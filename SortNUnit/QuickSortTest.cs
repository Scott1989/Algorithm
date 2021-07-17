using Algorithm;
using Algorithm.SortSpace;
using NUnit.Framework;
using StdIO;
using System.Collections.Generic;

namespace SortNUnit
{
    public class QuickSortTest
    {
        private List<TestItem> items;

        [SetUp]
        public void Setup()
        {
            string filePath = "SortData\\1WInt.txt";
            List<string> strings = TxtWorker.ReadAllLines(filePath);
            items = DataParser.StringsToTestItems(strings);
        }

        [Test]
        public void SortTest()
        {
            QuickSort quickSort = new QuickSort();
            quickSort.Sort(items.ToArray());

            Assert.IsTrue(quickSort.IsSorted(items.ToArray()));
        }
    }
}