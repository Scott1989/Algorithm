using System;
using System.Collections.Generic;

namespace Graph
{
    public class Graph
    {
        /// <summary>
        /// 图中的顶点数量
        /// </summary>
        public int V { get; set; }

        /// <summary>
        /// 图中的边数量
        /// </summary>
        public int E { get; set; }

        //用于存放边信息的邻接矩阵
        public List<int>[] adj { get; set; }

        /// <summary>
        /// 创建一个有V个节点数量的无边图
        /// </summary>
        /// <param name="V"></param>
        public Graph(int V) 
        {
            this.V = V;
            this.E = 0;

            //初始化邻接矩阵
            adj = new List<int>[V];
            for(int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        /// <summary>
        /// 向图中增加一个边，边的两头节点编号是v, w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        void AddEdge(int v, int w)
        {
            //index v对应的链表中，用于存放所有和v节点由连接关系的对端节点
            //每条边会存放两边
            adj[v].Add(w);
            adj[w].Add(v);
        }

        /// <summary>
        /// 获取节点v的所有相邻节点列表清单
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }




    }
}
