using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Ships;

namespace Battleships.Board.PlayersBoard
{
    /// <summary>
    /// <inheritdoc cref="IPlayersBoard"/>
    /// </summary>
    public class PlayersBoard : IPlayersBoard
    {
        public byte VerticalSize { get; }
        public byte HorizontalSize { get; }
        public IShip?[,] Fields { get; }

        public PlayersBoard(byte verticalSize, byte horizontalSize)
        {
            VerticalSize = verticalSize;
            HorizontalSize = horizontalSize;

            // Initialize all fields with no ship assigned
            Fields = new IShip?[VerticalSize, HorizontalSize];
            for (int i = 0; i < VerticalSize; i++)
            {
                for (int j = 0; j < HorizontalSize; j++)
                {
                    Fields[i, j] = null;
                }
            }
        }

        /// <summary>
        /// Adds the boat to <see cref="Fields"/> according to the parameters. <br/><br/>
        /// Performs basic checks verifying that provided values are correct.
        /// </summary>
        /// <param name="ship"></param>
        public void PlaceShip(IShip ship)
        {
            switch (ship.Orientation)
            {
                case ShipOrientation.Horizontal:
                    PlaceShipHorizontally(ship);
                    break;
                
                case ShipOrientation.Vertical:
                    PlaceShipVertically(ship);
                    break;
            }
        }

        private void PlaceShipHorizontally(IShip ship)
        {
            List<Coordinates> offsets = ship.CoordinatesOffsets.Select(offset => new Coordinates((byte)(ship.Coordinates.Horizontal + offset),
                ship.Coordinates.Vertical)).ToList();

            CheckIfOutOfBounds(offsets);
            CheckForOverlapping(offsets);

            foreach (var offset in offsets)
            {
                Fields[offset.Horizontal, offset.Vertical] = ship;
            }
        }

        private void PlaceShipVertically(IShip ship)
        {
            List<Coordinates> offsets = ship.CoordinatesOffsets.Select(offset => new Coordinates(ship.Coordinates.Horizontal,
                (byte)(ship.Coordinates.Vertical + offset))).ToList();

            CheckIfOutOfBounds(offsets);
            CheckForOverlapping(offsets);

            foreach (var offset in offsets)
            {
                Fields[offset.Horizontal, offset.Vertical] = ship;
            }
        }

        /// <summary>
        /// Checks if any of the provided coordinates is already occupied
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void CheckForOverlapping(List<Coordinates> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                var field = Fields[coordinate.Horizontal, coordinate.Vertical];
                if (field != null)
                {
                    throw new ArgumentException("Tried placing ship on occupied field.");
                }
            }
        }

        private void CheckIfOutOfBounds(List<Coordinates> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (coordinate.Horizontal > HorizontalSize || coordinate.Vertical > VerticalSize)
                {
                    throw new IndexOutOfRangeException("Tried placing ship out of bounds");
                }
            }
        }
    }
}
