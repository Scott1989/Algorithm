using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    ///  图搜索算法
    ///  基于给定图和节点，实现图搜索功能
    /// </summary>
    public abstract class Search
    {
        //源节点编号
        public int s { get; set;}

        //给定图
        public Graph g { get; set; }

        //是否已访问的标记数组，每一个节点都有一个标记位
        protected bool[] marked;

        //每个节点访问时的上一个节点
        protected int[] EdgeTo { get; set; }


        /// <summary>
        /// 图搜索算法
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        public Search(Graph g, int s)
        {
            this.g = g;
            this.s = s;

            marked = new bool[g.V];
            EdgeTo = new int[g.V];

            for (int i = 0; i < g.V; i++)
            {
                marked[i] = false;
                EdgeTo[i] = -1;
            }
        }

        /// <summary>
        /// 检查节点v，和节点s是否联通
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool IsConnected(int v)
        {
            //如果节点V被遍历，证明节点s可以到达节点v
            if (marked[v])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 和节点s具有联通关系的节点数量
        /// </summary>
        /// <returns></returns>
        public int GetConnCount()
        {
            //marked数组中true的数量，就是和节点s具有联通关系的节点数量
            return marked.Select(m => m == true).Count();
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
        public IEnumerable<int> PathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            ///存在路径，再查找访问路径
            if (HasPathTo(v))
            {
                int m = v;
                path.Push(m);

                while (m != s)
                {
                    int preNode = EdgeTo[m];
                    path.Push(preNode);
                    m = preNode;
                }
                path.Push(s);
                return path.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
