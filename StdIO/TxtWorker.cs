using System;
using System.Collections.Generic;
using System.IO;

namespace StdIO
{
    public static class TxtWorker
    {
        /// <summary>
        /// 根据文件路径，返回文件中所有行信息列表
        /// </summary>
        /// <param name="filePath">给定的文件路径</param>
        /// <returns>行信息列表</returns>
        public static List<string> ReadAllLines(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null; 
            }

            List<string> lines = new List<string>();
            string line;

            //针对文本文件进行按行解析
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    lines.Add(line);
                }
                file.Close();
            }
            return lines;
        }


      
        /// <summary>
        /// 将字符串内容，追加到文本文件中
        /// </summary>
        /// <param name="filePath">给定的文件路径</param>
        /// <param name="line">给定的字符串信息</param>
        public static void AppendLine(string filePath, string line)
        {
            using (FileStream fs = new FileStream(filePath,  FileMode.Append, FileAccess.ReadWrite))
            {
                //文本写入
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(line);
                sw.Flush();
                sw.Close();
            }
        }




        /// <summary>
        /// 批量写入文本字符串
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        public static void AppendLines(string filePath, List<string> lines)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(fs);
                foreach(var oneLine in lines)
                {
                    sw.Write(oneLine);
                    sw.Write(Environment.NewLine);
                }

                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// 将指定路径的文件，转为TestItem格式的数组
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TestItem[] ReadWithTestItemFormat(string filePath)
        {
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);
            return items;
        }
    }
}
