using System;
using System.Collections.Generic;

namespace Algorithm.Sort
{
    public  class ISort
    {
         public void Sort(IComparable[] a)
        { }


        /// <summary>
        /// 比较元素V,W的大小关系， V < W返回TRUE，其他返回FASLE
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 比较元素V,W的大小关系，V>W返回TRUE，其他返回FALSE
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Bigger(IComparable v, IComparable w)
        {
            return v.CompareTo(w) > 0;
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

        /// <summary>
        /// 打印处数组A所有的元素信息
        /// </summary>
        /// <param name="a"></param>
        public void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 判断数组A是否是升序排列
        /// </summary>
        /// <param name="a">数组</param>
        /// <returns></returns>
        public bool IsSorted(IComparable[] a)
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
    }
}
