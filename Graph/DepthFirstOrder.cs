using Algorithm.GraphSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary>
    /// 采用深度遍历，对有向图进行遍历，获取遍历序列
    /// </summary>
    public class DepthFirstOrder
    {
        //节点是否被访问过的标记位
        private bool[] marked;

        //前序遍历结果保存
        private Queue<int> pre;

        private Queue<int> post;

        private Stack<int> reversePost;

        public DepthFirstOrder(DiGraph g)
        {
            //初始化保存数据遍历队列的容器
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>(); 

            marked = new bool[g.V];
            for(int i = 0; i < marked.Length; i++)
            {
                marked[i] = false;
            }

            for (int m = 0; m < g.V; m++)
            {
                if (marked[m] == false)
                {
                    DFS(g, m);
                }
            }

        }

        /// <summary>
        /// 对有向图g,从节点v开始进行深度遍历
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void DFS(DiGraph g, int v)
        {
           this.pre.Enqueue(v);

            for(int k  = 0; k < g.adj[v].Count; k++)
            {
                DFS(g, g.adj[v][k]);
            }

            post.Enqueue(v);
            reversePost.Push(v);
        }

    }
}
