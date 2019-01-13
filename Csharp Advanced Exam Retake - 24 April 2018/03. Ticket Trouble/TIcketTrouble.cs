namespace _03._Ticket_Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class TicketTrouble
    {
        public static void Main()
        {
            var destination = Console.ReadLine();
            var input = Console.ReadLine();
            var seatPlaces = new List<string>();
            Regex regex = new Regex(@"([{\[])[^{}\[\]]*([{\[])([A-Z]+ [A-Z]+)([}\]])[^{}\[\]]*([\[{])([A-Z][0-9]{1,2})([\]}])[^{}\[\]]*([\]}])");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                bool isValid = ValidTicket(match, destination);

                if (isValid)
                {
                    seatPlaces.Add(match.Groups[6].Value);

                }

            }

            var sortedList = seatPlaces.OrderByDescending(x =>seatPlaces.Count(y => y.Substring(1) == x.Substring(1))).ToList();
            if (seatPlaces.Count==2)
            {
                Console.WriteLine($"You are traveling to {destination} on seats {seatPlaces[0]} and {seatPlaces[1]}.");
            }
            else
            {
                Console.WriteLine($"You are traveling to {destination} on seats {sortedList[0]} and {sortedList[1]}.");
            }
            
        }

        private static bool ValidTicket(Match match, string destination)
        {
            var firstBracket = match.Groups[1].Value;
            var secondBracket = match.Groups[2].Value;
            var matchDestination = match.Groups[3].Value;
            var thirdBracket = match.Groups[4].Value;
            var fourthBracket = match.Groups[5].Value;
            var fifthBracket = match.Groups[7].Value;
            var sixthBracket = match.Groups[8].Value;

            if (matchDestination!=destination)
            {
                return false;
            }

            bool firstGroupBrackets = ValidBrackets(firstBracket,sixthBracket);
            bool secondGroupBrackets = ValidBrackets(secondBracket,thirdBracket);
            bool thirdGroupBrackets = ValidBrackets(fourthBracket,fifthBracket);
            if (firstGroupBrackets&&secondGroupBrackets&&thirdGroupBrackets)
            {
                if (firstBracket!=secondBracket|| firstBracket!=fourthBracket)
                {
                    return true;
                }
                
            }

            return false;
        }

        private static bool ValidBrackets(string openBracket, string closeBracket)
        {
            if (openBracket == "{")
            {
                if (closeBracket != "}")
                {
                    return false;
                }
            }
            else
            {
                if (closeBracket != "]")
                {
                    return false;
                }
            }

            return true;
        }
    }
}
