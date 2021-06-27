﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 深度优先搜索
    /// </summary>
    public class DepthFirstSearch:Search
    {
        /// <summary>
        /// 图搜索算法，在指定图g中，从节点s开始进行深度遍历
        /// </summary>
        /// <param name="g">给定图</param>
        /// <param name="s">给定节点编号</param>
        public DepthFirstSearch(Graph g, int s):base(g,s)
        {
            DFS(g, s);
        }

      
        /// <summary>
        /// 采用深度优先遍历算法，从起点探索所有可以达到的节点
        /// 如果某个节点被访问过，标记为已访问
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        private void DFS(Graph g, int s)
        {
            marked[s] = true;
           // Count++;

            for(int i = 0; i < g.adj[s].Count; i++)
            {
                int m = g.adj[s][i];
                if (!marked[m])
                {
                    //从节点s访问到了节点m
                    //所以节点m的上一个点是s
                    EdgeTo[m] = s;
                    DFS(g, m);
                }
            }
        }
    }
}
