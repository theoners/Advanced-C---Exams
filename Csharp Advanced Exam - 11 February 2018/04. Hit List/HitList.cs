using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    public class HitList
    {
        public static void Main()
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());
            var personsInfo = new Dictionary<string, SortedDictionary<string, string>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input== "end transmissions")
                {
                    break;
                }

                var info = input.Split(new[] {":", "=",";"}, StringSplitOptions.RemoveEmptyEntries);

                var name = info[0];
                if (!personsInfo.ContainsKey(name))
                {
                    personsInfo.Add(name, new SortedDictionary<string, string>());
                }
                for (int i = 1; i < info.Length; i+=2)
                {
                        var keyInfo = info[i];
                        if (!personsInfo[name].ContainsKey(keyInfo))
                        {
                            personsInfo[name].Add(keyInfo,"");
                        }
                        var valueInfo = info[i+1];
                        personsInfo[name][keyInfo] = valueInfo;
                }
            }

            var nameInfo = Console.ReadLine().Split()[1];
            var symbolsCounts = 0;
            Console.WriteLine($"Info on {nameInfo}:");
            foreach (var personInfo in personsInfo.Where(x=>x.Key==nameInfo))
            {
                foreach (var kvp in personInfo.Value)
                {
                    Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
                    symbolsCounts += kvp.Key.Length + kvp.Value.Length;
                }
            }

            Console.WriteLine($"Info index: {symbolsCounts}");
            if (symbolsCounts>=targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-symbolsCounts} more info.");
            }
        }
    }
}
