using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class DiGraph
    {
        /// <summary>
        /// 顶点数量
        /// </summary>
        public int V { get; set; }

        /// <summary>
        /// 边数量
        /// </summary>
        public int E { get; set; }

        //用于存放边信息的邻接表
        //adj是一个数组，每一项对应一个链表，用于存放和某个节点相连的所有其他节点列表
        public List<int>[] adj { get; set; }

        /// <summary>
        /// 有向图构造函数，顶点数量为v
        /// 初始化顶点数、边数以及邻接表结构
        /// </summary>
        /// <param name="v"></param>
        public DiGraph(int V)
        {
            this.V = V;
            this.E = 0;
            this.adj = new List<int>[V];
        }

        /// <summary>
        /// 向图中增加一个有向边，边的起点编号是v,终点编号是 w
        /// </summary>
        /// <param name="v">边的起点</param>
        /// <param name="w">边的终点</param>
        public void AddEdge(int v, int w)
        {
            //节点V的链表中存放对端节点w信息
            adj[v].Add(w);
            this.E++;
        }

        /// <summary>
        /// 获取节点v的所有指向的节点列表清单
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        /// <summary>
        /// 创建图的反向图，即将边的方向进行逆转
        /// </summary>
        /// <returns></returns>
        public DiGraph Reverse()
        {
            DiGraph rDiGraph = new DiGraph(V);
            for(int v = 0; v < V; v++)
            {
                foreach(int w in adj[v])
                {
                    rDiGraph.AddEdge(w, v);
                }
            }

            return rDiGraph;
        }
    }
}
