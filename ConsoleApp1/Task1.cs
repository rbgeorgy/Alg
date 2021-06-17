using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class GraphSolver
    {
        private static readonly int INF = 2000000000;

        private int n, m;
        private int[] cost;
        private (int, int)[] roads;
        private int[] distances;
        private int[][] AdjMatrix;
        private bool[] used;

        public GraphSolver(int n, int m, int[] cost, (int, int)[] roads)
        {
            this.n = n;
            this.cost = cost;
            this.roads = roads;
            this.m = m;
            
        }

        public GraphSolver()
        {
            n = int.Parse(Console.ReadLine() ?? string.Empty);

            var line = Console.ReadLine()?.Split(" ");

            cost = new int[n + 5];
            
            for (var i = 1; i <= n; i++)
            {
                cost[i] = int.Parse(line[i-1]);
            }
            
            m = int.Parse(Console.ReadLine() ?? string.Empty);
            roads = new (int, int)[n+5];
            
            
            for (var i = 1; i <= m; i++)
            {
                line = Console.ReadLine()?.Split(' ');
                roads[i] = (int.Parse(line[0]), int.Parse(line[1]));
            }
            
        }

        public void MakeBetterChoiceByEdge(int i, int j)
        {
            if (distances[i] + AdjMatrix[i][j] < distances[j])
                distances[j] = distances[i] + AdjMatrix[i][j];
        }

        public int Solve()
        {
            distances = new int[n + 5];
            used = new bool[n + 5];

            AdjMatrix = new int[n + 5][];
            for (int i = 0; i < n + 5; i++)
            {
                used[i] = false;
                distances[i] = INF;
                AdjMatrix[i] = new int[n + 5];
                for (int j = 0; j < n + 5; j++)
                {
                    AdjMatrix[i][j] = INF;
                }
            }
            
            distances[1] = 0;

            for (var i = 1; i <= m; i++)
            {
                var roadTuple = roads[i];
                AdjMatrix[roadTuple.Item1][roadTuple.Item2] = cost[roadTuple.Item1];
                AdjMatrix[roadTuple.Item2][roadTuple.Item1] = cost[roadTuple.Item2];
            }

            for (var i = 1; i < n; i++)
            {
                var min = INF;
                var w = -1;
                for (var j = 1; j <= n; j++)
                    if (!used[j] && distances[j] < min)
                    {
                        min = distances[j];
                        w = j;
                    }
                if (w < 0) break;
                for(var j = 1; j <= n; j++)
                    if (!used[j] && AdjMatrix[w][j] != -1) MakeBetterChoiceByEdge(w, j);
                used[w] = true;
            }

            if (distances[n] != INF) return distances[n];
            return -1;
        }
    }
}