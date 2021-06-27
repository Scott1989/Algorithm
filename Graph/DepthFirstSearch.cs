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

        //是否已访问的标记数组，每一个节点都有一个标记位
        private bool[] marked;

        private int Count { get; set; }
        
        /// <summary>
        /// 图搜索算法，在指定图g中，从节点s开始进行深度遍历
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        DepthFirstSearch(Graph g, int s)
        {
            Count = 0;
            this.g = g;
            this.s = s;

            
            for(int i = 0; i < g.V; i++)
            {
                marked[i] = false;
            }

            DFS(g, s);
        }

        /// <summary>
        /// 从起点s,是否存在到节点v的路径
        /// 需要先进行DFS深度遍历，marked标记数组才有价值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        /// <summary>
        /// 检查在图g中，是否存在从s到v的路径信息
        /// 如果存在，将路径的信息以数组的形式返回
        /// 没有结果，返回NULL
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
      /*  public IEnumerable<int> PathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            ///存在路径，再查找访问路径
            if (HasPathTo(v))
            {

            }
        }*/


        /// <summary>
        /// 采用深度优先遍历算法，从起点探索所有可以达到的节点
        /// 如果某个节点被访问过，标记为已访问
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        private void DFS(Graph g, int s)
        {
            marked[s] = true;
            Count++;

            for(int i = 0; i < g.adj[s].Count; i++)
            {
                int m = g.adj[s][i];
                if (!marked[m])
                {
                    DFS(g, m);
                }
            }
        }
    }
}
