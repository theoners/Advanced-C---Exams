namespace _01.Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var leftSocks = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            var rightSocks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            var pairs = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                var currentLeftSocks = leftSocks.Pop();
                var currentRightSocks = rightSocks.Peek();

                if (currentLeftSocks==currentRightSocks)
                {
                    leftSocks.Push(currentLeftSocks+1);
                    rightSocks.Dequeue();
                }
                else if (currentLeftSocks > currentRightSocks)
                {
                    var pairValue = currentLeftSocks + currentRightSocks;
                    rightSocks.Dequeue();
                    pairs.Add(pairValue);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
