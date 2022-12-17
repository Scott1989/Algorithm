using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    /// <summary>
    /// 插入排序
    /// 排序思想：每当插入元素a[i]，认为[0, i-1]有序，在其中找到a[i]的插入位置，并将大于a[i]的元素后移
    /// </summary>
    public class InsertSort : ISort
    {
        new public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 1; i < N; i++)
            {
                IComparable current = a[i];
                
                //若a[i] >= a[i-1],那么现在是有序的，无需调整
                if (!Less(a[i], a[i-1])) continue;

                //找到a[i]的插入位置j
                int j = i;
                IComparable tmp = a[i];
                while(j-1 >= 0 && Less(tmp, a[j-1]))
                {
                    a[j] = a[j-1];
                    j--;
                }

                //若j和i相等，说明没有发生数据移动
                if (j != i) a[j] = tmp;
            }
        }
    }
}
