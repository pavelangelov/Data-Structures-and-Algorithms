using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.VariationsGenerator
{
    public class VariationGenerator
    {
        public ICollection<string> GetVariations(string[] elements, ICollection<string> results, int depth, int numberOfElements, int startElement = 0)
        {
            if (depth < 1)
            {
                return results;
            }

            var result = new List<string>();
            for (int i = 0; i < elements.Length; i++)
            {
                var variationsRes = PrintElemetnVariations(elements, result, i, numberOfElements - 1, $"({elements[startElement]}");

                results.Add(variationsRes);
            }

            return GetVariations(elements, results, depth - 1, numberOfElements, startElement + 1);
        }

        private string PrintElemetnVariations(string[] set, ICollection<string> result, int startIndex, int elementsLeft, string res)
        {
            if (elementsLeft == 0)
            {
                res += ")";
                return res;
            }

            res += $" {set[startIndex]}";

            return PrintElemetnVariations(set, result, startIndex + 1, elementsLeft - 1, res);
        }
    }
}
