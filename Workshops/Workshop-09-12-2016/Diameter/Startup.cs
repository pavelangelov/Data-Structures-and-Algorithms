using System;
using System.Collections.Generic;

namespace Diameter
{
    class Startup
    {
        static int n = int.Parse(Console.ReadLine());
        static int root;
        static int? maxDebth;

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

            var rand = new Random();
            // Find first node with max length
            var visited = new bool[n];
            var startIndex = rand.Next(0, n);
            DFS(graph, startIndex, visited, 0);

            // Start DFS from that node to find the Diameter 
            visited = new bool[n];
            var maxLength = DFS(graph, root, visited, 0);
            Console.WriteLine(maxLength);
        }

        static int DFS(List<Tuple<int, int>>[] graph, int node, bool[] visited, int? depth)
        {
            int maxLength = 0;

            if (!visited[node])
            {
                visited[node] = true;
                foreach (var item in graph[node])
                {
                    var sibling = item.Item1;
                    var itemLength = item.Item2;

                    var nodeLength = 0;
                    if (!visited[sibling])
                    {
                        nodeLength = DFS(graph, item.Item1, visited, depth + 1) + itemLength;
                    }

                    if (maxLength < nodeLength)
                    {
                        maxLength = nodeLength;
                        if (maxDebth == null)
                        {
                            root = sibling;
                        }
                        else if (depth != null && maxDebth < depth + 1)
                        {
                            root = sibling;
                        }
                        maxDebth = depth + 1;
                    }
                }
            }

            return maxLength;
        }
    }
}
