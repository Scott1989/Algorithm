using System;
using System.Collections.Generic;

namespace Algorithm.Sort
{
    //定义排序接口
    public class ISort
    {
        //每个排序实现类，都要实现Sort接口；
        public void Sort(IComparable[] a) { }

        /// <summary> 比较元素V,W的大小关系， V < W返回TRUE，其他返回FASLE </summary>
        /// <param name="v"></param>
        /// <param name="w"></param> 
        /// <returns></returns>
        public bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 比较元素V,W的大小关系，V&gt;W返回TRUE，其他返回FALSE
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Bigger(IComparable v, IComparable w)
        {
            return v.CompareTo(w) > 0;
        }

        /// <summary>
        /// 判断数组A是否是升序排列
        /// </summary>
        /// <param name="a">数组</param>
        /// <returns></returns>
        public bool IsAscSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 交换数组A中下表I, J元素的位置
        /// </summary>
        /// <param name="a">数组A</param>
        /// <param name="i">指定下表索引I</param>
        /// <param name="j">指定下表索引J</param>
        public void Exch(IComparable[] a, int i, int j)
        {
            if (i == j) return;

            IComparable m = a[i];
            a[i] = a[j];
            a[j] = m;
        }
    }
}