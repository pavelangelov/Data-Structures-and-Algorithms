using System;
using System.Linq;

using Framework.Contracts;

namespace _02.CombinationsWithDuplicates
{
    public class CombinationGenerator
    {
        private ILogger logger;
        private int n;
        private int k;

        public CombinationGenerator(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.logger = logger;
        }

        public void CombinationsWithRepetitions(int n, int k)
        {
            var depth = Enumerable.Range(0, k)
                                    .Select(x => 1)
                                    .ToArray();
            this.n = n;
            this.k = k;

            RecuriveWithRepetition(depth, 0, 0);
        }

        public void CombinationsWithouthRepetitions(int n, int k)
        {
            var depth = Enumerable.Range(0, k)
                                    .Select(x => 1)
                                    .ToArray();
            this.n = n;
            this.k = k;
            RecursiveWithoutRepetition(depth, 0, 0);
        }

        private void RecuriveWithRepetition(int[] depth, int currentIndex, int start)
        {
            if (currentIndex >= k)
            {
                this.logger.WriteLine(string.Join(", ", depth));
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    depth[currentIndex] = i + 2;
                    RecuriveWithRepetition(depth, currentIndex + 1, i);
                }
            }
        }

        private void RecursiveWithoutRepetition(int[] depth, int currentIndex, int start)
        {
            if (currentIndex >= k)
            {
                this.logger.WriteLine(string.Join(", ", depth));
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    depth[currentIndex] = i + 1;
                    RecuriveWithRepetition(depth, currentIndex + 1, i);
                }
            }
        }
    }
}
