namespace Battleships.Board
{
    /// <summary>
    /// Helper class to store positions on board.
    /// </summary>
    public class Coordinates
    {
        public byte Horizontal { get; }
        public byte Vertical { get; }
        
        public Coordinates(byte horizontal, byte vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }
    }
}