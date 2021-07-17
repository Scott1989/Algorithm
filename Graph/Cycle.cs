using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.GraphSpace
{
    /// <summary>
    /// 针对简单无向图的环检测算法
    /// </summary>
    public class Cycle
    {
        private Graph g;

        //节点是否被访问过的标记位
        private bool[] marked;

        //环的节点序列
        private List<int> cycles;

        //每个节点访问时的上一个节点，用于路径回查
        private int[] EdgeTo { get; set; }


        /// <summary>
        /// 构造函数，传入外部的简单无向图g，进行初始化
        /// </summary>
        /// <param name="g"></param>
        public Cycle(Graph g)
        {
            this.g = g;
        }

        /// <summary>
        /// 判断图中环是否存在
        /// </summary>
        /// <returns>true存在环，false不存在环</returns>
        public bool HasCycle()
        {
            return cycles != null;
        }

        /// <summary>
        /// 对节点v进行深度遍历，同时记录v过来的上一个节点u
        /// </summary>
        /// <param name="g"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        private void DFS(Graph g, int u, int v)
        {
            marked[v] = true;
            foreach(int w in g.adj[v])
            {
                //环已存在，停止遍历
                if (HasCycle())
                {
                    return;
                }

                if (!marked[w])
                {
                    //w未被遍历过，进度深度遍历
                    EdgeTo[w] = v;
                    DFS(g, v, w);
                }else if (w != u)
                {
                    //节点w已经被访问过
                    cycles = new List<int>();
                    for (int x = v; x != w; x = EdgeTo[x])
                    {
                        cycles.Add(x);
                    }
                    cycles.Add(w);
                    cycles.Add(v);
                }
            }
        }
    }
}
