using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 图信息的统计方法
    /// </summary>
    public class GraphStatistics
    {
        /// <summary>
        /// 获取图g中节点v的度数，即和节点v相连的其他节点数量
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int Degree(Graph g, int v)
        {
            return g.adj[v].Distinct().Count();
        }

        public static int MaxDegree(Graph g)
        {
            int maxDegree = 0;

            //统计每个节点的度数，并获取最大值
            for(int i = 0; i < g.V; i++)
            {
                int curDegree = Degree(g, i);
                if (curDegree > maxDegree)
                {
                    maxDegree = curDegree;
                }
            }

            return maxDegree;
        }

        /// <summary>
        /// 计算整个图中的平度度数
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int AverageDegree(Graph g)
        {
            int maxDegree = 0;  

            for(int i = 0; i < g.V; i++)
            {
                maxDegree += Degree(g, i);
            }

            return maxDegree / g.V;
        }

        /// <summary>
        /// 获取图中存在自环的节点数量
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int NumberOfSelfLoops(Graph g)
        {
            int selfLoopCount = 0;
            for(int i = 0; i < g.V; i++)
            {
                if (g.adj[i].Contains(i))
                {
                    selfLoopCount++;
                }
            }

            return selfLoopCount;
        }
    }
}
