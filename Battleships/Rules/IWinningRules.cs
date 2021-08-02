using Battleships.Player;

namespace Battleships.Rules
{
    /// <summary>
    /// Determines winner of the game based on algorithm in the implementations. <br/><br/>
    /// For general rules see <see cref="IGameRules"/>.
    /// </summary>
    public interface IWinningRules
    {
        WinStatus DidPlayerWin(IPlayer player);
    }
}