using System;
using Xunit;
using UltimateTicTacToe;

namespace UltimateTicTacToe.Tests
{
    public class NumberOfPlayerSpaces
    {
        [Fact]
        public void Simple_0_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Simple_0_2()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Simple_0_3()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
                {Player.PositionState.Opponent, Player.PositionState.Opponent, Player.PositionState.Opponent},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Simple_1_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(1, result);
        }




        [Fact]
        public void Simple_2_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(2, result);
        }





        [Fact]
        public void Simple_3_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(3, result);
        }





        [Fact]
        public void Simple_4_1()
        {
            Player.Board board = new Player.Board(new Player.PositionState[,]{
                {Player.PositionState.Player, Player.PositionState.Player, Player.PositionState.Player},
                {Player.PositionState.Player, Player.PositionState.Free, Player.PositionState.Free},
                {Player.PositionState.Free, Player.PositionState.Free, Player.PositionState.Free},
            });

            var result = board.NumberOfPlayerSpaces();

            Assert.Equal(4, result);
        }
    }
}
