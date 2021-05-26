using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class HeapSort:ISort
    {
        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for(int i = 0; i < N; i++)
            {
                //将数组[0, N-1-i]调整为大顶堆
                HeapAdjust(a, 0, N-1-i);

                //最大的元素放在a[0], 将其放置到数据结尾
                Exch(a, 0, N-1-i);
            }
        }

        
        
        private void HeapAdjust(IComparable[] a, int i, int j)
        {
            //从数组序列的最后一个元素向前查找其父亲，比父亲大，就和父亲调整位置
            //调整一轮后，最大的元素一定在最前面
            for(int m = j; m >=i; m--)
            {
                int parent = (m-1)/2;
                if (Bigger(a[m], a[parent]))
                {
                    Exch(a, m, parent);
                }
            }
        }
    }
}
