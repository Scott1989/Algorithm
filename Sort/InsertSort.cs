using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 插入排序
    /// 每当插入元素a[i]，认为[0, i-1]有序，找到对应的插入位置，并将大于a[i]的元素后移
    /// </summary>
    public class InsertSort : ISort
    {
        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 1; i < N; i++)
            {
                IComparable current = a[i];
                
                //找到a[i]的插入位置j
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (Less(a[j], current))
                    {
                        break;
                    }
                }

                //将[j+1，i-1]的元素后移一个位置
                for (int m = i - 1; m > j; m--)
                {
                    a[m+1] = a[m];
                }

                a[j] = current;
            }
        }
    }
}
