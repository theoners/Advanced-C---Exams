namespace _01._Data_Transfer
{
    using System;
    using System.Text.RegularExpressions;

    public class DataTransfer
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Regex senderRegex = new Regex(@"s:(.+?);");
            Regex receiverRegex = new Regex(@"r:(.+?);");
            Regex messageRegex = new Regex(@"m--(""[A-Za-z ]+"")");

            var dataTransfer = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                bool isValidInput = senderRegex.IsMatch(input) && receiverRegex.IsMatch(input) && messageRegex.IsMatch(input);
                if (isValidInput)
                {
                    var nameRegex = new Regex(@"[A-Za-z ]");
                    var senderMatches = nameRegex.Matches(senderRegex.Match(input).Groups[1].Value);
                    var receiverMatches = nameRegex.Matches(receiverRegex.Match(input).Groups[1].Value);


                    for (int j = 0; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            dataTransfer += input[j]-48;
                        }
                    }
                    Console.Write(string.Join("", senderMatches));
                    Console.Write($" says ");
                    Console.Write(messageRegex.Match(input).Groups[1].Value+" to ");
                    Console.Write(string.Join("", receiverMatches));
                    Console.WriteLine();
                    
                }
            }
            Console.WriteLine($"Total data transferred: {dataTransfer}MB");
        }
    }
}
