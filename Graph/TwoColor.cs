using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class TwoColor
    {
        //参与统计的图
        public Graph g { get; set; }

        //是否已访问的标记数组，每一个节点都有一个标记位
        private bool[] marked;

        private bool[] color;

        public bool IsTwoColorGraph { get; set; }

        public TwoColor(Graph g)
        {
            this.g = g;
            marked = new bool[g.V];
            color = new bool[g.V];
            IsTwoColorGraph = true;

            for (int i = 0; i < g.V; i++)
            {
                marked[i] = false;
                color[i] = false;
            }

            for (int i = 0; i < g.V; i++)
            {
                if (!marked[i])
                {
                    DFS(g, i);
                }
            }

        }

        /// <summary>
        /// 通过深度遍历，为每个节点进行着色，如果每个相邻节点的颜色不一样，就符合二分图的定义
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        private void DFS(Graph g, int s)
        {
            Stack<int> st = new Stack<int>();
            marked[s] = true;
            st.Push(s);

            int prevNode = -1;
            int curNode = -1;

            while (st.Count > 0)
            {
                prevNode = curNode;
                curNode = st.Pop();
                marked[curNode] = true;

                if (prevNode != -1)
                {
                     if (color[curNode] == color[prevNode])
                        {
                            IsTwoColorGraph = false;
                            return;
                        }
                }

                for (int i = g.adj[s].Count - 1; i >= 0; i--)
                {
                    int nextNode = g.adj[s][i];
                    if (marked[nextNode])
                    {
                        continue;
                    }
                    else
                    {
                        st.Push(nextNode);
                    }
                }
            }
        }
    }
}
