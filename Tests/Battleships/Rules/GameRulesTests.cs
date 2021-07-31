using System.Collections.Generic;
using Battleships.Rules;
using Xunit;

namespace Tests.Battleships.Rules
{
    public class GameRulesTests
    {
        [Theory, MemberData(nameof(GameRulesData))]
        public void GetTotalShips_ReturnsCorrectShipCount(byte maxCarriers, byte maxBattleships, byte maxCruisers, byte maxSubmarines, byte maxDestroyers)
        {
            var gameRules = new GameRules(maxCarriers, maxBattleships, maxCruisers, maxSubmarines, maxDestroyers, 1, 1,
                1);
            int totalTestShips = maxCarriers + maxBattleships + maxCruisers + maxSubmarines + maxDestroyers;
            
            Assert.True(gameRules.GetTotalShips() == totalTestShips);
        }

        public static IEnumerable<object[]> GameRulesData =>
            new List<object[]>
            {
                new object[] { 1, 1, 1, 1, 1 },
                new object[] { 3, 1, 6, 4, 8 },
                new object[] { 100, 100, 100, 100, 100 },
                new object[] { 0, 0, 0, 0, 0 },
            };
    }
}