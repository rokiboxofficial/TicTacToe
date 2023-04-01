using System.Linq;
using System.Drawing;

namespace TicTacToe;

internal sealed class GameStateDeterminer
{
    private readonly CellKind[,] _board;

    public GameStateDeterminer(CellKind[,] board)
    {
        _board = board;
    }

    public GameState GetGameState()
    {
        if(IsWin(CellKind.Cross))
            return Win(PlayerKind.Cross);
        else if(IsWin(CellKind.Nought))
            return Win(PlayerKind.Nought);
        else if(AllCellsAreUsed())
            return Draw();
        else
            return Continue();
    }

    private GameState Continue()
        => new GameState(GameStage.Running, null!);

    private GameState Win(PlayerKind playerKind)
    {
        var gameResult = playerKind == PlayerKind.Cross ? GameResult.CrossesWin : GameResult.NoughtsWin;
        var gameState = new GameState(GameStage.End, gameResult);
        return gameState;
    }

    private GameState Draw()
        => new GameState(GameStage.End, GameResult.Draw);

    private bool AllCellsAreUsed()
    {
        foreach(var cell in _board)
            if(cell == CellKind.Empty)
                return false;
                
        return true;
    }

    private bool IsWin(CellKind cellKind)
        => IsDiagonalWin(cellKind) || IsRowWin(cellKind) || IsColumnWin(cellKind);

    private bool IsDiagonalWin(CellKind cellKind)
    {
        var mainDiagonalInclineDirection = new Point(1, -1);
        var antiDiagonalInclineDirection = new Point(-1, -1);

        return  IsInclineWin(cellKind, mainDiagonalInclineDirection) ||
                IsInclineWin(cellKind, antiDiagonalInclineDirection);
    }

    private bool IsInclineWin(CellKind cellKind, Point inclineDirection)
    {
        var center = new Point(1, 1);
        var points = new List<Point>(3) {center};
        points.Add(new Point(center.X + inclineDirection.X, center.Y + inclineDirection.Y));
        points.Add(new Point(center.X - inclineDirection.X, center.Y - inclineDirection.Y));

        return points.All(point => _board[point.Y, point.X] == cellKind);
    }

    private bool IsRowWin(CellKind cellKind)
    {
        return Enumerable
                .Range(0, 3)
                .Any(y => Enumerable.Range(0, 3).All(x => _board[y, x] == cellKind));
    }

    private bool IsColumnWin(CellKind cellKind)
    {
        return Enumerable
                .Range(0, 3)
                .Any(x => Enumerable.Range(0, 3).All(y => _board[y, x] == cellKind));
    }
}