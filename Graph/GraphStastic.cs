using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 图信息统计方法
    /// </summary>
    public class GraphStatistics
    {
        /// <summary>
        /// 获取图g中节点v的度数，即和节点v相连的其他节点数量
        /// </summary>
        /// <param name="g">指定图</param>
        /// <param name="v">指定节点编号</param>
        /// <returns></returns>
        public static int Degree(Graph g, int v)
        {
            return g.adj[v].Count();
        }

        /// <summary>
        /// 获取图g中所有节点的最大度数
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int MaxDegree(Graph g)
        {
            int maxDegree = 0;

            //统计每个节点的度数，并将统计过程中的较大值进行记录，最后得到最大值
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
            //图中没有节点，返回0度
            if (g.V == 0) return 0;

            int sumDegree = 0;  
            for(int i = 0; i < g.V; i++)
            {
                sumDegree += Degree(g, i);
            }

            return sumDegree / g.V;
        }

        /// <summary>
        /// 获取图中存在自环的节点数量
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int NumberOfSelfLoops(Graph g)
        {
            int selfLoopCount = 0;
         
            //若某个节点对应的邻接表中有自身的编号，说明该节点存在自环
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
