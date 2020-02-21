using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
public class Player
{
    static void Main(string[] args)
    {
        string[] inputs;

        BigBoard boards = new BigBoard();

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int opponentRow = int.Parse(inputs[0]);
            int opponentCol = int.Parse(inputs[1]);

            Board board;
            var pos = new Position { Y = opponentRow, X = opponentCol };

            if (opponentRow != -1)
            {
                Board oppBoard = boards.GetBoard(pos);

                var littlePositionOpponent = Board.BigToLittlePosition(pos);

                oppBoard.UpdateState(littlePositionOpponent, PositionState.Opponent);

                board = boards.boards[littlePositionOpponent.Y, littlePositionOpponent.X];
            }
            else
            {
                board = boards.boards[0, 0];
                pos = new Position { Y = 0, X = 0 };
                // get a random board
            }

            int validActionCount = int.Parse(Console.ReadLine());
            var validPositions = new List<Position>();

            for (int i = 0; i < validActionCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int row = int.Parse(inputs[0]);
                int col = int.Parse(inputs[1]);

                validPositions.Add(new Position { Y = row, X = col });
            }

            var playableBoards = new List<Board>();

            foreach (var checkBoard in boards.boards)
            {
                BoardState boardState = checkBoard.GetBoardState();
                checkBoard.BoardState = boardState;

                if (boardState == BoardState.NotComplete)
                {
                    playableBoards.Add(checkBoard);
                }
            }

            if (board.BoardState == BoardState.NotComplete)
            {
                var bestPosition = board.GetBestPosition();

                Console.Error.WriteLine(bestPosition.ToString());

                var opponentPosition = Board.BigToLittlePosition(pos);

                var newPositionX = (opponentPosition.X * 3) + bestPosition.X;
                var newPositionY = (opponentPosition.Y * 3) + bestPosition.Y;

                var newPosition = new Position { X = newPositionX, Y = newPositionY };

                Console.Error.WriteLine(board.ToString());

                PlayPosition(newPosition);
                //var littlePosition = Board.BigToLittlePosition(newPosition);
                board.UpdateState(bestPosition, PositionState.Player);
            }
            else
            {
                int best = 0;
                Board bestBoard = null;

                foreach (var testBoard in playableBoards)
                {
                    int playersInBoard = testBoard.NumberOfPlayerSpaces();

                    if (playersInBoard > best){
                        best = playersInBoard;
                        bestBoard = testBoard;
                    }
                }

                Console.Error.WriteLine(bestBoard.ToString());

                var bestPosition = bestBoard.GetBestPosition();

                var newPositionX = (bestBoard.Position.X * 3) + bestPosition.X;
                var newPositionY = (bestBoard.Position.Y * 3) + bestPosition.Y;

                var newPosition = new Position { X = newPositionX, Y = newPositionY };

                PlayPosition(newPosition);
                //var littlePosition = Board.BigToLittlePosition(newPosition);
                //board = boards.boards[littlePosition.Y, littlePosition.X];
                bestBoard.UpdateState(bestPosition, PositionState.Player);
            }
        }
    }

    public static void PlayPosition(Position position)
    {
        Console.WriteLine($"{position.Y} {position.X}");
    }

    public class Board
    {
        public PositionState[,] positionStates { get; }

        public BoardState BoardState { get; set; }

        public Position Position  { get; set; }

        public int NumberOfPlayerSpaces()
        {
            int counter = 0;

            foreach (var space in positionStates)
            {
                if (space == PositionState.Player)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void UpdateState(Position position, PositionState newState)
        {
            positionStates[position.Y, position.X] = newState;
        }

        public Board(Position position)
        {
            positionStates = new PositionState[,]
            {
                {PositionState.Free, PositionState.Free, PositionState.Free},
                {PositionState.Free, PositionState.Free, PositionState.Free},
                {PositionState.Free, PositionState.Free, PositionState.Free},
            };

            Position = position;
        }

        public Board(PositionState[,] state, Position position)
        {
            positionStates = (PositionState[,])(state.Clone());

            Position = position;
        }


        public static Position BigToLittlePosition(Position position)
        {
            return new Position { X = position.X % 3, Y = position.Y % 3 };
        }

        public Position GetBestPosition()
        {
            int bestValue = -100;
            Position bestPosition = null;

            var positions = GetFreePositions().ToList();

            if (positions.Count == 9)
            {
                Random rnd = new Random();
                int x = rnd.Next(3);
                int y = rnd.Next(3);
                return new Position { Y = y, X = x };
            }

            foreach (var position in positions)
            {
                Board subBoard = new Board(this.positionStates, this.Position);
                subBoard.UpdateState(position, PositionState.Player);

                var subScore = subBoard.GetScore(PlayerType.Opponent);

                if (subScore > bestValue)
                {
                    bestValue = subScore;
                    bestPosition = position;
                }
            }

            return bestPosition;
        }

        public int GetScore(PlayerType playerType)
        {
            var boardState = GetBoardState();

            if (boardState == BoardState.Draw)
            {
                return 0;
            }
            if (boardState == BoardState.Opponent)
            {
                return -10;
            }
            if (boardState == BoardState.Player)
            {
                return 10;
            }

            int bestValue = playerType == PlayerType.Player ? 100 : -100;

            foreach (var position in GetFreePositions())
            {
                Board subBoard = new Board(this.positionStates, this.Position);
                subBoard.UpdateState(position, playerType == PlayerType.Opponent ? PositionState.Opponent : PositionState.Player);

                var subScore = subBoard.GetScore(playerType == PlayerType.Opponent ? PlayerType.Player : PlayerType.Opponent);

                // if (playerType == PlayerType.Opponent && subScore < bestValue || playerType == PlayerType.Player && subScore > bestValue)
                // {
                //     bestValue = subScore;
                // }
                if (playerType == PlayerType.Player && subScore < bestValue || playerType == PlayerType.Opponent && subScore > bestValue)
                {
                    bestValue = subScore;
                }
            }

            return bestValue - 1;
        }

        public IEnumerable<Position> GetFreePositions()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (positionStates[i, j] == PositionState.Free)
                    {
                        yield return new Position { Y = i, X = j };
                    }
                }
            }
        }

        public BoardState GetBoardState()
        {
            for (int i = 0; i < 3; i++)
            {
                if (positionStates[i, 0] == positionStates[i, 1] && positionStates[i, 0] == positionStates[i, 2])
                {
                    if (positionStates[i, 0] != PositionState.Free)
                    {
                        return positionStates[i, 0] == PositionState.Opponent ? BoardState.Opponent : BoardState.Player;
                    }
                }
                if (positionStates[0, i] == positionStates[1, i] && positionStates[0, i] == positionStates[2, i])
                {
                    if (positionStates[0, i] != PositionState.Free)
                    {
                        return positionStates[0, i] == PositionState.Opponent ? BoardState.Opponent : BoardState.Player;
                    }
                }
            }

            if (positionStates[0, 0] == positionStates[1, 1] && positionStates[0, 0] == positionStates[2, 2])
            {
                if (positionStates[0, 0] != PositionState.Free)
                {
                    return positionStates[0, 0] == PositionState.Opponent ? BoardState.Opponent : BoardState.Player;
                }
            }

            if (positionStates[0, 2] == positionStates[1, 1] && positionStates[1, 1] == positionStates[2, 0])
            {
                if (positionStates[0, 2] != PositionState.Free)
                {
                    return positionStates[0, 2] == PositionState.Opponent ? BoardState.Opponent : BoardState.Player;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (positionStates[i, j] == PositionState.Free)
                    {
                        return BoardState.NotComplete;
                    }
                }
            }
            return BoardState.Draw;
        }

        public override string ToString()
        {
            return $"{positionStates[0, 0]},{positionStates[0, 1]}, {positionStates[0, 2]}\r\n{positionStates[1, 0]},{positionStates[1, 1]}, {positionStates[1, 2]}\r\n{positionStates[2, 0]},{positionStates[2, 1]}, {positionStates[2, 2]}";
        }
    }

    public class BigBoard
    {
        public Board[,] boards { get; }

        public BigBoard()
        {
            boards = new Board[,]
            {
                {new Board(new Position{ Y = 0, X = 0}), new Board(new Position{ Y = 0, X = 1}), new Board(new Position{ Y = 0, X = 2})},
                {new Board(new Position{ Y = 1, X = 0}), new Board(new Position{ Y = 1, X = 1}), new Board(new Position{ Y = 1, X = 2})},
                {new Board(new Position{ Y = 2, X = 0}), new Board(new Position{ Y = 2, X = 1}), new Board(new Position{ Y = 2, X = 2})},
            };
        }

        public BigBoard(Board[,] boards)
        {
            this.boards = boards;
        }

        public Board GetBoard(Position position)
        {
            int x = position.X / 3;
            int y = position.Y / 3;

            return boards[y, x];
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"Y: {Y}; X: {X}";
        }
    }

    public class BoardAndPosition
    {
        public int BoardId { get; set; }

        public Position Position { get; set; }
    }

    public enum PositionState
    {
        Free,
        Player,
        Opponent
    }

    public enum BoardState
    {
        NotComplete,
        Player,
        Opponent,
        Draw
    }

    public enum PlayerType
    {
        Player,
        Opponent
    }
}
