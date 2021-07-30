using System;
using System.Reflection;
using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Rules;
using Battleships.Ships;

namespace Battleships.Player
{
    /// <summary>
    /// A demonstration of <see cref="IPlayerStrategy"/> that mostly relies on pseudo-random values.
    /// </summary>
    public class SimplePlayerStrategy : IPlayerStrategy
    {
        public IPlayersBoard PlayersBoard { get; }
        private Random _random = new Random();
        private IShipFactory _shipFactory = new ShipFactory();

        public SimplePlayerStrategy(IPlayersBoard playersBoard)
        {
            PlayersBoard = playersBoard;
        }

        
        public void PlaceShips(IGameRules gameRules)
        {
            var ships = _shipFactory.GetShips(gameRules);

            foreach (var ship in ships)
            {
               TryPlacingShip(ship); 
            }
        }

        public Coordinates GetShotCoordinates(byte boardHorizontalSize,byte boardVerticalSize)
            
        {
            byte verticalPos = (byte)_random.Next(0, boardVerticalSize);
            byte horizontalPos = (byte)_random.Next(0, boardHorizontalSize);

            return new Coordinates(horizontalPos, verticalPos);
        }

        private void TryPlacingShip(IShip ship)
        {
            // Loop until successfully placed
            while (true)
            {
                // Create ship parameters using random values 
                ship.Orientation = (ShipOrientation)_random.Next(0, 3);
                byte verticalPos = (byte)_random.Next(0, PlayersBoard.VerticalSize);
                byte horizontalPos = (byte)_random.Next(0, PlayersBoard.HorizontalSize);
                ship.Coordinates = new Coordinates(horizontalPos, verticalPos);
                
                try
                {
                    PlayersBoard.PlaceShip(ship);
                    
                    // Return from function on successful placement
                    break;
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }
    }
}