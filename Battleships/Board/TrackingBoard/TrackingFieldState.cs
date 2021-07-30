namespace Battleships.Board.TrackingBoard
{
    /// <summary>
    /// Describes the state of a single field on a tracking board. <br/><br/>
    /// See <see cref="ITrackingBoard"/>
    /// </summary>
    public enum TrackingFieldState
    {
        NoState,
        Empty,
        Miss,
        Hit,
        DestroyedShip
    }
}