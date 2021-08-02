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
        
        public IPlayersBoard SecondPlayersBoard { get; }
        public ITrackingBoard SecondTrackingBoard { get; }
        
        public int TimeCounter { get; }
        
        public WinStatus CurrentWinStatus { get; }
        
        public GameState(IPlayersBoard firstPlayersBoard, ITrackingBoard firstTrackingBoard, IPlayersBoard secondPlayersBoard, ITrackingBoard secondTrackingBoard, WinStatus currentWinStatus, int timeCounter)
        {
            FirstPlayersBoard = firstPlayersBoard;
            FirstTrackingBoard = firstTrackingBoard;
            SecondPlayersBoard = secondPlayersBoard;
            SecondTrackingBoard = secondTrackingBoard;
            CurrentWinStatus = currentWinStatus;
            TimeCounter = timeCounter;
        }
    }
}