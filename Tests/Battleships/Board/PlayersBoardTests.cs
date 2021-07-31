using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Ships;
using Xunit;

namespace Tests.Battleships.Board
{
    public class PlayersBoardTests
    {
        private readonly PlayersBoard _playersBoard;

        public PlayersBoardTests()
        {
            _playersBoard = new PlayersBoard(10, 10);
        }

        /// <summary>
        /// xUnit calls the constructor before each test in this case,
        /// there will be no race conditions. <br/>
        /// See more <a href="https://xunit.net/docs/shared-context">here</a>
        /// </summary>
        [Fact]
        public void Constructor_AllFieldsNull()
        {
            // Flatten the 2D array to use Linq on it
            var query = from IShip ship in _playersBoard.Fields
                select ship;
            
            Assert.True(query.All(x => x == null));
        }
        
        [Theory, MemberData(nameof(ShipData))]
        public void PlaceShips_InBounds(IShip ship1, IShip ship2, IShip ship3)
        {
            _playersBoard.PlaceShip(ship1);
            _playersBoard.PlaceShip(ship2);
            _playersBoard.PlaceShip(ship3);
            
            // Flatten the 2D array to use Linq on it
            var query = from IShip ship in _playersBoard.Fields
                where ship != null
                select ship;
            
            var totalShipsSize = ship1.Size + ship2.Size + ship3.Size;

            Assert.True(query.Count() == totalShipsSize);
        }
        
        [Fact]
        public void PlaceShip_OutOfBoundsHorizontal()
        {
            var ship = new Carrier();
            ship.Orientation = ShipOrientation.Horizontal;
            ship.Coordinates = new Coordinates((byte)(_playersBoard.Fields.GetLength(0) + 1), 0);
            
            Assert.ThrowsAny<Exception>(() => _playersBoard.PlaceShip(ship));
        }

        [Fact]
        public void PlaceShip_OutOfBoundsVertical()
        {
            var ship = new Carrier();
            ship.Orientation = ShipOrientation.Vertical;
            ship.Coordinates = new Coordinates(0, (byte)(_playersBoard.Fields.GetLength(1) + 1));
            
            Assert.ThrowsAny<Exception>(() => _playersBoard.PlaceShip(ship));
        }

        [Fact]
        public void PlaceShip_Overlapping()
        {

            var ship = new Carrier
            {
                Orientation = ShipOrientation.Horizontal,
                Coordinates = new(0, 0)
            };
            var ship2 = new Carrier();
            ship2.Orientation = ShipOrientation.Horizontal;
            ship2.Coordinates = new(0, 0);
            
            _playersBoard.PlaceShip(ship);
            Assert.ThrowsAny<Exception>(() => _playersBoard.PlaceShip(ship2));
        }

        public static IEnumerable<object[]> ShipData =>
            new List<object[]>
            {
                new object[]
                {
                    new Carrier { Orientation = ShipOrientation.Horizontal, Coordinates = new Coordinates(1, 1) },
                    new Battleship { Orientation = ShipOrientation.Vertical, Coordinates = new Coordinates(5, 5) },
                    new Submarine { Orientation = ShipOrientation.Horizontal, Coordinates = new Coordinates(6, 1) }
                }
            };
    }
}
