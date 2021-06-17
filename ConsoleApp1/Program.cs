using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // string path = Directory.GetCurrentDirectory() + "/HashesForTest/";
            //
            // string[] filePaths = Directory.GetFiles(path, "*.hash",
            //     SearchOption.TopDirectoryOnly);
            // foreach (var VARIABLE in filePaths)
            // {
            //     var h1 = await File.ReadAllBytesAsync(VARIABLE);
            //
            //     using (StreamWriter sw = new StreamWriter(path +
            //                                               "/" + VARIABLE.Split('/')[2] + " .txt"))
            //     {
            //         for (var i = 0; i < h1.Length; i++)
            //         {
            //             if (i == 0)
            //             {
            //                 await sw.WriteAsync("[" + h1[i] +",");
            //                 continue;
            //             }
            //             if(i == h1.Length-1)
            //             {
            //                 await sw.WriteAsync(h1[i] +"]");
            //                 break;
            //             }
            //             await sw.WriteAsync(h1[i] + ",");
            //         }
            //     }
            // }

            // GenerateZigzagIndexes(5);



            // var g = new Graph();
            //
            // //добавление вершин
            // g.AddVertex("0");
            // g.AddVertex("1");
            // g.AddVertex("2");
            // g.AddVertex("3");
            // g.AddVertex("4");
            // g.AddVertex("5");
            // g.AddVertex("6");
            // g.AddVertex("7");
            // g.AddVertex("8");
            //
            // //добавление ребер
            // g.AddEdge("0", "1", 3);
            // g.AddEdge("0", "2", 15);
            // g.AddEdge("0", "5", 11);
            // g.AddEdge("0", "8", 4);
            // g.AddEdge("1", "3", 5);
            // g.AddEdge("2", "3", 2);
            // g.AddEdge("2", "7", 5);
            // g.AddEdge("3", "4", 7);
            // g.AddEdge("4", "5", 12);
            // g.AddEdge("4", "6", 6);
            // g.AddEdge("5", "8", 3);
            // g.AddEdge("6", "7", 6);
            //
            // var dijkstra = new Dijkstra(g);
            // var path = dijkstra.FindShortestPath("0", "6");
            // Console.WriteLine(path);
            // Console.ReadLine();


            var prim = new Prim();

            var n = 9;
            List<Edge> MST = new List<Edge>();
            List<Edge> E = new List<Edge>()
            {
                new Edge(0, 4, 14),
                new Edge(0, 5, 20),
                
                new Edge(1, 3, 11),
                new Edge(1, 2, 3),
                new Edge(1, 6, 12),
                new Edge(1, 8, 3),
                
                new Edge(2, 5, 10),
                new Edge(2, 7, 1),
                
                new Edge(3, 5, 9),
                new Edge(3, 7, 5),
                
                new Edge(4, 6, 10),
                
                new Edge(6, 8, 7),
                
                new Edge(7, 8, 8),
            };

            prim.algorithmByPrim(n, E, MST);
        }
        
        public static List<(int, int)> GenerateZigzagIndexes(int size)
        {
            int i, j;
            int diag;
            var n = size;

            var zigzag = new List<(int, int)>();
            
            for(diag = 0; diag < 2*n; diag++)
            {
                for(j = 0; j < n; j++)
                for(i = 0; i < n; i++)
                {
                    if(diag + 1 == (i + 1) + (j + 1))
                    {
                        
                        if (diag % 2 == 1)
                        {
                            Console.WriteLine(j + " " + i);
                            zigzag.Add((j,i));
                        }
                        else
                        {
                            Console.WriteLine(i + " " + j);
                            zigzag.Add((i,j));
                        }
                    }
                }
            }

            return zigzag;
        }
    }
}