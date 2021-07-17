using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdIO
{
    /// <summary>
    /// 负责不同数据之间的格式转换
    /// </summary>
    public static class DataParser
    {
        /// <summary>
        /// 将整数数组转换为字符串数组
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static List<string> IntsToStrings(List<int> ints)
        {
            List<string> strings = new List<string>();
            foreach (var data in ints)
            {
                string oneString = data.ToString();
                strings.Add(oneString);
            }
            return strings;
        }

        /// <summary>
        /// 将字符串数组转换为整数串数组
        /// </summary>
        /// <param name="ints">输入的整数字符串数组</param>
        /// <returns>整数数组</returns>
        public static List<int> StringsToInts(List<string> strings)
        {
            List<int> ints = new List<int>();
            foreach (var data in strings)
            {
                int value = int.Parse(data);
                ints.Add(value);
            }
            return ints;
        }

        public static List<TestItem> StringsToTestItems(List<string> strings)
        {
            List<TestItem> items = new List<TestItem>();
            List<int> ints = new List<int>();
            foreach (var data in strings)
            {
                int value = int.Parse(data);
                ints.Add(value);
            }

            foreach(int oneInt in ints)
            {
                TestItem item = new TestItem(oneInt);
                items.Add(item);
            }

            return items;
        }


    }
}
