using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern
{
    class PatternDrawer
    {
        private string figure = "urd";

        public string GetFigure(int interations)
        {
            GetNextFigure(interations - 1);

            return this.figure;
        }

        public void GetNextFigure(int interations)
        {
            if (interations == 0)
            {
                return;
            }

            var next = new StringBuilder();

            // append figure turned right
            for (int i = figure.Length - 1; i >= 0 ; i--)
            {
                var letter = figure[i];
                next.Append(ReverseRight(letter.ToString()));
            }

            // turn up
            next.Append("u");

            // append new figure
            next.Append(this.figure);

            // turn right
            next.Append("r");

            // append new figure
            next.Append(this.figure);

            // turn down
            next.Append("d");

            // append figure turned left
            for (int i = figure.Length - 1; i >= 0; i--)
            {
                var letter = figure[i];
                next.Append(ReverseLeft(letter.ToString()));
            }

            figure = next.ToString();

            GetNextFigure(interations - 1);
        }

        private string ReverseRight(string letter)
        {
            switch (letter)
            {
                case "u":
                    return "l";
                case "r":
                    return "u";
                case "d":
                    return "r";
                case "l":
                    return "d";
                default:
                    throw new ArgumentException("letter");
            }
        }

        private string ReverseLeft(string letter)
        {
            switch (letter)
            {
                case "u":
                    return "r";
                case "r":
                    return "d";
                case "d":
                    return "l";
                case "l":
                    return "u";
                default:
                    throw new ArgumentException("letter");
            }
        }
    }
}
