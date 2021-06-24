using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 深度优先搜索
    /// </summary>
    public class DepthFirstSearch
    {
        //起始节点编号
        private int s;

        //给定图
        private Graph g;

        private bool[] marked;

        private int Count { get; set; }
        
        /// <summary>
        /// 图搜索算法
        /// </summary>
        /// <param name="g">给定的图</param>
        /// <param name="s">给定的节点编号s</param>
        DepthFirstSearch(Graph g, int s)
        {
            this.Count = 0;
            this.g = g;
            this.s = s;

            for(int i = 0; i < g.V; i++)
            {
                marked[i] = false;
            }

            Dfs(g, s);
        }

        /// <summary>
        /// 从起点s,是否存在到节点v的路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            ///存在路径，再查找访问路径
            if (HasPathTo(v))
            {

            }
        }


        /// <summary>
        /// 采用深度优先遍历算法，从起点探索所有可以达到的节点
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        private void Dfs(Graph g, int s)
        {
            marked[s] = true;
            Count++;

            for(int i = 0; i < g.adj[s].Count; i++)
            {
                int m = g.adj[s][i];
                if (!marked[m])
                {
                    Dfs(g, m);
                }
            }
        }

    }
}
