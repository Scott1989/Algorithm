using System;

namespace StdIO
{
    public class TestItem:IComparable
    {
        private int value;

        public TestItem(int m)
        {
            value = m;
        }

        public int CompareTo(TestItem that)
        {
            return value.CompareTo(that.value);
        }

        public int CompareTo(object obj)
        {
            return value.CompareTo(((TestItem)obj).value);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
