using System;
using System.Collections.Generic;

namespace Graph
{
    public abstract class Graph
    {
        /// <summary>
        /// 创建一个有V个节点数量的无边图
        /// </summary>
        /// <param name="V"></param>
        public Graph(int V) { }

        /// <summary>
        /// 返回图中的节点数量
        /// </summary>
        /// <returns></returns>
        int V();

        /// <summary>
        /// 返回图中的边的数量
        /// </summary>
        /// <returns></returns>
        int E();


        /// <summary>
        /// 向图中增加一个边，边的两头节点编号是v, w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        void AddEdge(int v, int w);

        /// <summary>
        /// 获取节点v的所有相邻节点列表清单
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        IEnumerable<int> Adj(int v); 




    }
}
