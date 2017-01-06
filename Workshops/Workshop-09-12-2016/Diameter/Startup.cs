using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    class Startup
    {
        static int n = int.Parse(Console.ReadLine());

        static void Main()
        {
            var graph = new List<Tuple<int, int>>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<Tuple<int, int>>();
            }

            for (int i = 0; i < n - 1; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var firstNode = int.Parse(line[0]);
                var secondNode = int.Parse(line[1]);
                var length = int.Parse(line[2]);

                graph[firstNode].Add(new Tuple<int, int>(secondNode, length));
                graph[secondNode].Add(new Tuple<int, int>(firstNode, length));
            }
            
            // Start DFS fill max paths for ecery node 
            var lengths = new int[n];
            DFS(graph, lengths, 0, -1);
            //Console.WriteLine(string.Join(", ", lengths));
            Console.WriteLine(lengths.Max());
        }

        static int DFS(List<Tuple<int, int>>[] graph, int[] lengths, int currentNode, int previusNode)
        {
            int maxLength = 0;
            int secondMaxLength = 0;

            foreach (var sibling in graph[currentNode])
            {
                if (sibling.Item1 == previusNode)
                {
                    continue;
                }

                var length = DFS(graph, lengths, sibling.Item1, currentNode) + sibling.Item2;

                if (maxLength < length)
                {
                    secondMaxLength = maxLength;
                    maxLength = length;
                }
                else if (secondMaxLength < length)
                {
                    secondMaxLength = length;
                }
            }

            lengths[currentNode] = maxLength + secondMaxLength;

            return maxLength;
        }
    }
}
