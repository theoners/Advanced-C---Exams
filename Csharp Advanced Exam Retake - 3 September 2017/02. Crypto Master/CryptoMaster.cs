namespace _02._Crypto_Master
{
    using System;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var longestRun = 1;

            for (int i = 0; i < array.Length; i++)
            {

                for (int step = 1; step < array.Length; step++)
                {
                    int currentIndex = i;

                    int nextIndex = (currentIndex + step) % array.Length;
                    int currentRun = 1;

                    while (array[nextIndex] > array[currentIndex])
                    {
                        currentRun++;
                        if (currentRun > longestRun)
                        {
                            longestRun = currentRun;
                        }

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % array.Length;
                    }
                }
            }
            Console.WriteLine(longestRun);
        }
    }
}
