using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    /// <summary>
    /// 冒泡排序
    /// 相邻的元素两两相比，将大的元素后移，最大的元素放N-1位置，
    /// 第二大元素放N-2位置，最终得到全局有序的数组
    /// </summary>
    public class BubbleSort : ISort
    {
        new public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N - i - 1; j++)
                {
                    //a[j] > a[j+1]，将两个元素进行交换，大数据后移
                    if (Bigger(a[j], a[j + 1]))
                    {
                        Exch(a, j, j + 1);
                    }
                }
            }
        }
    }
}