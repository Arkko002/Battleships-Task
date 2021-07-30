namespace Battleships.Board.TrackingBoard
{
    /// <summary>
    /// Board interface that doesn't expose details of ships positions. <br/>
    /// Stores information about hits, misses, and count of destroyed ships. <br/><br/>
    ///
    /// For information about specific fields see <see cref="TrackingFieldState"/>
    /// </summary>
    public interface ITrackingBoard : IBoard
    {
        byte DestroyedShipsCount { get; }
        TrackingFieldState[,] Fields { get; }
        void SetFieldState(Coordinates coordinates, TrackingFieldState fieldState);
    }
}