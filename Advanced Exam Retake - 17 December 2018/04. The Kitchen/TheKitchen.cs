namespace _04._The_Kitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheKitchen
    {
       public static void Main()
       {
           var firstLine = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
           var secondLine = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
           var knifes = new Stack<int>();
           var forks = new Queue<int>();
           var sets = new List<int>();
           for (int i = 0; i < firstLine.Length; i++)
           {
               knifes.Push(firstLine[i]);
           }

           for (int i = 0; i < secondLine.Length; i++)
           {
               forks.Enqueue(secondLine[i]);
           }

           while (knifes.Count>0 && forks.Count>0)
           {
               var knife = knifes.Peek();
               var fork = forks.Peek();

               if (knife>fork)
               {
                   var set = knife + fork;
                   sets.Add(set);
                   knifes.Pop();
                   forks.Dequeue();

               }

               else if (fork>knife)
               {
                   knifes.Pop();
               }
               else if (knife==fork)
               {
                   forks.Dequeue();
                   knife = knifes.Pop() + 1;
                   knifes.Push(knife);
               }
           }

           Console.WriteLine($"The biggest set is: {sets.Max()}");
           Console.WriteLine(string.Join(" ", sets));
       }
    }
}
