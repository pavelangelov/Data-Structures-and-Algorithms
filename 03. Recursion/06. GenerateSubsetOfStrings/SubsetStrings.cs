using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenerateSubsetOfStrings
{
    public class SubsetStrings
    {
        private ILogger logger;
        private string[] strings;
        private int k;

        public SubsetStrings(ILogger logger)
        {
            this.logger = logger;
        }

        public void GenerateSubsets(string[] words, int combinationsLength)
        {
            this.strings = new string[combinationsLength];
            this.k = combinationsLength;
            RecursiveWithoutRepetition(words, 0, 0);
        }

        private void RecursiveWithoutRepetition(string[] words, int currentIndex, int start)
        {
            if (currentIndex >= k)
            {
                this.logger.WriteLine($"({string.Join(", ", this.strings)})");
            }
            else
            {
                for (int i = start; i < words.Length; i++)
                {
                    this.strings[currentIndex] = words[i];
                    RecursiveWithoutRepetition(words, currentIndex + 1, i + 1);
                }
            }
        }
    }
}
