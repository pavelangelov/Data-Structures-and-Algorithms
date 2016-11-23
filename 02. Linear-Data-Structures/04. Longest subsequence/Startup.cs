using System.Collections.Generic;

using Utils.Models;

namespace _04.Longest_subsequence
{
    public class Startup
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();

            var numbers = new List<int>() { 1, 2, 3, 3, 2, 2, 2, 2, 4, 4, 4 };
            //var numbers = new List<int>() { 1,1,1,5,5,3,3,2,4,5,3,3,3,3};
            //var numbers = new List<int>() { 9,9,9,9,2,1,4,2,3,5,6,6,6 };

            var longestSequence = ExtractLongestSubsequence(numbers);
            logger.WriteLine(string.Join(", ", longestSequence));

        }

        public static ICollection<int> ExtractLongestSubsequence(IList<int> numbers)
        {
            var bestStartIndex = 0;
            var longestSequence = 0;
            int currentSuquence = 1;
            int currentStart = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[currentStart] == numbers[i])
                {
                    currentSuquence++;
                }
                else
                {
                    currentSuquence = 1;
                    currentStart = i;
                }

                if(currentSuquence > longestSequence)
                {
                    longestSequence = currentSuquence;
                    bestStartIndex = currentStart;
                }

            }

            var result = new List<int>();
            for (int i = 0; i < longestSequence; i++)
            {
                result.Add(numbers[bestStartIndex + i]);
            }

            return result;
        }
    }
}
