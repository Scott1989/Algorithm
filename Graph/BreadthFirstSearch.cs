using System.Collections.Generic;
using System.Linq;

namespace Algorithm.GraphSpace
{
    /// <summary>
    /// 广度优先搜索
    /// </summary>
    public class BreadthFirstSearch:Search
    {
        /// <summary>
        /// 图搜索算法，在指定图g中，从节点s开始进行广度遍历
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        public BreadthFirstSearch(Graph g, int s):base(g,s)
        {
            BFS(g, s);
        }

        /// <summary>
        /// 图搜索算法，在指定图g中，从节点s开始进行广度遍历
        /// 每遍历一个节点，将其压栈，一层访问完毕后，通过出栈，访问下一层
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        public void BFS(Graph g, int s)
        {
            Queue<int> visitRecord = new Queue<int>();
            visitRecord.Enqueue(s);

            while(visitRecord.Count > 0)
            {
                int curNode = visitRecord.Dequeue();
                marked[curNode] = true;

                for (int m = 0; m < g.adj[curNode].Count(); m++)
                {
                    //该节点已经访问过，跳过
                    int nextNode = g.adj[curNode][m];
                    if (marked[nextNode] == true)
                    {
                        continue;
                    }else
                    {
                        visitRecord.Enqueue(nextNode);
                    }
                }
            } 
        }
    }
}
