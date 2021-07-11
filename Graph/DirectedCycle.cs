using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 有向图中环检测算法
    /// </summary>
    public class DirectedCycle
    {
        //给定有向图
        public DiGraph g { get; set; }

        //节点是否被访问过的标记位
        private bool[] marked;

        //当前节点是否在遍历栈上的标记位
        private bool[] onStack;

        //环的节点序列
        private List<int> cycles;

        //每个节点访问时的上一个节点，用于路径回查
        private int[] EdgeTo { get; set; }

        /// <summary>
        /// 有向环检测算法的构造函数
        /// </summary>
        /// <param name="g">给定的有向图</param>
        public DirectedCycle(DiGraph g)
        {
            this.g = g;
            marked = new bool[g.V];
            onStack = new bool[g.V];
            EdgeTo = new int[g.V];
            cycles = null;
            for (int i = 0; i < g.V; i++)
            {
                marked[i] = false;
                onStack[i] = false;
                EdgeTo[i] = -1;
            }

            //对每个节点进行深度遍历，进行环的探索
            //查找到环后就结束遍历
            for(int i = 0; i < g.V; i++)
            {
                DFS(g, i);
            }
        }

        public List<int> Cycle()
        {
            return cycles?.ToList();
        }

        public bool HasCycle()
        {
            return cycles != null;
        }

        /// <summary>
        /// 从节点v出发，对有向图g进行深度遍历
        /// </summary>
        /// <param name="g">给定图g</param>
        /// <param name="v">进行深度遍历的起点</param>
        private void DFS(DiGraph g, int v)
        {
            //环已存在，不再做深度遍历
            if (HasCycle())
            {
                return;
            }

            onStack[v] = true;  //进栈
            marked[v] = true;   //标记已访问

            foreach(var next in g.adj[v])
            {
                if (!marked[next]) 
                {
                    //节点next未被访问过，需要对齐进行深度遍历
                    //标记v->next的路径信息
                    EdgeTo[next] = v;
                    DFS(g, next);
                }else
                {
                    //节点next已经被访问过，并且还在栈上
                    if (onStack[next])
                    {
                        cycles = new List<int>();
                        for (int x = v; x != next; x = EdgeTo[x])
                        {
                            cycles.Add(x);
                        }
                        cycles.Add(next);
                        cycles.Add(v);
                    }

                }
            }
            onStack[v] = false;
        }
    }
}
