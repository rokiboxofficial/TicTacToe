using TicTacToe;
using System.Drawing;

namespace TicTacToe.Tests.TestingApi;

internal static class GameExtensions
{
    internal static void MakeTurn(this Game game, Column column, Row row)
    {
        var x = (int) column;
        var y = (int) row;
        var point = new Point(x, y);

        game.MakeTurn(point);
    }
}