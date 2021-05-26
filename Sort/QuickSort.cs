using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 快速排序
    /// 选取一个中间数M，比其小的数转移致M左边，比其大的数转移致M右边
    /// 再分别对数组左、右两个分区采用该方法，递归执行
    /// </summary>
    public class QuickSort:ISort
    {
        public void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length-1);
        }

        private void Sort(IComparable[] a, int lo,  int hi)
        {
            if (hi <= lo) return;

            //取排序区间的中间部分
             int k = Partition(a, lo, hi);
        
            //对数据进行分区，比mid大的放左边，比mid大的放右边
            Sort(a, lo, k-1);
            Sort(a, k + 1, hi);
        }

        /// <summary>
        /// 将数组进行分区，根据数组的第一个数字，进行切分
        /// 将小于的数字放左边，大于的数字放右边
        /// </summary>
        /// <param name="a">数组</param>
        /// <param name="lo">数组最左边下表</param>
        /// <param name="hi">数组最右边下表</param>
        /// <returns></returns>
        private int Partition(IComparable[] a, int lo, int hi)
        {
            int begin = lo, end = hi;
            IComparable pivot = a[lo];

            while (begin < end)
            {
                //右半部查找，找到第一个小于等于pivot的数据
                while (lo < end && Bigger(a[end], pivot))
                {
                    end--;
                }

                //找到右边小于等于pivot的数值，放到左边的空位
                if (end > begin)
                {
                    a[begin] = a[end];
                }
                //左半部查找，找到第一个大于pivot的数据
                while (begin < hi && !Bigger(a[begin], pivot))
                {
                    begin++;
                }

                //找到左边大于pivot的数组，放到右边的空位
                if (end > begin)
                {
                    a[end] = a[begin];
                }
            }

            a[end] = pivot;
            return end;
        }
    }
}
