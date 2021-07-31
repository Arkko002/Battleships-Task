using System.Collections.Generic;
using System.Linq;
using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Player;
using Battleships.Rules;
using Battleships.Ships;
using Moq;
using Xunit;

namespace Tests.Battleships.Player
{
    public class SimplePlayerStrategyTests
    {
        private SimplePlayerStrategy _playerStrategy;
        private IPlayersBoard _playersBoard;
        private Mock<IShipFactory> _shipFactory;

        public SimplePlayerStrategyTests()
        {
            _playersBoard = new PlayersBoard(20, 20);
            
            _shipFactory = new Mock<IShipFactory>();
            _playerStrategy = new SimplePlayerStrategy(_playersBoard, _shipFactory.Object);
        }
        
        [Theory]
        [InlineData(1,1)]
        [InlineData(5,5)]
        [InlineData(255, 255)]
        [InlineData(0,0)]
        public void GetShotCoordinates_WithinBoardSize(byte horizontal, byte vertical)
        {
            var coordinates = _playerStrategy.GetShotCoordinates(horizontal, vertical);
            
            Assert.InRange(coordinates.Horizontal, 0, horizontal);
            Assert.InRange(coordinates.Vertical, 0, vertical);
        }


        [Theory]
        [MemberData(nameof(ShipData))]
        public void PlaceShips_PlacesAllShips(IShip ship1, IShip ship2, IShip ship3)
        {
            var totalShipSize = ship1.Size + ship2.Size + ship3.Size;
            _shipFactory.Setup(x => x.GetShips(It.IsAny<IGameRules>()))
                .Returns(new List<IShip> { ship1, ship2, ship3 });
            
            _playerStrategy.PlaceShips(new Mock<IGameRules>().Object);
            var query = from IShip ship in _playersBoard.Fields
                where ship != null
                select ship;
            
            Assert.True(query.Contains(ship1) && query.Contains(ship2) && query.Contains(ship3));
            Assert.True(totalShipSize == query.Count());
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