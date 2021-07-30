namespace Battleships.Rules
{
    /// <summary>
    /// A general rules object with no default variable values provided.
    /// </summary>
    public class GameRules : IGameRules
    {
        public byte MaxCarriers { get; }
        public byte MaxBattleships { get; }
        public byte MaxCruiser { get; }
        public byte MaxSubmarine { get; }
        public byte MaxDestroyer { get; }
        public short GameTime { get; }
        public byte BoardVerticalSize { get; }
        public byte BoardHorizontalSize { get; }
        
        public GameRules(byte maxCarriers, byte maxBattleships, byte maxCruiser, byte maxSubmarine, byte maxDestroyer, byte gameTime, byte boardVerticalSize, byte boardHorizontalSize)
        {
            MaxCarriers = maxCarriers;
            MaxBattleships = maxBattleships;
            MaxCruiser = maxCruiser;
            MaxSubmarine = maxSubmarine;
            MaxDestroyer = maxDestroyer;
            GameTime = gameTime;
            BoardVerticalSize = boardVerticalSize;
            BoardHorizontalSize = boardHorizontalSize;
        }

        public int GetTotalShips()
        {
            return MaxBattleships + MaxCarriers + MaxCruiser + MaxDestroyer + MaxSubmarine;

        }
    }
}