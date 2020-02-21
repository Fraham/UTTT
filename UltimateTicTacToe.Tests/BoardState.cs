using System;
using Xunit;
using UltimateTicTacToe;

namespace UltimateTicTacToe.Tests
{
    public class BoardState
    {
        [Fact]
        public void Simple_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.NotComplete, result);
        }

        [Fact]
        public void Simple_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }

        [Fact]
        public void Simple_3()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Vertical_1_1_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Vertical_1_1_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }

        [Fact]
        public void Vertical_1_2_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Vertical_1_2_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }

        [Fact]
        public void Vertical_1_3_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Vertical_1_3_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Player},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }






        [Fact]
        public void Horizontal_1_1_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Horizontal_1_1_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }

        [Fact]
        public void Horizontal_1_2_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Horizontal_1_2_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }

        [Fact]
        public void Horizontal_1_3_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Horizontal_1_3_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }







        [Fact]
        public void Diagonal_1_1_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Opponent},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Diagonal_1_1_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Player},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }

        [Fact]
        public void Diagonal_1_2_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Opponent},
                {Player.PositionState.Free, Player.PositionState.Opponent, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Opponent, result);
        }

        [Fact]
        public void Diagonal_1_2_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
            }, null);

            var result = board.GetBoardState();

            Assert.Equal(Player.BoardState.Player, result);
        }
    }
}
