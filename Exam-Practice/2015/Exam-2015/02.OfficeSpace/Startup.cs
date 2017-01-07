using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OfficeSpace
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var graph = new List<Tuple<int, int>>[n + 1];
            var values = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                var value = int.Parse(values[i]);
                var siblings = Console.ReadLine().Split(' ');
                graph[i + 1] = new List<Tuple<int, int>>();
                for (int j = 0; j < siblings.Length; j++)
                {
                    var node = int.Parse(siblings[j]);
                    graph[i + 1].Add(new Tuple<int, int>(node, value));
                }
            }
            var len = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                bool[] visited = new bool[n + 1];
                try
                {
                    var currentLen = DFS(graph, visited, i, 0);

                    if (len < currentLen)
                    {
                        len = currentLen;
                    }
                }
                catch (ArgumentException ex)
                {
                    len = -1;
                    break; ;
                }
            }

            Console.WriteLine(len);
        }

        static int DFS(List<Tuple<int, int>>[] graph, bool[] visited, int currentNode, int startNode)
        {
            if (currentNode == 0)
            {
                return 0;
            }

            if (!visited[currentNode])
            {
                visited[currentNode] = true;
                List<int> lengths = new List<int>();
                foreach (var node in graph[currentNode])
                {
                    lengths.Add(DFS(graph, visited, node.Item1, currentNode) + node.Item2);
                }
                int max;
                if (lengths.Count > 0)
                {
                    max = lengths.Max();
                }
                else
                {
                    max = 0;
                }
                return max;
            }

            throw new ArgumentException();
        }
    }

}
