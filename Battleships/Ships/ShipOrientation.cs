namespace Battleships.Ships
{
    /// <summary>
    /// Describes the direction from ship's coordinates the offsets span towards.
    /// <example>
    /// A horizontal direction and offset values [0, 1] means that a ship will take
    /// up two space, one of which will be towards the upper limit of board's horizontal axis. <br/><br/>
    ///
    /// Offsets [-1, 0] and horizontal direction means that one of the tiles of the ship will
    /// be placed closer to the lower limit of the board's horizontal axis.
    /// </example>
    /// </summary>
    public enum ShipOrientation
    {
        Horizontal,
        Vertical
    }
}