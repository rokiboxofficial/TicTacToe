using NUnit.Framework;
using TicTacToe.Tests.TestingApi;

namespace TicTacToe.Tests.UnitTests;

public class GameEndingsTests
{
    #region RowTests
    
    [Test]
    public void WhenNewGameWasCreated_AndCrossesWasFilledTopRow_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Left, Row.Bottom);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Middle, Row.Bottom);
        game.MakeTurn(Column.Right, Row.Top);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.CrossesWin);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasCreated_AndNoughtsWasFilledTopRow_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Left, Row.Bottom);
        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Middle, Row.Bottom);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Left, Row.Middle);
        game.MakeTurn(Column.Right, Row.Top);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.NoughtsWin);

        Assert.AreEqual(expected, actual);
    }
    
    #endregion

    #region ColumnTests

    [Test]
    public void WhenNewGameWasCreated_AndCrossesWasFilledLeftColumn_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Right, Row.Top);
        game.MakeTurn(Column.Left, Row.Middle);
        game.MakeTurn(Column.Right, Row.Middle);
        game.MakeTurn(Column.Left, Row.Bottom);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.CrossesWin);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasCreated_AndNoughtsWasFilledLeftColumn_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Right, Row.Top);

        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Left, Row.Middle);
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Left, Row.Bottom);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.NoughtsWin);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region DiagonalTests

    [Test]
    public void WhenNewGameWasCreated_AndCrossesWasFilledMainDiagonal_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Right, Row.Top);
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Left, Row.Bottom);
        game.MakeTurn(Column.Right, Row.Bottom);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.CrossesWin);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasCreated_AndNoughtsWasFilledMainDiagonal_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Right, Row.Top);
        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Left, Row.Bottom);
        game.MakeTurn(Column.Right, Row.Bottom);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.NoughtsWin);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasCreated_AndCrossesWasFilledAntiDiagonal_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Right, Row.Top);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Middle, Row.Bottom);
        game.MakeTurn(Column.Left, Row.Bottom);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.CrossesWin);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasCreated_AndNoughtsWasFilledAntiDiagonal_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Right, Row.Middle);
        game.MakeTurn(Column.Right, Row.Top);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Middle, Row.Bottom);
        game.MakeTurn(Column.Left, Row.Bottom);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.NoughtsWin);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region DrawTests

    [Test]
    public void WhenNewGameWasCreated_AndBoardWasFullyFilledAndNoOneWinCondition_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Left, Row.Top);
        game.MakeTurn(Column.Left, Row.Middle);
        game.MakeTurn(Column.Middle, Row.Top);
        game.MakeTurn(Column.Right, Row.Top);
        game.MakeTurn(Column.Right, Row.Middle);
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Left, Row.Bottom);
        game.MakeTurn(Column.Middle, Row.Bottom);
        game.MakeTurn(Column.Right, Row.Bottom);
        
        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.End, GameResult.Draw);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ContinueTests

    [Test]
    public void WhenNewGameWasStarted_AndCrossesMadeOneTurnInMiddleOfBoard_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Middle, Row.Middle);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.Running, null!);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WhenNewGameWasStarted_AndNoughtsMadeOneTurnInLeftTopCornerAfterCrossesMadeTurnIntoMiddleOfBoard_ThenGameStateShouldBeCorrect()
    {
        // Arrange.
        var game = new Game();

        // Act.
        game.MakeTurn(Column.Middle, Row.Middle);
        game.MakeTurn(Column.Left, Row.Top);

        // Assert.
        var actual = game.GameState;
        var expected = new GameState(GameStage.Running, null!);

        Assert.AreEqual(expected, actual);
    }

    #endregion 
}