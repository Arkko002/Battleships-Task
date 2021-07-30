namespace Battleships.Board
{
    /// <summary>
    /// Base board interface that's meant to be extended upon. <br/>
    /// Boards by default cannot be of non-existing size since 0x0 boards contain exactly one playing field.
    /// </summary>
    public interface IBoard
    {
        // This implementation supports only rectangle or square shaped boards
        // Creating irregular boards would require a different approach to specifying dimensions
        
        /// <summary>
        /// Size of the board on vertical axis starting at 0.
        /// </summary>
        byte VerticalSize { get; }
        
        /// <summary>
        /// Size of the board in horizontal axis starting at 0.
        /// </summary>
        byte HorizontalSize { get; }
    }
}