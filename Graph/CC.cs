using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// CC类用于统计图中的联通分量数量，及每个联通分量中的节点编号
    /// 如果从一个节点都存在一个路径到达另一个任意节点，就是连通图
    /// </summary>
    public class CC
    {
        //用来标记未联通的统计此处，最终代表联通分量数量
        public int count { get; set;  }

        //用来存放每个节点所属的联通编号
        public int[] id { get; set; }

        //参与统计的图
        public Graph g { get; set; }

        //是否已访问的标记数组，每一个节点都有一个标记位
        protected bool[] marked;

        /// <summary>
        /// 对图g中的每个节点进行深度遍历
        /// 需要深度遍历的次数，就是联通分量的值
        /// </summary>
        /// <param name="g"></param>
        public CC(Graph g)
        {
            this.g = g;
            id = new int[g.V];
            marked = new bool[g.V];

            for(int i = 0; i < g.V; i++)
            {
                id[i] = 0;
                marked[i] = false;
            }
            count = 0;

            //对每个节点进行深度遍历
            //若节点之间是联通的，DFS可以一直遍历下去，count值保持不变
            //当count值增加时，已经遍历结束一个联通分量，开始新的联通分量遍历
            for (int i = 0; i < g.V; i++)
            {
                if (!marked[i])
                {
                    count++;
                    DFS(g, i);
                }
            }
        }

        /// <summary>
        /// 返回图g中的联通分量数量值
        /// </summary>
        /// <returns></returns>
        public int GetConnCount()
        {
            return count;
        }

        /// <summary>
        /// 判断节点V和节点W之间是否联通
        /// 判断节点V和节点W是否在同一个联通分量即可
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool IsConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        /// <summary>
        /// 返回节点V所属的联通分量编号
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int GetConnId(int v)
        {
            return id[v];
        }

        /// <summary>
        /// 采用非递归的深度遍历，在图中从某个节点开始进行深度遍历
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        private void DFS(Graph g, int s)
        {
            Stack<int> st = new Stack<int>();
            st.Push(s);

            while (st.Count > 0)
            {
                int curNode = st.Pop();
                marked[curNode] = true;
                id[s] = count;
                
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
