namespace TicTacToe;

public interface IGameState
{
    public GameStage GameStage { get; } 
    public GameResult? GameResult { get; }
}