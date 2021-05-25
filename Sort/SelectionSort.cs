using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 选择排序，每次查找数组中的无序部分的最小者，将其放置数据有序部分的结尾处
    /// </summary>
    public class SelectionSort:ISort
    {
        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for(int i = 0; i < N; i++)
            {
                //进行无序部分最小者查找
                int minIndex = i;
                IComparable min = a[minIndex];
                for(int j = i+1; j < N; j++)
                {
                    if (Less(a[j], min))
                    {
                        minIndex = j;
                        min = a[j];
                    }
                }

                if (i != minIndex) Exch(a, i, minIndex);
            }
        }
    }
}
