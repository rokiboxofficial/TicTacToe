using NUnit.Framework;
using TicTacToe.Tests.TestingApi;

namespace TicTacToe.Tests.UnitTests;

public class GameConsistencyTests
{
    [Test]
    public void WhenNewGameWasCreated_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.Running, null!);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasCreated_AndNoughtsMadeTurnIntoAlreadyOccupiedCell_ThenInvalidOperationExceptionShouldBeThrowed()
    {
        var unitUnderTest = new TestDelegate(() =>
        {
            // Arrange.
            var game = new Game();

            // Act.
            game.MakeTurn(Column.Middle, Row.Middle);
            game.MakeTurn(Column.Middle, Row.Middle);
        });

        // Assert.
        Assert.Throws<InvalidOperationException>(unitUnderTest);
    }

    [Test]
    public void WhenGameWasAlreadyEnded_AndNoughtsMadeTurnIntoEmptyCell_ThenInvalidOperationExceptionShouldBeThrowed()
    {
        var unitUnderTest = new TestDelegate(() =>
        {
            // Arrange.
            var game = new Game();
            game.MakeTurn(Column.Left, Row.Top);
            game.MakeTurn(Column.Right, Row.Top);
            game.MakeTurn(Column.Left, Row.Middle);
            game.MakeTurn(Column.Right, Row.Middle);
            game.MakeTurn(Column.Left, Row.Bottom);

            // Act.
            game.MakeTurn(Column.Middle, Row.Middle);
        });

        // Assert.
        Assert.Throws<InvalidOperationException>(unitUnderTest);
    }
}