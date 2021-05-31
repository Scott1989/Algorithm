using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    /// <summary>
    /// 合并排序
    /// 排序思想：合并排序采用分治方法，对数组左半边使用合并排序，对数据右边使用合并排序，两边都有序后再合并成新的大有序数组
    /// </summary>
    public class MergeSort : ISort
    {
        public void Sort(IComparable[] a)
        {
           int N = a.Length;
           Sort(a, 0, N-1);
        }


        /// <summary>
        /// 采用递归的方式，将数据对半切分进行同类排序，最后将其合并为大的有序数组
        /// </summary>
        private void Sort(IComparable[] a, int begin, int end)
        {
            if (begin == end) return;

            int mid = begin + (end - begin) / 2;
            Sort(a, begin, mid);
            Sort(a, mid+1, end);
            Merge(a, begin, mid, end);
        }


        /// <summary>
        /// [i, j] [j+1, k]的数据进行有序合并
        /// </summary>
        private void Merge(IComparable[] a, int i, int j, int k)
        {
            if (j == k) return;
            
            IComparable[] b = new IComparable[k-i+1];

            int leftIndex = i;
            int rightIndex = j + 1;
          

            int tmpIndex = 0;

            //从左右有序数组中依次挑小的放临时数组
            while(leftIndex <= j && rightIndex <= k)
            {
                if (Less(a[leftIndex], a[rightIndex]))
                {
                    b[tmpIndex] = a[leftIndex];
                    tmpIndex++;
                    leftIndex++;
                }else
                {
                    b[tmpIndex] = a[rightIndex];
                    tmpIndex++;
                    rightIndex++;
                }
            }

            //左边序列还有剩余，补充到临时缓冲区中
            if (leftIndex <= j)
            {
                for(int m = leftIndex; m <= j; m++)
                {
                    b[tmpIndex] = a[m];
                    tmpIndex++;
                }
            }

            //右边序列还有剩余，补充到临时缓冲区中
            if (rightIndex <= k)
            {
                for(int m = rightIndex; m <= k; m++)
                {
                    b[tmpIndex] = a[m];
                    tmpIndex++;
                }
            }

            //将临时缓冲区中排好序的数据更新到数组中
            for(int m = i; m <= k; m++)
            {
                a[m] = b[m-i];
            }
        }
    }
}
