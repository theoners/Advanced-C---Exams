using System;

namespace _02.TronRacer
{
    public class Program
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new char[matrixSize, matrixSize];
            var firstPlayerPosition = new int[2];
            var secondPlayerPosition = new int[2];

            for (int i = 0; i < matrixSize; i++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = input[j];
                    switch (input[j])
                    {
                        case 'f':
                            firstPlayerPosition[0] = i;
                            firstPlayerPosition[1] = j;

                            break;
                        case 's':
                            secondPlayerPosition[0] = i;
                            secondPlayerPosition[1] = j;
                            break;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var firstPlayerCommand = command[0];
                var secondPlayerCommand = command[1];

                firstPlayerPosition = PlayerMove(matrix, firstPlayerPosition, firstPlayerCommand);
                if (matrix[firstPlayerPosition[0],firstPlayerPosition[1]]=='*')
                {
                    matrix[firstPlayerPosition[0], firstPlayerPosition[1]] = 'f';
                }
                else
                {
                    matrix[firstPlayerPosition[0], firstPlayerPosition[1]] = 'x';
                    break;
                }

                secondPlayerPosition = PlayerMove(matrix, secondPlayerPosition, secondPlayerCommand);

                if (matrix[secondPlayerPosition[0], secondPlayerPosition[1]] == '*')
                {
                    matrix[secondPlayerPosition[0], secondPlayerPosition[1]] = 's';
                }
                else
                {
                    matrix[secondPlayerPosition[0], secondPlayerPosition[1]] = 'x';
                    break;
                }

            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }

        private static int[] PlayerMove(char[,] matrix, int[] playerPosition, string command)
        {
            switch (command)
            {
                case "up":
                    playerPosition[0]--;
                    break;
                case "down":
                    playerPosition[0]++;
                    break;
                case "left":
                    playerPosition[1]--;
                    break;
                case "right":
                    playerPosition[1]++;
                    break;

            }

            if (playerPosition[0]==-1)
            {
                playerPosition[0] = matrix.GetLength(0)-1;
            }
            else if (playerPosition[0]==matrix.GetLength(0))
            {
                playerPosition[0] = 0;
            }

            if (playerPosition[1] == -1)
            {
                playerPosition[1] = matrix.GetLength(0)-1;
            }
            else if (playerPosition[1] == matrix.GetLength(0))
            {
                playerPosition[1] = 0;
            }

            return playerPosition;
        }
    }
}
