using Battleships.Player;
using Battleships.Rules;
using Moq;
using Xunit;

namespace Tests.Battleships.Rules
{
    public class TimeoutRulesTests
    {
        private Mock<IPlayer> _mockPlayer;

        public TimeoutRulesTests()
        {
            _mockPlayer = new Mock<IPlayer>();
        }

        [Fact]
        public void DidPlayerWin_TimeOut()
        {
            var timeCounter = 2;
            var timeoutRules = new TimeoutRules(ref timeCounter);
            _mockPlayer.Setup(x => x.GameRules.GameTime).Returns(1);
            
            Assert.True(timeoutRules.DidPlayerWin(_mockPlayer.Object) == WinStatus.Draw);
        }

        [Fact]
        public void DidPlayerWin_TimeLeft()
        {
            var timeCounter = 0;
            var timeoutRules = new TimeoutRules(ref timeCounter);
            _mockPlayer.Setup(x => x.GameRules.GameTime).Returns(1);
            
            Assert.True(timeoutRules.DidPlayerWin(_mockPlayer.Object) == WinStatus.GameInProgress);
        }

    }
}