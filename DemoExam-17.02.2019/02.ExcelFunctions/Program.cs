namespace _02.ExcelFunctions
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var firstRow = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var excel = new string[n][];
            excel[0] = firstRow;

            for (int i = 1; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                excel[i] = input;
            }

            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (commands[0]=="hide")
            {
                var colName = commands[1];
                var colIndex=-1;
                for (int i = 0; i < excel[0].Length; i++)
                {
                    if (excel[0][i]== colName)
                    {
                        colIndex = i;
                    }
                }

                Console.WriteLine(string.Join(" | " , excel[0].Where(x=>x!=colName)));

                for (int i = 1; i < excel.Length; i++)
                {
                        Console.WriteLine(string.Join(" | ", excel[i].Where((x,y)=>y!=colIndex)));
                }
            }

            else if (commands[0] == "sort")
            {
                var filter = commands[1];
                var colIndex = -1;
                for (int i = 0; i < excel[0].Length; i++)
                {
                    if (excel[0][i] == filter)
                    {
                        colIndex = i;
                    }
                }

                Console.WriteLine(string.Join(" | ", excel[0]));
                foreach (var row in excel.OrderBy(x=>x[colIndex]))
                {
                    if (!row.Contains(filter))
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }

            else if (commands[0]=="filter")
            {
                var colName = commands[1];
                var filter = commands[2];
                var colIndex = -1;
                for (int i = 0; i < excel[0].Length; i++)
                {
                    if (excel[0][i] == colName)
                    {
                        colIndex = i;
                    }
                }

                Console.WriteLine(string.Join(" | ", excel[0]));
                for (int i = 0; i < excel.Length; i++)
                {
                    if (excel[i][colIndex].Contains(filter))
                    {
                        Console.WriteLine(string.Join(" | ", excel[i]));
                    }
                }
            }
        }
    }
}
