using Battleships.Board;

namespace Battleships.Ships
{
    public interface IShip
    {
        /// <summary>
        /// <inheritdoc cref="ShipOrientation"/>
        /// </summary>
        ShipOrientation Orientation { get; set; } 
        
        /// <summary>
        /// Starting position of ship on vertical and horizontal axis
        /// </summary>
        Coordinates Coordinates { get; set; } 
        
        /// <summary>
        /// Coordinates offset relative from position from <see cref="Coordinates"/> that the ship occupies/> <br/>
        /// First value should always be 0, that will be the center of ship placed on starting coordinates.
        /// </summary>
        byte[] CoordinatesOffsets { get; }

        byte Size => (byte)CoordinatesOffsets.Length;
        byte NumOfHits { get; set;}
        bool IsDestroyed { get; set; }

        /// <summary>
        /// Increments the hit count of the shit and sets IsDestroyed if it's greater than Size
        /// </summary>
        /// <returns><see cref="IsDestroyed"/> property</returns>
        void Hit()
        {
            NumOfHits++;

            if (NumOfHits == Size)
            {
                IsDestroyed = true;
            }
        }
    }
}