using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Search
{
    class BinarySearch : Search
    {
        public int Find(IComparable[] a, IComparable key)
        {
            int begin = 0, end = a.Length;

            while (begin != end)
            {
                int mid = begin + (end - begin) / 2;

                if (key.CompareTo(a[mid]) == 0)  //找到和key相同的数值
                {
                    return mid;
                } else if (key.CompareTo(a[mid]) < 0)  //KEY比数组当前位置内容小
                {
                    end = mid - 1;
                } else  //KEY比数组当前内容大
                {
                    begin = begin + 1;
                }
            }

            return -1;
        }
    }
}
