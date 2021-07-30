using System.Collections.Generic;
using Battleships.Board;
using Battleships.Board.PlayersBoard;
using Battleships.Board.TrackingBoard;
using Battleships.Rules;
using Battleships.Ships;

namespace Battleships.Player
{
    /// <summary>
    /// Main player interface responsible for managing boards and creating shot coordinates.
    /// </summary>
    public interface IPlayer
    {
        IPlayersBoard PlayersBoard { get; }
        ITrackingBoard TrackingBoard { get; }
        
        IGameRules GameRules { get; }
        
        IPlayerStrategy PlayerStrategy { get; }
        IList<IShip> Ships { get; }

        Coordinates Shoot();

        TrackingFieldState ProcessShot(Coordinates coordinates);
        void UpdateTrackingBoard(Coordinates coordinates, TrackingFieldState fieldState);
    }
}