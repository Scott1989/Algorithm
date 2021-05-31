using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    /// <summary>
    /// 冒泡排序
    /// 排序思想：相邻的元素两两相比，将大的元素后移，最大的元素放N-1位置，第二大元素放N-2位置，最终得到全局有序的数组
    /// </summary>
    public class BubbleSort : ISort
    {
        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for(int i = 0; i < N-1; i++)
            {
                for(int j = i+1; j < N; j++)
                {
                    //a[i] > a[j]，将两个元素进行交换，大数据后移
                    if (Bigger(a[i], a[j]))
                    {
                        Exch(a, i, j);
                    }
                }
            }
        }
    }
}
