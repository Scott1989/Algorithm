using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /// <summary>
    /// 针对简单无向图的环检测算法
    /// </summary>
    public class Cycle
    {
        private Graph g;

        /// <summary>
        /// 构造函数，传入外部的简单无向图g，进行初始化
        /// </summary>
        /// <param name="g"></param>
        public Cycle(Graph g)
        {
            this.g = g;
        }

        /// <summary>
        /// 判断图中环是否存在
        /// </summary>
        /// <returns>true存在环，false不存在环</returns>
        public bool IsCycleExist()
        {

            return false;
        }
    }
}
