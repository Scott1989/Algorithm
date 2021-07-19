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
    public class HeapSortTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HeapSortTest_10()
        {
            string filePath = "SortData\\10Int.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }

        [Test]
        public void HeapSortTest_100()
        {
            string filePath = "SortData\\100Int.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }

        [Test]
        public void HeapSortTest_1000()
        {
            string filePath = "SortData\\1000Int.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }



        [Test]
        public void HeapSortTest_1W()
        {
            string filePath = "SortData\\1WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }

        [Test]
        public void HeapSortTest_10W()
        {
            string filePath = "SortData\\10WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }

        [Test]
        public void HeapSortTest_100W()
        {
            string filePath = "SortData\\100WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }

        [Test]
        public void HeapSortTest_1000W()
        {
            string filePath = "SortData\\1000WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            HeapSort heapSort = new HeapSort();
            heapSort.Sort(items);

            Assert.IsTrue(heapSort.IsSorted(items));
        }
    }
}
