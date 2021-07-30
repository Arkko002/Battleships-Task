using System.Collections.Generic;
using Battleships.Rules;

namespace Battleships.Ships
{
    public interface IShipFactory
    {
        /// <summary>
        /// Handles initialization of IShip instances that will be placed on the board by IPlayer
        /// </summary>
        /// <param name="gameRules"></param>
        /// <returns>List of initialized ships with no coordinates assigned</returns>
        IList<IShip> GetShips(IGameRules gameRules);
    }
}