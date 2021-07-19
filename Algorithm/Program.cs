using Algorithm.SortSpace;
using Algorithm.ST;
using StdIO;
using StdRandom;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = RandomGeneration.GenerateInt(10000);
            string filePath = "1WInt.txt";
            List<string> strResult = DataParser.IntsToStrings(result);
            TxtWorker.AppendLines(filePath, strResult);


           result = RandomGeneration.GenerateInt(100000);
            filePath = "10WInt.txt";
            strResult = DataParser.IntsToStrings(result);
            TxtWorker.AppendLines(filePath, strResult);

            result = RandomGeneration.GenerateInt(1000000);
            filePath = "100WInt.txt";
            strResult = DataParser.IntsToStrings(result);
            TxtWorker.AppendLines(filePath, strResult);

            result = RandomGeneration.GenerateInt(10000000);
            filePath = "1000WInt.txt";
            strResult = DataParser.IntsToStrings(result);
            TxtWorker.AppendLines(filePath, strResult);

            /* List<int> result = RandomGeneration.GenerateInt(100);
             IComparable[] testList_BubbleSort = new IComparable[result.Count];
             IComparable[] testList_QuickSort = new IComparable[result.Count];
             IComparable[] testList_SelectionSort = new IComparable[result.Count];
             IComparable[] testList_InsertSort = new IComparable[result.Count];
             IComparable[] testList_HeapSort = new IComparable[result.Count];
             IComparable[] testList_MergeSort = new IComparable[result.Count];
             IComparable[] testList_ShellSort = new IComparable[result.Count];


           for (int i = 0; i < testList_BubbleSort.Length; i++)
              {
                  TestData test = new TestData(result[i]%100);
                   testList_BubbleSort[i] = test;
                   testList_QuickSort[i] = test;
                   testList_SelectionSort[i] = test;
                   testList_InsertSort[i] = test;
                   testList_HeapSort[i] = test;
                   testList_MergeSort[i] = test;
                   testList_ShellSort[i] = test;
           }


        *//*   IComparable[] testList = new IComparable[50];
           for (int i = 0; i < 50; i++)
           {
               TestData test = new TestData(50-i);
               testList[i] = test;
           }*//*

           BubbleSort bubbleSort = new BubbleSort();
           Console.WriteLine("BubbleSort begin.");
           bubbleSort.Show(testList_BubbleSort);
           bubbleSort.Sort(testList_BubbleSort);
           bubbleSort.Show(testList_BubbleSort);
           Console.WriteLine("BubbleSort end.");

           QuickSort quickSort = new QuickSort();
           Console.WriteLine("QuickSort begin.");
           quickSort.Sort(testList_QuickSort);
           quickSort.Show(testList_QuickSort);
           Console.WriteLine("QuickSort end.");

           SelectionSort selectSort = new SelectionSort();
           Console.WriteLine("SelectionSort begin.");
           selectSort.Sort(testList_SelectionSort);
           selectSort.Show(testList_SelectionSort);
           Console.WriteLine("SelectionSort end.");



           InsertSort insertSort = new InsertSort();
           Console.WriteLine("InsertSort begin.");
           insertSort.Sort(testList_InsertSort);
           insertSort.Show(testList_InsertSort);
           Console.WriteLine("InsertSort end.");


           HeapSort heapSort = new HeapSort();
           Console.WriteLine("HeapSort begin.");
           heapSort.Sort(testList_InsertSort);
           heapSort.Show(testList_InsertSort);
           Console.WriteLine("HeapSort end.");


           MergeSort mergeSort = new MergeSort();
           Console.WriteLine("MergeSort begin.");
           mergeSort.Sort(testList_MergeSort);
           mergeSort.Show(testList_MergeSort);
           Console.WriteLine("MergeSort end.");

           ShellSort shellSort = new ShellSort();
           Console.WriteLine("ShellSort begin.");
           mergeSort.Sort(testList_MergeSort);
           mergeSort.Show(testList_MergeSort);
           Console.WriteLine("ShellSort end.");

           Console.ReadLine();


           //       SequentialSearchST<int, string> seqST = new  SequentialSearchST<int, string>();
           BST<int, int> bst = new BST<int, int>();

           bst.Put(10, 10);
           bst.Put(9, 9);
           bst.Put(7, 7);
           bst.Put(8, 8);
           bst.Put(11, 11);
           bst.Put(13, 13);
           bst.Put(12, 12);


           bst.DeleteMax();
           bst.DeleteMax();
           bst.DeleteMax();
           bst.DeleteMax();
           bst.DeleteMax();
           bst.DeleteMax();
           bst.DeleteMax();
*/

            Console.ReadLine();

        }
    }
}
