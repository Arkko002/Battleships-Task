namespace Battleships.Rules
{
    /// <summary>
    /// Represents general rules of the game, like game time, numbers of ships and board dimensions. <br/><br/>
    /// For rules describing winning conditions see <see cref="IWinningRules"/>
    /// </summary>
    public interface IGameRules
    {
        byte MaxCarriers { get; }
        byte MaxBattleships { get; }
        byte MaxCruiser { get; }
        byte MaxSubmarine { get; }
        byte MaxDestroyer { get; }
        int GetTotalShips();
        
        /// <summary>
        /// Because the game is played out between two bots time is counted on basis of moves.
        /// </summary>
        short GameTime { get; }
        
        
        byte BoardVerticalSize { get; }
        byte BoardHorizontalSize { get; }
    }
}