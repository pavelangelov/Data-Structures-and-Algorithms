using System.Collections.Generic;

using Framework.Contracts;

namespace _02.Binomial_theorem
{
    public class Binominal
    {
        private List<string> result;
        private int startPow;
        private char first;
        private char second;

        public void Start(IReader reader, ILogger logger)
        {
            var sequence = reader.ReadLine();
            this.first = sequence[1];
            this.second = sequence[3];
            this.startPow = int.Parse(reader.ReadLine());

            this.result = new List<string>();
            this.result.Add($"({this.first}^{this.startPow})");

            ExtractPow(this.startPow, 0, this.startPow, 1);

            logger.WriteLine(string.Join("+", this.result));
        }

        private void ExtractPow(int firstPow, int secondPow, long lastProduct, long lastDevider)
        {

            if (firstPow <= 1)
            {
                this.result.Add($"({this.second}^{this.startPow})");
                return;
            }
            else
            {
                long update;
                if (this.startPow == firstPow)
                {
                    update = 1;
                }
                else
                {
                    update = this.startPow - secondPow;
                }

                var product = (lastProduct * update) / lastDevider++;
                this.result.Add($"{product}({this.first}^{firstPow - 1})({this.second}^{secondPow + 1})");
                ExtractPow(firstPow - 1, secondPow + 1, product, lastDevider);
            }
        }
    }
}
