namespace TicTacToe;

public sealed class GameState : IGameState
{
    public GameState(GameStage gameStage = GameStage.Running, GameResult? gameResult = null)
    {
        GameStage = gameStage;
        GameResult = gameResult;
    }


    public GameStage GameStage { get; set; }
    public GameResult? GameResult { get; set; }

    public override bool Equals(object? obj)
    {
        var gameState = obj as GameState;
        if(gameState == null) return false;

        return  GameStage == gameState.GameStage &&
                GameResult == gameState.GameResult;
    }

    public override int GetHashCode()
        => GameStage.GetHashCode() ^ GameResult.GetHashCode() ^ 11;
}