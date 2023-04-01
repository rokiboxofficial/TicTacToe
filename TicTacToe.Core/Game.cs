using System.Drawing;

namespace TicTacToe;

public sealed class Game
{
    public const int Size = 3;
    private static readonly Dictionary<PlayerKind, CellKind> _cellKindByPlayerKind = new ()
    {
        [PlayerKind.Cross] = CellKind.Cross,
        [PlayerKind.Nought] = CellKind.Nought
    };
    private readonly CellKind[,] _board;
    private readonly GameStateDeterminer _gameStateDeterminer;

    public Game()
    {
        _board = new CellKind[Size,Size];
        _gameStateDeterminer = new GameStateDeterminer(_board);
        GameState = new GameState();
        CurrentTurn = PlayerKind.Cross;
    }

    public IGameState GameState { get; private set; }
    public PlayerKind CurrentTurn { get; private set; }

    public CellKind this[Point point]
    {
        private set => _board[point.Y, point.X] = value;
        get => _board[point.Y, point.X];
    }

    public void MakeTurn(Point point)
    {
        if(GameState.GameStage == GameStage.End)
            throw new InvalidOperationException("Game is ended");

        var cell = this[point];
        
        if(cell != CellKind.Empty)
            throw new InvalidOperationException("This cell is already occupied");
        
        var currentTurnKind = _cellKindByPlayerKind[CurrentTurn];
        this[point] = currentTurnKind;

        UpdateGameState();
        PassCurrentTurn();
    }

    private void UpdateGameState()
        => GameState = _gameStateDeterminer.GetGameState();

    private void PassCurrentTurn()
    {
        CurrentTurn = CurrentTurn == PlayerKind.Cross 
        ? PlayerKind.Nought
        : PlayerKind.Cross;   
    }
}