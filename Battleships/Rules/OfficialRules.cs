using Battleships.Board;
using System.Linq;
using Battleships.Player;

namespace Battleships.Rules
{
    /// <summary>
    /// Simple ruleset based on the official Battleships rules. <br/><br/>
    /// For more information see rules <a href="https://en.wikipedia.org/wiki/Battleship_(game)#Description">here</a>
    /// </summary>
    public class OfficialRules : IWinningRules
    {
        public WinStatus DidPlayerWin(IPlayer player)
        {
            if (player.TrackingBoard.DestroyedShipsCount == player.GameRules.GetTotalShips())
            {
                if (player.Ships.All(x => x.IsDestroyed))
                {
                    return WinStatus.Draw;
                }

                return WinStatus.PlayerWon;
            }

            return WinStatus.GameInProgress;
        }
    }
}