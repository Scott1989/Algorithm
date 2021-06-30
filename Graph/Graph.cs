using System;
using System.Collections.Generic;

namespace Algorithm.Graph
{
    /// <summary>
    ///  无向图定义
    /// </summary>
    public class Graph
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
        /// 创建一个有V个节点数量的无边图
        /// </summary>
        /// <param name="V"></param>
        public Graph(int V) 
        {
            this.V = V;
            this.E = 0;

            //初始化邻接表
            adj = new List<int>[V];
            for(int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        /// <summary>
        /// 向图中增加一个边，边的两头节点编号是v, w
        /// 每个边的信息保存两次
        /// </summary>
        /// <param name="v">边的节点1</param>
        /// <param name="w">边的节点2</param>
        public void AddEdge(int v, int w)
        {
            //节点V的链表中存放对端节点w信息
            adj[v].Add(w);

            //节点W的链表中存放对端节点v的信息
            adj[w].Add(v);
        }

        /// <summary>
        /// 获取节点v的所有相邻节点列表清单
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }
    }
}
