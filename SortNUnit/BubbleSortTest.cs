using Algorithm.Sort;
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
        public void BubbleSortTest_10()
        {
            //读取10个数据项测试用例的原始数据
            string filePath = "SortData\\10Int.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);
            Assert.IsTrue(items != null && items.Count() > 0);


            //读取已排序的10个数据项测试用例原始数据
            string sortedFilePath = "SortData\\10IntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);
            Assert.IsTrue(sortedItems != null && sortedItems.Count() > 0);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

        [Test]
        public void BubbleSortTest_100()
        {
            string filePath = "SortData\\100Int.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);
            Assert.IsTrue(items != null && items.Count() > 0);

            string sortedFilePath = "SortData\\100IntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);
            Assert.IsTrue(sortedItems != null && sortedItems.Count() > 0);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

        [Test]
        public void BubbleSortTest_1000()
        {
            string filePath = "SortData\\1000Int.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);
            Assert.IsTrue(items != null && items.Count() > 0);

            string sortedFilePath = "SortData\\1000IntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);
            Assert.IsTrue(sortedItems != null && sortedItems.Count() > 0);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));

        }


        [Test]
        public void BubbleSortTest_1W()
        {
            string filePath = "SortData\\1WInt.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);
            Assert.IsTrue(items != null && items.Count() > 0);

            string sortedFilePath = "SortData\\1WIntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);
            Assert.IsTrue(sortedItems != null && sortedItems.Count() > 0);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

        [Test]
        public void BubbleSortTest_10W()
        {
            string filePath = "SortData\\10WInt.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);
            Assert.IsTrue(items != null && items.Count() > 0);

            string sortedFilePath = "SortData\\10WIntSorted.txt";
            TestItem[] sortedItems = SortDataParser.GetTestItems(sortedFilePath);
            Assert.IsTrue(sortedItems != null && sortedItems.Count() > 0);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
            Assert.IsTrue(SortDataParser.IsTestItemsSame(sortedItems, items));
        }

     /*   [Test]
        public void BubbleSortTest_100W()
        {
            string filePath = "SortData\\100WInt.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
        }

        [Test]
        public void BubbleSortTest_1000W()
        {
            string filePath = "SortData\\1000WInt.txt";
            TestItem[] items = SortDataParser.GetTestItems(filePath);

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(items);

            Assert.IsTrue(bubbleSort.IsAscSorted(items));
        }*/
    }
}
