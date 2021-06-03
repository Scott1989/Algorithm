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
        }
    }
}