using Battleships.Board;

namespace Battleships.Ships
{
    public class Cruiser : IShip
    {
        public ShipOrientation Orientation { get; set; }
        public Coordinates Coordinates { get; set; }
        public byte[] CoordinatesOffsets { get; } = { 0, 1, 2 };
        public byte Size => (byte)CoordinatesOffsets.Length;
        public byte NumOfHits { get; set; } = 0;
        public bool IsDestroyed { get; set; } = false;
    }
}