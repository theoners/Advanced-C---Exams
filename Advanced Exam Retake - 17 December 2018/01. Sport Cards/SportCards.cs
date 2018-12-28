namespace _01._Sport_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SportCards
    {
        public static void Main(string[] args)
        {
            var sportCards = new Dictionary<string, SortedDictionary<string, decimal>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line.Trim() == "end")
                {
                    break;
                }

                if (!line.Contains("check"))
                {
                    var input = line
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);


                    var sport = input[0];
                    var card = input[1];
                    var price = decimal.Parse(input[2]);

                    if (!sportCards.ContainsKey(sport))
                    {
                        sportCards.Add(sport, new SortedDictionary<string, decimal>());
                    }

                    if (!sportCards[sport].ContainsKey(card))
                    {
                        sportCards[sport].Add(card,price);
                    }
                    else
                    {
                        sportCards[sport][card] = price;
                    }

                    
                }
                else
                {
                    var card = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

                    if (sportCards.ContainsKey(card))
                    {
                        Console.WriteLine($"{card} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{card} is not available!");
                    }
                }
            }

            foreach (var cards in sportCards.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{cards.Key}:");

                foreach (var sports in cards.Value)
                {
                    Console.WriteLine($"  -{sports.Key} - {sports.Value:F2}");
                }
            }
        }
    }
}
