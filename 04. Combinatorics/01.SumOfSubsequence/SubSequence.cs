using System.Linq;

using Framework.Contracts;

namespace _01.SumOfSubsequence
{
    public class SubSequence
    {
        private ILogger logger;
        private long sum = 0;
        private int k;
        private int[] subsequence;

        public SubSequence(ILogger logger)
        {
            this.logger = logger;
        }

        public void Calculate(IReader reader)
        {
            var tests = int.Parse(reader.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                var values = reader.ReadLine()
                                    .Split(' ')
                                    .Select(x => int.Parse(x))
                                    .ToArray();
                this.k = values[0] - values[1];
                this.subsequence = new int[k];
                var numbers = reader.ReadLine()
                                    .Split(' ')
                                    .Select(x => int.Parse(x))
                                    .ToArray();

                CalculateSubsequence(numbers, 0, 0);
                this.logger.WriteLine(this.sum.ToString());
                this.sum = 0;
            }
        }


        private void CalculateSubsequence(int[] numbers, int currentIndex, int start)
        {
            if (currentIndex >= k)
            {
                foreach (var value in subsequence)
                {
                    sum += value;
                }
            }
            else
            {
                for (int i = start; i < numbers.Length; i++)
                {
                    subsequence[currentIndex] = numbers[i];
                    CalculateSubsequence(numbers, currentIndex + 1, i + 1);
                }
            }
        }
    }
}
