namespace _03._Crypto_Blockchain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CryptoBlockChain
    {
        public static void Main()
        {
            int lineCount = int.Parse(Console.ReadLine());
            var text = string.Empty;
            for (int i = 0; i < lineCount; i++)
            {
                text += Console.ReadLine();
            }

            var result = string.Empty;
            var regex = new Regex(@"([{[])(.*?(\d{3,}).*?)([]}])");
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                var openBracket = match.Groups[1].Value;
                var textCount = match.Length;
                var allDigits = match.Groups[3].Value;
                var closeBracket = match.Groups[4].Value;

                if (CheckBrackets(openBracket,closeBracket)&& allDigits.Length%3==0)
                {
                    var chars = new Queue<char>();
                    while (allDigits.Length!=0)
                    {
                        var digit = int.Parse(allDigits.Substring(0,3));
                        allDigits = allDigits.Substring(3,allDigits.Length-3);
                        digit -= textCount;
                        chars.Enqueue((char)digit);
                    }

                    while (chars.Any())
                    {
                        result += chars.Dequeue();
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static bool CheckBrackets(string openBracket, string closeBracket)
        {
            if (openBracket=="[" && closeBracket=="]")
            {
                return true;
            }
            else if (openBracket == "{" && closeBracket == "}")
            {
                return true;
            }

            return false;
        }
    }
}
