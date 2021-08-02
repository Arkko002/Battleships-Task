using Battleships.Player;
using Battleships.Rules;
using Battleships.Ships;
using Moq;
using Xunit;

namespace Tests.Battleships.Rules
{
    public class OfficialRulesTests
    {
        private OfficialRules _officialRules;
        private Mock<IPlayer> _mockPlayer;

        public OfficialRulesTests()
        {
            _officialRules = new OfficialRules();
            _mockPlayer = new Mock<IPlayer>();
        }

        [Fact]
        public void DidPlayerWin_PlayerWin()
        {
            var ships = new IShip[]
            {
                new Destroyer() { IsDestroyed = false},
                new Carrier() { IsDestroyed = false},
                new Submarine() { IsDestroyed = true },
                new Cruiser() { IsDestroyed = true }
            };

            _mockPlayer.Setup(x => x.TrackingBoard.DestroyedShipsCount).Returns(1);
            _mockPlayer.Setup(x => x.GameRules.GetTotalShips()).Returns(1);
            _mockPlayer.Setup(x => x.Ships).Returns(ships);
            
            Assert.True(_officialRules.DidPlayerWin(_mockPlayer.Object) == WinStatus.PlayerWon);
        }

        [Fact]
        public void DidPlayerWin_Draw()
        {
            var ships = new IShip[]
            {
                new Destroyer() { IsDestroyed = true},
                new Carrier() { IsDestroyed = true},
                new Submarine() { IsDestroyed = true },
                new Cruiser() { IsDestroyed = true }
            };
            
            _mockPlayer.Setup(x => x.TrackingBoard.DestroyedShipsCount).Returns(1);
            _mockPlayer.Setup(x => x.GameRules.GetTotalShips()).Returns(1);
            _mockPlayer.Setup(x => x.Ships).Returns(ships);

            Assert.True(_officialRules.DidPlayerWin(_mockPlayer.Object) == WinStatus.Draw);
        }

        [Fact]
        public void DidPlayerWin_GameInProgress()
        {
            var ships = new IShip[]
            {
                new Destroyer() { IsDestroyed = false},
                new Carrier() { IsDestroyed = false},
                new Submarine() { IsDestroyed = true },
                new Cruiser() { IsDestroyed = true }
            };
            
            _mockPlayer.Setup(x => x.TrackingBoard.DestroyedShipsCount).Returns(1);
            _mockPlayer.Setup(x => x.GameRules.GetTotalShips()).Returns(2);
            _mockPlayer.Setup(x => x.Ships).Returns(ships);
            
            Assert.True(_officialRules.DidPlayerWin(_mockPlayer.Object) == WinStatus.GameInProgress);
        }
    }
}