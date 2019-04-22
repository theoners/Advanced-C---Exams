using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _01.TrojanInvasion
{
   public class Program
    {
        static void Main()
        {
            var wavesCount = int.Parse(Console.ReadLine());
           
            var spartansDefense =new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var trojanWarriors= new Stack<int>();

            for (int i = 1; i <= wavesCount; i++)
            {
                if (!spartansDefense.Any())
                {
                    break;
                }
                trojanWarriors = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                if (i % 3 == 0)
                {
                    spartansDefense.Add(int.Parse(Console.ReadLine()));
                }
             
                while (trojanWarriors.Any() && spartansDefense.Any())
                {
                    var trojanSoldier = trojanWarriors.Peek();
                    var spartansDefender = spartansDefense[0];

                   

                    if (trojanSoldier>spartansDefender)
                    {
                        spartansDefense.RemoveAt(0);
                        trojanWarriors.Pop();
                        trojanWarriors.Push(trojanSoldier-spartansDefender);
                    }
                    else if (trojanSoldier < spartansDefender)
                    {
                        trojanWarriors.Pop();
                        spartansDefense[0] -= trojanSoldier;
                    }
                    else
                    {
                        trojanWarriors.Pop();
                        spartansDefense.RemoveAt(0);
                    }
                }
            }

            if (spartansDefense.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine("Plates left: "+ string.Join(", ", spartansDefense));
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine("Warriors left: "+string.Join(", ", trojanWarriors));
            }
        }
    }
}
