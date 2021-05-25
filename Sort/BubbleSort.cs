using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 冒泡排序
    /// 相邻的元素两两相比，将大的元素后移，最大的元素放N-1位置，第二大元素放N-2位置
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
                    //a[i] > a[j]，将两个元素进行交换
                    if (Bigger(a[i], a[j]))
                    {
                        Exch(a, i, j);
                    }
                }
            }
        }
    }
}
