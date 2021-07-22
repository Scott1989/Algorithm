using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdIO
{
    /// <summary>
    /// 将从文本中读取的字符串数据，转换位Graph数据结构
    /// </summary>
    public static class GraphDataParser
    {
        /// <summary>
        /// 从指定路径的文件中读取图信息，格式为：
        /// 10    顶点数量
        /// 1,  5  边信息 以边的两个顶点信息描述
        /// 2,  7
        /// ....
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Algorithm.GraphSpace.Graph GetGraph(string filePath)
        {
            List<string> lines = TxtWorker.ReadAllLines(filePath);  
            lines = lines.Where(line =>(string.IsNullOrEmpty(line)) == false).ToList();

            int V = int.Parse(lines[0]);
            Algorithm.GraphSpace.Graph g = new Algorithm.GraphSpace.Graph(V);

            for(int i = 1; i < lines.Count; i++)
            {
                string line = lines[i];
                string[] peers = line.Split(",");
                peers = peers.Where(peer => string.IsNullOrEmpty(peer) == false).ToArray();
                int begin = int.Parse(peers[0]);
                int end = int.Parse(peers[1]);

                g.AddEdge(begin, end);
            }

            return g;
        }
    }
}
