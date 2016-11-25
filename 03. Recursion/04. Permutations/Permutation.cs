using System.Linq;

using Framework.Contracts;

namespace _04.Permutations
{
    public class Permutation
    {
        private ILogger logger;

        public Permutation(ILogger logger)
        {
            this.logger = logger;
        }

        public void PrintPermutations(int maxNumber)
        {
            var startIndex = 0;
            var startNumber = 1;
            var numbers = Enumerable.Range(0, maxNumber).Select(x => startNumber++).ToArray();

            Perm(numbers, startIndex);
        }

        private void Perm(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                Print(numbers);
            }
            else
            {
                Perm(numbers, index + 1);
                for (int i = index + 1; i < numbers.Length; i++)
                {
                    Swap(ref numbers[index], ref numbers[i]);
                    Perm(numbers, index + 1);
                    Swap(ref numbers[index], ref numbers[i]);
                }
            }
        }

        private void Print(int[] arr)
        {
            this.logger.WriteLine(string.Join(", ", arr));
        }

        private void Swap(ref int a, ref int b)
        {
            if (a == b)
            {
                return;
            }

            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
