using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 广度优先搜索
    /// </summary>
    public class BreadthFirstSearch
    {
        //起始节点编号
        private int s;

        //给定图
        private Graph g;

        //是否已访问的标记数组，每一个节点都有一个标记位
        private bool[] marked;

        private int Count { get; set; }

        /// <summary>
        /// 图搜索算法，在指定图g中，从节点s开始进行广度遍历
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        public BreadthFirstSearch(Graph g, int s)
        {
            Count = 0;
            this.g = g;
            this.s = s;

            for (int i = 0; i < g.V; i++)
            {
                marked[i] = false;
            }

            BFS(g, s);
        }

        /// <summary>
        /// 从起点s,是否存在到节点v的路径
        /// 需要先进行遍历，marked标记数组才有价值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        /// <summary>
        /// 图搜索算法，在指定图g中，从节点s开始进行广度遍历
        /// 每遍历一个节点，将其压栈，一层访问完毕后，通过出栈，访问下一层
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        public void BFS(Graph g, int s)
        {
            Stack<int> visitRecord = new Stack<int>();

            visitRecord.Push(s);
            marked[s] = true;
            while(visitRecord.Count > 0)
            {
                int curNode = visitRecord.Pop();
                for(int m = 0; m < g.adj[curNode].Count(); m++)
                {
                    //该节点已经访问过，跳过
                    int connectedNode = g.adj[curNode][m];
                    if (marked[connectedNode] == true)
                    {
                        continue;
                    }

                    //访问节点，并跳过
                    marked[connectedNode] = true;
                    visitRecord.Push(connectedNode);
                }
            }
        }

    }
}
