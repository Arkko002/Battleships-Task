using Battleships.Rules;

namespace Battleships
{
    /// <summary>
    /// Main interface representing the game, responsible for controlling it's flow.
    /// </summary>
    public interface IBattleshipsGame
    {
        IGameRules GameRules { get; set; }
        WinStatus CurrentWinStatus { get; }

        /// <summary>
        /// Sets all the variables to their initial state based on game rules.
        /// </summary>
        void StartGame();
        
        
        /// <summary>
        /// Currently started game proceeds forward with one move. <br/><br/>
        /// See <see cref="IWinningRules"/> for details about determining winning player
        /// </summary>
        /// <returns>An enum indicating state of the game</returns>
        GameState NextMove();

        /// <summary>
        /// Creates a DTO object that encapsulates data describing game's progress without modifying game's state.
        /// </summary>
        /// <returns></returns>
        GameState GetGameState();
    }
}