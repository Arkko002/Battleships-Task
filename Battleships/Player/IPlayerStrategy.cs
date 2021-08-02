using System.Collections.Generic;
using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Rules;
using Battleships.Ships;

namespace Battleships.Player
{
    /// <summary>
    /// Exposes actions to <see cref="IPlayer"/> that allow it make decisions about game mechanics.
    /// </summary>
    public interface IPlayerStrategy
    {
        IPlayersBoard PlayersBoard { get; }
        
        void PlaceShips(IEnumerable<IShip> ships);
        
        Coordinates GetShotCoordinates(byte boardVerticalSize, byte boardHorizontalSize);
    }
}