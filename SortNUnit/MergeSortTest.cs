﻿using Algorithm.Sort;
using NUnit.Framework;
using StdIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNUnit
{
    public class MergeSortTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MergeSortTest_10()
        {
            string filePath = "SortData\\10Int.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            string sortedFilePath = "SortData\\10IntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

        [Test]
        public void MergeSortTest_100()
        {
            string filePath = "SortData\\100Int.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            string sortedFilePath = "SortData\\100IntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

        [Test]
        public void MergeSortTest_1000()
        {
            string filePath = "SortData\\1000Int.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            string sortedFilePath = "SortData\\1000IntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }



        [Test]
        public void MergeSortTest_1W()
        {
            string filePath = "SortData\\1WInt.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            string sortedFilePath = "SortData\\1WIntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

        [Test]
        public void MergeSortTest_10W()
        {
            string filePath = "SortData\\10WInt.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            string sortedFilePath = "SortData\\10WIntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

      /*  [Test]
        public void MergeSortTest_100W()
        {
            string filePath = "SortData\\100WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
        }

        [Test]
        public void MergeSortTest_1000W()
        {
            string filePath = "SortData\\1000WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            TestItem[] items = DataParser.StringsToTestItems(strings);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(items);

            Assert.IsTrue(mergeSort.IsAscSorted(items));
        }*/
    }
}
