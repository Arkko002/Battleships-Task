using Battleships.Player;

namespace Battleships.Rules
{
    /// <summary>
    /// TIme running out win condition ruleset.
    /// </summary>
    public class TimeoutRules : IWinningRules
    {
        private readonly int _timeCounter;
        
        public TimeoutRules(ref int timeCounter)
        {
            _timeCounter = timeCounter;
        }
        
        public WinStatus DidPlayerWin(IPlayer player)
        {
            if (_timeCounter > player.GameRules.GameTime)
            {
                return WinStatus.Draw;
            }

            return WinStatus.GameInProgress;
        }
    }
}