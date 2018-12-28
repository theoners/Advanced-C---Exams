namespace _02._Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tagram
    {
        public static void Main()
        {
            var tagram = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input.Contains(" -> "))
                {
                    var tagramElements = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    var name = tagramElements[0];
                    var tag = tagramElements[1];
                    var likes = int.Parse(tagramElements[2]);

                    if (!tagram.ContainsKey(name))
                    {
                        tagram.Add(name, new Dictionary<string, int>());
                    }
                    if (!tagram[name].ContainsKey(tag))
                    {
                        tagram[name].Add(tag, 0);
                    }

                    tagram[name][tag] += likes;
                }
                else
                {
                    var bannedUsername = input.Split()[1];

                    if (tagram.ContainsKey(bannedUsername))
                    {
                        tagram.Remove(bannedUsername);
                    }
                }
            }

            foreach (var users in tagram.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                Console.WriteLine($"{users.Key}");

                foreach (var tagsAndLikes in users.Value)
                {
                    Console.WriteLine($"- {tagsAndLikes.Key}: {tagsAndLikes.Value}");
                }
            }
        }
    }
}
