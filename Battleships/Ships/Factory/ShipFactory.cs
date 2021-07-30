using System.Collections.Generic;
using Battleships.Rules;

namespace Battleships.Ships
{
    public class ShipFactory : IShipFactory
    {
        public IList<IShip> GetShips(IGameRules gameRules)
        {
            var shipList = new List<IShip>();
            
            for (int i = 0; i < gameRules.MaxCarriers; i++)
            {
                shipList.Add(new Carrier());
            }
            for (int i = 0; i < gameRules.MaxBattleships; i++)
            {
                shipList.Add(new Battleship());
            }
            for (int i = 0; i < gameRules.MaxCruiser; i++)
            {
                shipList.Add(new Cruiser());
            }
            for (int i = 0; i < gameRules.MaxDestroyer; i++)
            {
                shipList.Add(new Destroyer());
            }
            for (int i = 0; i < gameRules.MaxSubmarine; i++)
            {
                shipList.Add(new Submarine());
            }

            return shipList;
        }
    }
}