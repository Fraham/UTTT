using System;
using Xunit;
using UltimateTicTacToe;

namespace UltimateTicTacToe.Tests
{
    public class BoardMinMax
    {
        [Fact]
        public void Simple_1_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 1, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 0, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_1_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 1, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 0, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_1_3()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 1, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 0, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_1_4()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 1, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 0, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_2_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 0, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 2, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_2_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 0, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 2, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_2_3()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 0, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 2, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Simple_2_4()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Player},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 0, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 2, $"Y: {result.Y} X: {result.X}");
        }






        [Fact]
        public void Diagonal_1_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 2, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 0, $"Y: {result.Y} X: {result.X}");
        }

        [Fact]
        public void Diagonal_1_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBestPosition();

            Assert.True(result.Y == 2, $"Y: {result.Y} X: {result.X}");
            Assert.True(result.X == 0, $"Y: {result.Y} X: {result.X}");
        }
    }
}
