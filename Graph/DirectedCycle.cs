using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 有向图中是否存在有向环的检测算法
    /// </summary>
    public class DirectedCycle
    {
        //给定有向图
        public DiGraph g { get; set; }

        //节点是否被访问过的标记位
        private bool[] marked;

        //图中是否存在环
        private bool isDirectedCycleExist { get; set; }

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
            EdgeTo = new int[g.V];
            cycles = new List<int>();
            isDirectedCycleExist = false;
            for (int i = 0; i < g.V; i++)
            {
                marked[i] = false;
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
            return cycles.ToList();
        }

        public bool IsCycleExist()
        {
            return isDirectedCycleExist;
        }

        /// <summary>
        /// 从节点v出发，对有向图g进行深度遍历
        /// </summary>
        /// <param name="g">给定图g</param>
        /// <param name="v">进行深度遍历的起点</param>
        private void DFS(DiGraph g, int v)
        {
            //环已经存在，不做遍历，直接返回
            if (isDirectedCycleExist)
            {
                return;
            }

            Stack<int>  s = new Stack<int>();
            s.Push(v);

            //栈中有数据，并且还未检测到环，进行深度遍历
            while(s.Count > 0 && !isDirectedCycleExist)
            {
                int cur = s.Pop();
                
                if (!marked[cur])  //节点未被遍历
                {
                    marked[cur] = true;
                    foreach(int next in g.adj[cur])
                    {

                        if (s.Contains(next))
                        {
                            //节点v->m已经访问过，在后续的遍历中再次遇到m,环存在
                            isDirectedCycleExist = true;
                        }

                        s.Push(next);
                        EdgeTo[next] = cur;

                        
                        //确认已经存在环，停止遍历
                        if (isDirectedCycleExist)
                        {
                            break;
                        }
                    }

                }
                else
                {
                    continue;
                }
            }

            //存在环，从栈顶往下找，找到和栈顶一样的元素，环节点序列就找到
            if (isDirectedCycleExist)
            {
                int top = s.Pop();
                cycles.Add(top);
                while(s.Peek() != top)
                {
                    cycles.Add(s.Pop());
                }
                cycles.Add(s.Pop()); 
            }
        }
    }
}
