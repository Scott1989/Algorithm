using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 检查有向图中是否存在有向环
    /// </summary>
    public class DirectedCycle
    {
        //给定有向图
        public DiGraph g { get; set; }

        //节点是否被访问的标记位
        private bool[] marked;

        //图g中是否存在环
        public bool IsDirectedCycleExist { get; set; }

        //环的节点序列
        private List<int> cycles;

        //每个节点访问时的上一个节点
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
            IsDirectedCycleExist = false;
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

       
        /// <summary>
        /// 从节点v对有向图g进行深度遍历
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void DFS(DiGraph g, int v)
        {
            if (IsDirectedCycleExist)
            {
                return;
            }
            Stack<int>  s = new Stack<int>();
            s.Push(v);

            while(s.Count > 0)
            {
                int cur = s.Pop();
                if (!marked[cur])
                {
                    marked[cur] = true;
                    foreach(int m in g.adj[cur])
                    {
                        s.Push(m);
                        EdgeTo[m] = cur;
                        if (s.Contains(m))
                        {
                            //节点v->m已经访问过，在后续的遍历中再次遇到m,环存在
                            IsDirectedCycleExist = true;
                            break;
                        }
                    }
                }else
                {
                    continue;
                }
            }

            //存在环，从栈顶往下找，找到和栈顶一样的元素，环节点序列就找到
            if (IsDirectedCycleExist)
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
