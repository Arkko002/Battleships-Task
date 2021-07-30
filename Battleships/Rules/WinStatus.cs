namespace Battleships.Rules
{
    /// <summary>
    /// Describes the current status of ongoing game.
    /// See <see cref="IWinningRules"/> for more information about win conditions.
    /// </summary>
    public enum WinStatus
    {
        NoState,
        GameInProgress,
        PlayerWon,
        Draw
    }
}