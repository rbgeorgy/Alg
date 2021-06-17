using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Prim
    {
        public void algorithmByPrim(int numberV, List<Edge> E, List<Edge> MST)
        {
            //неиспользованные ребра
            List<Edge> notUsedE = new List<Edge>(E);
            //использованные вершины
            List<int> usedV = new List<int>();
            //неиспользованные вершины
            List<int> notUsedV = new List<int>();
            for (int i = 0; i < numberV; i++)
                notUsedV.Add(i);
            //выбираем случайную начальную вершину
            Random rand = new Random();
            var randRes = rand.Next(0, numberV);
            usedV.Add(randRes);
            notUsedV.RemoveAt(usedV[0]);
            while (notUsedV.Count > 0)
            {
                int minE = -1; //номер наименьшего ребра
                //поиск наименьшего ребра
                for (int i = 0; i < notUsedE.Count; i++)
                {
                    if ((usedV.IndexOf(notUsedE[i].v1) != -1) && (notUsedV.IndexOf(notUsedE[i].v2) != -1) ||
                        (usedV.IndexOf(notUsedE[i].v2) != -1) && (notUsedV.IndexOf(notUsedE[i].v1) != -1))
                    {
                        if (minE != -1)
                        {
                            if (notUsedE[i].weight < notUsedE[minE].weight)
                                minE = i;
                        }
                        else
                            minE = i;
                    }
                }
                //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
                if (usedV.IndexOf(notUsedE[minE].v1) != -1)
                {
                    usedV.Add(notUsedE[minE].v2);
                    notUsedV.Remove(notUsedE[minE].v2);
                }
                else
                {
                    usedV.Add(notUsedE[minE].v1);
                    notUsedV.Remove(notUsedE[minE].v1);
                }
                //заносим новое ребро в дерево и удаляем его из списка неиспользованных
                MST.Add(notUsedE[minE]);
                notUsedE.RemoveAt(minE);
            }
        }
    }
    
    public class Edge
    {
        public int v1, v2;
 
        public int weight;
 
        public Edge(int v1, int v2, int weight)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }
    }
}