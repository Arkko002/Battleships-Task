using System.Collections.Generic;
using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Board.TrackingBoard;
using Battleships.Rules;
using Battleships.Ships;

namespace Battleships.Player
{
    /// <summary>
    /// A simple implementation of IPlayer interface that delegates most of the work to it's property objects.
    /// </summary>
    public class SimplePlayer : IPlayer
    {
        public IPlayersBoard PlayersBoard { get; }
        public ITrackingBoard TrackingBoard { get; }
        public IGameRules GameRules { get; }
        public IPlayerStrategy PlayerStrategy { get; }

        /// <summary>
        /// List of player's ships that will be initialised according to ship counts from <see cref="GameRules"/>
        /// </summary>
        public IList<IShip> Ships { get; }

        public SimplePlayer(IPlayersBoard playersBoard, ITrackingBoard trackingBoard, IPlayerStrategy playerStrategy, IGameRules gameRules)
        {
            PlayersBoard = playersBoard;
            TrackingBoard = trackingBoard;
            PlayerStrategy = playerStrategy;
            GameRules = gameRules;
            Ships = new List<IShip>();
            
            playerStrategy.PlaceShips(gameRules);
        }
        
        public Coordinates Shoot()
        {
            // Even tho this implementation of IPlayer interface relies mostly on underlying objects it still
            // serves a purpose at separating abstraction layers and preventing concern leakage to IBattleshipsGame implementations
            return PlayerStrategy.GetShotCoordinates(TrackingBoard.VerticalSize, TrackingBoard.HorizontalSize);
        }

        public TrackingFieldState ProcessShot(Coordinates coordinates)
        {
            var ship = PlayersBoard.Fields[coordinates.Horizontal, coordinates.Vertical];

            if (ship == null)
            {
                return TrackingFieldState.Miss;
            }

            ship.Hit();
            return ship.IsDestroyed ? TrackingFieldState.DestroyedShip : TrackingFieldState.Hit;
        }

        public void UpdateTrackingBoard(Coordinates coordinates, TrackingFieldState fieldState)
        {
            TrackingBoard.SetFieldState(coordinates, fieldState);
        }
    }
}