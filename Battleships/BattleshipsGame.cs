using System.Collections.Generic;
using Battleships.Player;
using Battleships.Rules;
using Battleships.Board.PlayersBoard;
using Battleships.Board.TrackingBoard;
using Battleships.Ships;


namespace Battleships
{
    public class BattleshipsGame : IBattleshipsGame
    {
        private IGameRules _gameRules;
        public IGameRules GameRules
        {
            get => _gameRules;
            set
            {
                _gameRules = value;
                StartGame();
            }
        }

        public WinStatus CurrentWinStatus { get; private set; }

        private IEnumerable<IWinningRules> WinningRules { get; }


        private IPlayer FirstPlayer { get; set; }
        private IPlayer SecondPlayer { get; set; }

        public int TimeCounter { get; set; }

        public BattleshipsGame(IGameRules gameRules, IList<IWinningRules> winningRulesList, ref int timeCounter)
        {
            GameRules = gameRules;

            WinningRules = winningRulesList;
            TimeCounter = timeCounter;

            StartGame();
        }
        
        public void StartGame()
        {
            var firstPlayersBoard = new PlayersBoard(GameRules.BoardVerticalSize, GameRules.BoardHorizontalSize);
            var secondPlayersBoard = new PlayersBoard(GameRules.BoardVerticalSize, GameRules.BoardHorizontalSize);

            var firstTrackingBoard = new TrackingBoard(GameRules.BoardVerticalSize, GameRules.BoardHorizontalSize); 
            var secondTrackingBoard = new TrackingBoard(GameRules.BoardVerticalSize, GameRules.BoardHorizontalSize);

            FirstPlayer = new SimplePlayer(firstPlayersBoard, firstTrackingBoard, new SimplePlayerStrategy(firstPlayersBoard),
                GameRules, new ShipFactory());
            SecondPlayer = new SimplePlayer(secondPlayersBoard, secondTrackingBoard, new SimplePlayerStrategy(secondPlayersBoard),
                GameRules, new ShipFactory());

            TimeCounter = 1;
            CurrentWinStatus = WinStatus.GameInProgress;
        }

        public GameState NextMove()
        {
            var playersTurn = TimeCounter % 2;
            TimeCounter++;
            
            if (playersTurn == 1)
            {
                ProcessTurn(FirstPlayer, SecondPlayer);
                return GetGameState();
            }

            ProcessTurn(SecondPlayer, FirstPlayer);
            return GetGameState();

        }

        public GameState GetGameState()
        {
            return new GameState(FirstPlayer.PlayersBoard, FirstPlayer.TrackingBoard, SecondPlayer.PlayersBoard,
                SecondPlayer.TrackingBoard, CurrentWinStatus, TimeCounter);
        }

        /// <summary>
        /// Processes shot information for current player's turn. <br/>
        /// Will update <see cref="CurrentWinStatus"/> if a win condition occured.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        private void ProcessTurn(IPlayer player, IPlayer enemy)
        {
            var coordinates = player.Shoot();
            var fieldState = enemy.ProcessShot(coordinates);
            player.UpdateTrackingBoard(coordinates, fieldState);
            
            foreach (var winningRule in WinningRules)
            {
                var status = winningRule.DidPlayerWin(player);
                if (status != WinStatus.GameInProgress)
                {
                    CurrentWinStatus = status;
                }
            }
        }
    }
}