using Sort;
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
              List<int> result = RandomGeneration.GenerateInt(50);
              IComparable[] testList1 = new IComparable[result.Count];
              IComparable[] testList2 = new IComparable[result.Count];

            for (int i = 0; i < testList1.Length; i++)
               {
                   TestData test = new TestData(result[i]%50);
                   testList1[i] = test;
                   testList2[i] = test;
            }
   

         /*   IComparable[] testList = new IComparable[50];
            for (int i = 0; i < 50; i++)
            {
                TestData test = new TestData(50-i);
                testList[i] = test;
            }*/

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Show(testList1);
            bubbleSort.Sort(testList1);
            bubbleSort.Show(testList1);

            bool isSorted = bubbleSort.IsSorted(testList1);
            Console.WriteLine("BubbleSort IsSorted: " + isSorted);
            Console.ReadLine();

            QuickSort quickSort = new QuickSort();
            quickSort.Sort(testList2);
            quickSort.Show(testList2);
      //      bool isSorted = quickSort.IsSorted(testList2);
        //    Console.WriteLine("QuickSort  IsSorted: " + isSorted);
            Console.ReadLine();

        }
    }
}
