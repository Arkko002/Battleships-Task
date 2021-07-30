using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Rules;

namespace Battleships.Player
{
    /// <summary>
    /// Exposes actions to <see cref="IPlayer"/> that allow it make decisions about game mechanics.
    /// </summary>
    public interface IPlayerStrategy
    {
        IPlayersBoard PlayersBoard { get; }
        
        void PlaceShips(IGameRules gameRules);
        
        Coordinates GetShotCoordinates(byte boardVerticalSize, byte boardHorizontalSize);
    }
}