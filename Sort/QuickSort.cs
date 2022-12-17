using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    /// <summary>
    /// 快速排序
    /// 排序思想：选取一个中间数M，比其小的数转移致M左边，比其大的数转移致M右边
    /// 再分别对数组左、右两个分区采用相同方法，递归执行
    /// </summary>
    public class QuickSort:ISort
    {
        new public void Sort(IComparable[] a)
        {
            //            Sort(a, 0, a.Length-1);
            SortNoRecursive(a, 0, a.Length - 1);
        }

        /// <summary>
        /// 采用非递归方式进行快速排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private void SortNoRecursive(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            //用栈来模拟递归调用过程
            Stack<int> s = new Stack<int>();
            s.Push(lo);
            s.Push(hi);

            
            while(s.Count() > 0)
            {
                int hiTmp = s.Pop();
                int loTmp = s.Pop();
                int kTmp = Partition_2(a, loTmp, hiTmp);

                if (loTmp < kTmp)
                {
                    s.Push(loTmp);
                    s.Push(kTmp - 1);
                }

                if (kTmp < hiTmp)
                {
                    s.Push(kTmp + 1);
                    s.Push(hiTmp);
                }
            }
        }

        private void Sort(IComparable[] a, int lo,  int hi)
        {
            if (hi <= lo) return;

            //取排序区间的中间部分
             int k = Partition_2(a, lo, hi);
        
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
            IComparable pivot = a[lo];  //将数组第一个元素作为分区的基准
            int markIndex = lo + 1;

            for(int i = markIndex; i <= hi; i++)
            {
                if (Less(a[i], pivot))
                {
                    Exch(a, i, markIndex);
                    markIndex++;
                }
            }

            markIndex--;
            Exch(a, lo, markIndex);
            return markIndex;
        }

          /// <summary>
        /// 将数组进行分区，根据数组的第一个数字，进行切分
        /// 将小于的数字放左边，大于的数字放右边
        /// </summary>
        /// <param name="a">数组</param>
        /// <param name="lo">数组最左边下表</param>
        /// <param name="hi">数组最右边下表</param>
        /// <returns></returns>
        private int Partition_2(IComparable[] a, int lo, int hi)
        {
            if (lo == hi) return lo;

            IComparable pivot = a[lo];  //将数组第一个元素作为分区的基准
            int begin = lo+1, end = hi;
        
            while (begin <= end)
            {
                //右半部查找，找到第一个小于等于pivot的数据
                while (end >= lo && Bigger(a[end], pivot))
                {
                    end--;
                }

                //左半部查找，找到第一个大于pivot的数据
                while (begin <= hi && !Bigger(a[begin], pivot))
                {
                    begin++;
                }

                //找到左边大于pivot的数组，放到右边的空位
                if (end > begin) 
                {
                    Exch(a, begin, end);
                    begin++;
                    end--;
                }
            }

            //将end指向的数据和lo位置的数据进行交换
            Exch(a, end, lo);
            return end;
        }


    }
}
