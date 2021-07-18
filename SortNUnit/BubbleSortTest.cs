using Algorithm.SortSpace;
using NUnit.Framework;
using StdIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNUnit
{
    public class BubbleSortTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BubbleSortTest_1W()
        {
            string filePath = "SortData\\1WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsSorted(items));
        }

        [Test]
        public void BubbleSortTest_10W()
        {
            string filePath = "SortData\\10WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsSorted(items));
        }

        [Test]
        public void BubbleSortTest_100W()
        {
            string filePath = "SortData\\100WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsSorted(items));
        }

        [Test]
        public void BubbleSortTest_1000W()
        {
            string filePath = "SortData\\1000WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsSorted(items));
        }

    }
}
