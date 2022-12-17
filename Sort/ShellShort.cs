
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    /// <summary>
    /// 希尔排序
    /// 排序思想：根据步长，讲数据划分为几个小段数组，分别对小段数组排序，通过对步长的控制
    /// 实现数据的全局基本有序，逐步调整到全局有序
    /// </summary>
     public class ShellSort : ISort
    {
        new public void Sort(IComparable[] a)
        {
            Sort_BasedOnInsert(a);
        }

        public void Sort_BasedOnSwap(IComparable[] a)
        {
            int N = a.Length;

             //逐渐缩小步长，从数组长度的一半，缩小到1
            for(int gap = N/2; gap > 0; gap = gap/2)
            {
               //针对每个小数组，使用冒泡排序，保证每个段有序
                for(int i = 0; i <= N; i += gap)
                {
                    for(int j = i+gap; j < N; j += gap)
                    {
                        if (Less(a[i], a[j]))
                        {
                            Exch(a, i, j);
                        }
                    }
                }
            }
        }


        public void Sort_BasedOnInsert(IComparable[] a)
        {
            int N = a.Length;

            //逐渐缩小步长，从数组长度的一半，缩小到1
            for(int gap = N/2; gap > 0; gap = gap/2)
            {
                //针对每个间隔小数组，使用插入排序，保证每个段有序
                for(int i = gap; i < N; i += gap)
                {
                    //a[i] >= a[i-gap],无需调整
                    if (!Less(a[i], a[i-gap]))  continue;

                    //a[i] < a[i-gap], 非有序状态，进行排序
                    IComparable tmp = a[i];
                    int m = i;
                    while(m-gap >= 0 &&Less(tmp, a[m-gap]))
                    {
                        a[m] = a[m-gap];
                        m -= gap;
                    }

                    a[m] = tmp;
                }
            }
        }

    }
}