using Algorithm.ST;
using NUnit.Framework;

namespace STNUnit
{
    public class BSTTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestPut()
        {
            BST<int, int> bst = new BST<int, int>();
            bst.Put(1, 1);
            Assert.AreEqual(bst.Rank(1), 0);

            bst.Put(2, 2);
            Assert.AreEqual(bst.Rank(2), 1);

            bst.Put(3, 3);
            Assert.AreEqual(bst.Rank(3), 2);

            bst.Put(10, 10);
            Assert.AreEqual(bst.Rank(4), 3);

            bst.Put(9, 9);
            Assert.AreEqual(bst.Rank(5), 4);

            bst.Put(7, 7);
            Assert.AreEqual(bst.Rank(6), 5);

        }

        [Test]
        public void TestSize()
        {
            BST<int, int> bst = new BST<int, int>();
            bst.Put(1, 1);
            Assert.AreEqual(bst.Size(), 1);

            bst.Put(2, 2);
            Assert.AreEqual(bst.Size(), 2);

            bst.Put(3, 3);
            Assert.AreEqual(bst.Size(), 3);

            bst.Put(10, 10);
            Assert.AreEqual(bst.Size(), 4);

            bst.Put(9, 9);
            Assert.AreEqual(bst.Size(), 5);

            bst.Put(7, 7);
            Assert.AreEqual(bst.Size(), 6);

            bst.Put(8, 8);
            Assert.AreEqual(bst.Size(), 7);

            bst.Put(11, 11);
            Assert.AreEqual(bst.Size(), 8);

            bst.Put(13, 13);
            Assert.AreEqual(bst.Size(), 9);

            bst.Put(12, 12);
            Assert.AreEqual(bst.Size(), 10);


        }

        [Test]
        public void TestDelete()
        {
            BST<int, int> bst = new BST<int, int>();
            bst.Put(1, 1);
            Assert.AreEqual(bst.Size(), 1);

            bst.Put(2, 2);
            Assert.AreEqual(bst.Size(), 2);

            bst.Put(3, 3);
            Assert.AreEqual(bst.Size(), 3);


            bst.Delete(3);
            Assert.AreEqual(bst.Contains(3), false);
            Assert.AreEqual(bst.Size(), 2);

            bst.Delete(2);
            Assert.AreEqual(bst.Contains(2), false);
            Assert.AreEqual(bst.Size(), 1);

            bst.Delete(1);
            Assert.AreEqual(bst.Contains(1), false);

            Assert.AreEqual(bst.IsEmpty(), true);




            bst.Put(10, 10);
            bst.Put(9, 9);
            bst.Put(7, 7);
            bst.Put(8, 8);
            bst.Put(11, 11);
            bst.Put(13, 13);
            bst.Put(12, 12);

            bst.Delete(11);
            Assert.AreEqual(bst.Contains(11), false);

            bst.Delete(13);
            Assert.AreEqual(bst.Contains(13), false);

            bst.Delete(10);
            Assert.AreEqual(bst.Contains(10), false);

            bst.Delete(9);
            Assert.AreEqual(bst.Contains(9), false);

            bst.Delete(7);
            Assert.AreEqual(bst.Contains(7), false);

            bst.Delete(8);
            Assert.AreEqual(bst.Contains(8), false);

            bst.Delete(12);
            Assert.AreEqual(bst.Contains(12), false);

            Assert.AreEqual(bst.IsEmpty(), true);

        }




        [Test]
        public void TestDeleteMax()
        {
            BST<int, int> bst = new BST<int, int>();
            bst.Put(1, 1);
            Assert.AreEqual(bst.Size(), 1);

            bst.Put(2, 2);
            Assert.AreEqual(bst.Size(), 2);

            bst.Put(3, 3);
            Assert.AreEqual(bst.Size(), 3);


            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(3), false);
            Assert.AreEqual(bst.Size(), 2);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(2), false);
            Assert.AreEqual(bst.Size(), 1);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(1), false);

            Assert.AreEqual(bst.IsEmpty(), true);




            bst.Put(10, 10);
            bst.Put(9, 9);
            bst.Put(7, 7);
            bst.Put(8, 8);
            bst.Put(11, 11);
            bst.Put(13, 13);
            bst.Put(12, 12);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(13), false);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(12), false);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(11), false);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(10), false);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(9), false);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(8), false);

            bst.DeleteMax();
            Assert.AreEqual(bst.Contains(7), false);

            Assert.AreEqual(bst.IsEmpty(), true);
        }





        [Test]
        public void TestDeleteMin()
        {
            BST<int, int> bst = new BST<int, int>();
         
            bst.Put(10, 10);
            bst.Put(9, 9);
            bst.Put(7, 7);
            bst.Put(8, 8);
            bst.Put(11, 11);
            bst.Put(13, 13);
            bst.Put(12, 12);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(7), false);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(8), false);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(9), false);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(10), false);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(11), false);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(12), false);

            bst.DeleteMin();
            Assert.AreEqual(bst.Contains(13), false);

        }


        [Test]
        public void TestMax()
        {
            BST<int, int> bst = new BST<int, int>();

            bst.Put(10, 10);
            bst.Put(9, 9);
            bst.Put(7, 7);
            bst.Put(8, 8);
            bst.Put(11, 11);
            bst.Put(13, 13);
            bst.Put(12, 12);

            Assert.AreEqual(bst.Max(), 13);

            bst.DeleteMax();
            Assert.AreEqual(bst.Max(), 12);

            bst.DeleteMax();
            Assert.AreEqual(bst.Max(), 11);

            bst.DeleteMax();
            Assert.AreEqual(bst.Max(), 10);

            bst.DeleteMax();
            Assert.AreEqual(bst.Max(), 9);

            bst.DeleteMax();
            Assert.AreEqual(bst.Max(), 8);

            bst.DeleteMax();
//            Assert.AreEqual(bst.IsEmpty(), true);
        }



    }
}