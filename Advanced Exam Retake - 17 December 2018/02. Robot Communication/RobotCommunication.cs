namespace _02._Robot_Communication
{
    using System;
    using System.Text.RegularExpressions;

    public class RobotCommunication
    {
        public static void Main()
        {
            Regex regex = new Regex(@"([,_])([^,_0-9]+)([\d])");

            while (true)
            {
                var input = Console.ReadLine();
                if (input=="Report")
                {
                    break;
                }

                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    var firstElement = match.Groups[1].Value;
                    var text = match.Groups[2].Value;
                    var number = int.Parse(match.Groups[3].Value);
                    if (firstElement==",")
                    {
                        var result = "";
                        for (int i = 0; i < text.Length; i++)
                        {
                            result += (char)(text[i] + number);
                        }

                        Console.Write(result+" ");
                    }
                    else
                    {
                        var result = "";
                        for (int i = 0; i < text.Length; i++)
                        {
                            result += (char)(text[i] - number);
                        }
                        Console.Write(result+" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
