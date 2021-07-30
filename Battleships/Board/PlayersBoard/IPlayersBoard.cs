using Battleships.Player;
using Battleships.Ships;

namespace Battleships.Board.PlayersBoard
{
    /// <summary>
    /// Allows <see cref="IPlayer"/> to store information about it's ships positions.
    /// </summary>
    public interface IPlayersBoard : IBoard
    {
        IShip?[,] Fields { get; }
        
        void PlaceShip(IShip ship);
    }
}