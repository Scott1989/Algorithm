using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class TestData:IComparable
    {
        private int value;

        public TestData(int m)
        {
            value = m;
        }

        public int CompareTo(TestData that)
        {
            return value.CompareTo(that.value);
        }

        public int CompareTo(object obj)
        {
            return value.CompareTo(((TestData)obj).value);
        }

        public override string ToString()
        {
            return   this.value.ToString();
        }
    }
}
