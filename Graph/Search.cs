using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class Search
    {
        //起始节点
        private int s;

        //给定图
        private Graph g;

        /// <summary>
        /// 图搜索算法
        /// </summary>
        /// <param name="g">给定的图</param>
        /// <param name="s">给定的节点编号s</param>
        Search(Graph g, int s)
        {
            this.g = g;
            this.s = s;
        }

        /// <summary>
        /// 检查节点v，和节点s是否联通
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool marked(int v)
        {
            foreach(var index in g.adj[v])
            {
                if (index == v)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 和节点s联通的节点数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return g.adj[s].Count();
        }
    }
}
