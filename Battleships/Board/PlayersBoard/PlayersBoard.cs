using System;
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
            foreach (var offset in ship.CoordinatesOffsets)
            {
                CheckForOverlapping(ship.Coordinates.Horizontal + offset, ship.Coordinates.Vertical);
                Fields[ship.Coordinates.Horizontal + offset, ship.Coordinates.Vertical] = ship;
            }
        }

        private void PlaceShipVertically(IShip ship)
        {
            foreach (var offset in ship.CoordinatesOffsets)
            {
                CheckForOverlapping(ship.Coordinates.Horizontal, ship.Coordinates.Vertical + offset);
                Fields[ship.Coordinates.Horizontal, ship.Coordinates.Vertical + offset] = ship;
            }
        }

        /// <summary>
        /// Checks if a field specified by passed parameters is already occupied, throws an exception if so.
        /// </summary>
        /// <param name="horizontalPos"></param>
        /// <param name="verticalPos"></param>
        /// <exception cref="ArgumentException"></exception>
        private void CheckForOverlapping(int horizontalPos, int verticalPos)
        {
            var field = Fields[horizontalPos, verticalPos];
            if (field != null)
            {
                throw new ArgumentException("Tried placing ship on occupied field.");
            }
        }

        private void CheckIfOutOfBounds(int horizontalPos, int verticalPos)
        {
            if (horizontalPos < 0 || HorizontalSize < horizontalPos ||
                verticalPos < 0 || VerticalSize < verticalPos)
            {
                throw new IndexOutOfRangeException("Tried placing ship out of bounds");
            }
        }
    }
}