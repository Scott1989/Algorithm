using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdIO
{
    /// <summary>
    /// 排序用数据格式转换器
    /// 将从文本文件中读取的字符串，转换为TestItem数组
    /// </summary>
    public static class SortDataParser
    {
        /// <summary>
        /// 将指定路径的文件，转为TestItem格式的数组
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TestItem[] GetTestItems(string filePath)
        {
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = SortDataParser.StringsToTestItems(strings);
            return items;
        }


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

        public static TestItem[] StringsToTestItems(List<string> strings)
        {
            if (strings == null || strings.Count == 0)
            {
                return null;
            }

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

            return items.ToArray();
        }

        /// <summary>
        /// 检测两个TestItem数组是否完全一致
        /// </summary>
        /// <param name="items1">数组1</param>
        /// <param name="items2">数组2</param>
        /// <returns></returns>
        public static bool IsTestItemsSame(TestItem[] items1, TestItem[] items2)
        {
            if (items1.Length != items2.Length)
            {
                return false;
            }

            for(int i = 0; i < items1.Length; i++)
            {
                if (items1[i].CompareTo(items2[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
