using Algorithm.SortSpace;
using NUnit.Framework;
using StdIO;
using System;
using System.Collections.Generic;

namespace SortNUnit
{
    public class MergeSortTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MergeSortTest_1W()
        {
            string filePath = "SortData\\1WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsSorted(items));
        }

        [Test]
        public void MergeSortTest_10W()
        {
            string filePath = "SortData\\10WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsSorted(items));
        }

        [Test]
        public void MergeSortTest_100W()
        {
            string filePath = "SortData\\100WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsSorted(items));
        }

        [Test]
        public void MergeSortTest_1000W()
        {
            string filePath = "SortData\\1000WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsSorted(items));
        }
    }
}
