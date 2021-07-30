using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Board.TrackingBoard;
using Battleships.Rules;

namespace Battleships
{
    /// <summary>
    /// Data transfer object containing current state of the boards, and game info.
    /// </summary>
    public class GameState
    {
        public IPlayersBoard FirstPlayersBoard { get; }
        public ITrackingBoard FirstTrackingBoard { get; }
        
        public IPlayersBoard SecondPlayerBoard { get; }
        public ITrackingBoard SecondTrackingBoard { get; }
        
        public int TimeCounter { get; }
        
        public WinStatus CurrentWinStatus { get; }
        
        public GameState(IPlayersBoard firstPlayersBoard, ITrackingBoard firstTrackingBoard, IPlayersBoard secondPlayerBoard, ITrackingBoard secondTrackingBoard, WinStatus currentWinStatus, int timeCounter)
        {
            FirstPlayersBoard = firstPlayersBoard;
            FirstTrackingBoard = firstTrackingBoard;
            SecondPlayerBoard = secondPlayerBoard;
            SecondTrackingBoard = secondTrackingBoard;
            CurrentWinStatus = currentWinStatus;
            TimeCounter = timeCounter;
        }
    }
}