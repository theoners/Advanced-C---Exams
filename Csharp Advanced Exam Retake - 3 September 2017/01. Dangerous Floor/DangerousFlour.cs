namespace _01._Dangerous_Floor
{
    using System;

    public class DangerousFlour
    {
        public static void Main()
        {
            var board = new string[8, 8];
            GetBoard(board);

            while (true)
            {
                var command = Console.ReadLine().Split('-');
                if (command?[0] == "END")
                {
                    break;
                }

                var figure = command[0][0].ToString();
                var currentPosition = command[0].Substring(1);
                var currentPositionRow = int.Parse(currentPosition[0].ToString());
                var currentPositionCol = int.Parse(currentPosition[1].ToString());
                var movePosition = command[1];
                var movePositionRow = int.Parse(movePosition[0].ToString());
                var movePositionCol = int.Parse(movePosition[1].ToString());

                var haveFigure = CheckFigure(figure, board, currentPositionRow, currentPositionCol);
                if (!haveFigure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                var isValidMove = CheckForInvalidMove(board, figure, currentPositionRow, currentPositionCol, movePositionRow, movePositionCol);
                if (!isValidMove)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                var isInSide = CheckPositionIsInside(movePositionRow, movePositionCol);
                if (!isInSide)
                {
                    Console.WriteLine("Move go out of board!");
                }
            }
        }

        private static bool CheckPositionIsInside(int movePositionRow, int movePositionCol)
        {
            return movePositionRow >= 0 && movePositionRow < 8 && movePositionCol >= 0 && movePositionCol < 8;
        }

        private static bool CheckForInvalidMove(string[,] board, string figure, int currentPositionRow, int currentPositionCol, int movePositionRow, int movePositionCol)
        {
            bool isInside = CheckPositionIsInside(movePositionRow, movePositionCol);

            if (currentPositionRow == movePositionRow && currentPositionCol == movePositionCol)
            {
                return false;
            }
            if (figure == "K")
            {
                var rowDifference = Math.Abs(currentPositionRow - movePositionRow);
                var colDifference = Math.Abs(currentPositionCol - movePositionCol);
                if (rowDifference < 2 && colDifference < 2)
                {
                    if (isInside)
                    {
                        board[currentPositionRow, currentPositionCol] = "X";
                        board[movePositionRow, movePositionCol] = "K";
                    }
                    return true;
                }
            }
            else if (figure == "R")
            {
                var rowDifference = Math.Abs(currentPositionRow - movePositionRow);
                var colDifference = Math.Abs(currentPositionCol - movePositionCol);
                if (rowDifference == 0 || colDifference == 0)
                {
                    if (isInside)
                    {
                        board[currentPositionRow, currentPositionCol] = "X";
                        board[movePositionRow, movePositionCol] = "R";
                    }

                    return true;
                }
            }
            else if (figure == "B")
            {
                var rowDifference = Math.Abs(currentPositionRow - movePositionRow);
                var colDifference = Math.Abs(currentPositionCol - movePositionCol);
                if (rowDifference == colDifference)
                {
                    if (isInside)
                    {
                        board[currentPositionRow, currentPositionCol] = "X";
                        board[movePositionRow, movePositionCol] = "B";
                    }

                    return true;
                }
            }
            else if (figure == "Q")
            {
                var rowDifference = Math.Abs(currentPositionRow - movePositionRow);
                var colDifference = Math.Abs(currentPositionCol - movePositionCol);
                if (rowDifference == colDifference || rowDifference == 0 || colDifference == 0)
                {
                    if (isInside)
                    {
                        board[currentPositionRow, currentPositionCol] = "X";
                        board[movePositionRow, movePositionCol] = "Q";
                    }

                    return true;
                }
            }
            else if (figure == "P")
            {
                var rowDifference = currentPositionRow - movePositionRow;

                if (currentPositionCol == movePositionCol && rowDifference == 1)
                {
                    if (isInside)
                    {
                        board[currentPositionRow, currentPositionCol] = "X";
                        board[movePositionRow, movePositionCol] = "P";
                    }

                    return true;
                }
            }

            return false;
        }

        private static bool CheckFigure(string figure, string[,] board, int currentPositionRow, int currentPositionCol)
        {
            if (board[currentPositionRow, currentPositionCol] == figure)
            {
                return true;
            }

            return false;
        }

        private static void GetBoard(string[,] board)
        {

            for (int rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                var line = Console.ReadLine().Split(',');
                for (int colIndex = 0; colIndex < 8; colIndex++)
                {
                    board[rowIndex, colIndex] = line[colIndex];
                }
            }
        }
    }
}
