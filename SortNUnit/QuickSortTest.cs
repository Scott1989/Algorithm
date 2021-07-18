using Algorithm;
using Algorithm.SortSpace;
using NUnit.Framework;
using StdIO;
using System.Collections.Generic;

namespace SortNUnit
{
    public class QuickSortTest
    {  
        [SetUp]
        public void Setup()
        {      
        }

        [Test]
        public void QuickSortTest_1W()
        {
            string filePath = "SortData\\1WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            QuickSort quickSort = new QuickSort();
            quickSort.Sort(items);

            Assert.IsTrue(quickSort.IsSorted(items));
        }

        [Test]
        public void QuickSortTest_10W()
        {
            string filePath = "SortData\\10WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            QuickSort quickSort = new QuickSort();
            quickSort.Sort(items);

            Assert.IsTrue(quickSort.IsSorted(items));
        }

        [Test]
        public void QuickSortTest_100W()
        {
            string filePath = "SortData\\100WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            QuickSort quickSort = new QuickSort();
            quickSort.Sort(items);

            Assert.IsTrue(quickSort.IsSorted(items));
        }

        [Test]
        public void QuickSortTest_1000W()
        {
            string filePath = "SortData\\1000WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            QuickSort quickSort = new QuickSort();
            quickSort.Sort(items);

            Assert.IsTrue(quickSort.IsSorted(items));
        }


    }
}