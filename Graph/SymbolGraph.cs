using Algorithm.ST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.GraphSpace
{
    /// <summary>
    /// 符号图，用字符串作为节点Key的图
    /// 每一个行信息中的字符串代表一行，用分号隔离
    /// </summary>
    public class SymbolGraph
    {

        private Graph g;                
        private List<string> keys;   //用于保存每一个节点的名称
        private BST<string, int> st; //用于保存节点名称及其整数索引，用节点的整数索引构建图信息

        /// <summary>
        /// 用一个字符串数组初始化符号图
        /// 每一个行信息中的字符串代表一个字符串，用分号隔离
        /// 通过每一行信息，统计节点数量、边数量以及边信息
        /// </summary>
        /// <param name="lines"></param>
        public SymbolGraph(List<string> lines)
        {
            keys = new List<string> (); 
            st = new BST<string, int>();

            int count = 0;
            foreach (var line in lines)
            {
                string point1 = line.Split(';')[0];
                string point2 = line.Split(';')[1];

                if (!st.Contains(point1))
                {
                    st.Put(point1, count);
                    keys[count] = point1;
                    count++;
                }

                if (!st.Contains(point2))
                {
                    st.Put(point2, count);
                    keys[count] = point1;
                    count++;
                }
            }

            g.V = keys.Count();
            g.E = lines.Count();

            foreach (var line in lines)
            {
                string point1 = line.Split(';')[0];
                string point2 = line.Split(';')[1];
                   
                g.AddEdge(st.Get(point1), st.Get(point2));
            }
        }

        /// <summary>
        /// 根据节点名称，获取其在图中的节点编号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int index(string name)
        {
            return st.Get(name);
        }

        /// <summary>
        /// 判断指定名称的节点是否存在于图中
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool contains(string name)
        {
            return st.Contains(name);
        }

        /// <summary>
        /// 根据指定编号，获取其对应的名称，若编号不存在，返回空
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string name(int v)
        {
            if (keys.Count <= v)
            {
                return keys[v];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
