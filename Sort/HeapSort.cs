using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class HeapSort:ISort
    {
        /// <summary>
        /// 堆排序
        /// 排序思想：将数组[0, N-1]构建为大顶堆，最大的元素排0位，将其和N-1位置的数据进行交换；
        /// 然后继续基于[0, N-2]构建大顶堆，第二大元素排0位，将其和N-2位置的数据进行交换，
        /// 最终得到全局有序的数组
        /// </summary>
        public void Sort(IComparable[] a)
        {
            int N = a.Length;
            for(int i = 0; i < N; i++)
            {
                //将数组[0, N-1-i]调整为大顶堆
                HeapAdjust(a, 0, N-1-i);

                //最大的元素放在a[0], 将其放置到数据结尾N-1-i处
                Exch(a, 0, N-1-i);
            }
        }


        /// <summary>
        /// 堆调整
        /// 调整思想：将数组[0, N-1]看成是一颗二叉树；下表i位置的元素，左孩子节点下标为2i+1： 右孩子节点下标为2i+2： 父节点下表为(m-1)/2，
        /// 从最后一个元素开始调整，只要孩子节点比父节点大，就和父节点调整位置，最终能将最大的元素调整到堆顶
        /// </summary>
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
