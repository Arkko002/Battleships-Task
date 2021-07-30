using System.Linq;
using Battleships.Rules;
using Battleships.Ships;
using Xunit;

namespace Tests.Battleships.Ships
{
    public class ShipFactoryTests
    {
        private ShipFactory _shipFactory;

        public ShipFactoryTests()
        {
            _shipFactory = new ShipFactory();
        }

        [Fact]
        void GetShips_ReturnsListOfShips()
        {
            var gameRules = new GameRules(1, 2, 3, 4, 5, 10, 10, 10);

            var ships = _shipFactory.GetShips(gameRules);
            
            Assert.True(ships.Count(x => x.GetType() == typeof(Carrier)) == 1);
            Assert.True(ships.Count(x => x.GetType() == typeof(Battleship)) == 2);
            Assert.True(ships.Count(x => x.GetType() == typeof(Cruiser)) == 3);
            Assert.True(ships.Count(x => x.GetType() == typeof(Submarine)) == 4);
            Assert.True(ships.Count(x => x.GetType() == typeof(Destroyer)) == 5);
        }
    }
}