namespace _02.Helen_s_Abduction
{
    using System;
    using System.Linq;

    public class Program
    {
       public static void Main()
        {
            var parisEnergy = double.Parse(Console.ReadLine());
            var matrixSize = int.Parse(Console.ReadLine());
            var field = new char[matrixSize][];
            var isDead = false;
            GetMatrix(field);
            var parisRow = 0;
            var parisCol = 0;

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'P')
                    {
                        parisRow = i;
                        parisCol = j;
                        break;
                    }
                }
            }

            field[parisRow][parisCol] = '-';
            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();

                var command = input[0].ToLower();

                var spartansRow = int.Parse(input[1]);
                var spartansCol = int.Parse(input[2]);
                field[spartansRow][spartansCol] = 'S';

                if (parisEnergy > 0)
                {
                    switch (command)
                    {
                        case "up":
                            if (parisRow - 1 >= 0)
                            {
                                parisRow--;
                            }
                            break;
                        case "down":
                            if (parisRow + 1 < field.Length)
                            {
                                parisRow++;
                            }
                            break;
                        case "left":
                            if (parisCol - 1 >= 0)
                            {
                                parisCol--;
                            }
                            break;
                        case "right":
                            if (parisCol + 1 < field[0].Length)
                            {
                                parisCol++;
                            }
                            break;
                    }
                    parisEnergy--;
                }

                if (field[parisRow][parisCol] == 'H')
                {
                    field[parisRow][parisCol] = '-';
                    break;
                }
                if (parisEnergy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    break;
                }

                if (field[parisRow][parisCol] == 'S')
                {
                    parisEnergy =parisEnergy-2;

                    field[parisRow][parisCol] = '-';

                }

                if (parisEnergy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    break;
                }

            }

            if (parisEnergy<=0)
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }
            else
            {
                if (parisEnergy<0)
                {
                    parisEnergy = 0;
                }
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
            }

            for (int i = 0; i < matrixSize; i++)
            {
                Console.WriteLine(string.Join("",field[i]));
            }
        }

        private static void GetMatrix(char[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {

                var input = Console.ReadLine()?.ToCharArray();
                field[i]=input;
            }
        }
    }
}
