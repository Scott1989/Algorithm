using Algorithm.Graph;
using NUnit.Framework;
using System.Collections.Generic;

namespace GraphTest
{
    public class DiGraphTest
    {
        private DiGraph g;

        [SetUp]
        public void Setup()
        {
            //https://algs4.cs.princeton.edu/42digraph/
            //测试用的图例来自上文链接

            g = new DiGraph(13);

            g.AddEdge(4, 2);
            g.AddEdge(2, 3);
            g.AddEdge(3, 2);
            g.AddEdge(6, 0);
            g.AddEdge(0, 1);
            g.AddEdge(2, 0);
            g.AddEdge(11, 12);
            g.AddEdge(12, 9);
            g.AddEdge(9, 10);
            g.AddEdge(9, 11);
            g.AddEdge(8, 9);
            g.AddEdge(10, 12);
            g.AddEdge(11, 4);

            g.AddEdge(4, 3);
            g.AddEdge(3, 5);
            g.AddEdge(7, 8);
            g.AddEdge(8, 7);
            g.AddEdge(5, 4);
            g.AddEdge(0, 5);
            g.AddEdge(6, 4);

            g.AddEdge(6, 9);
            g.AddEdge(7, 6);
        }

        [Test]
        public void ETest()
        {
            Assert.IsTrue(g.E == 22);
        }

        [Test]
        public void AdjTest()
        {
            List<int> result = (List<int>)g.Adj(0);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(1) == true);
            Assert.IsTrue(result.Contains(5) == true);

            result = (List<int>)g.Adj(6);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Contains(0) == true);
            Assert.IsTrue(result.Contains(4) == true);
            Assert.IsTrue(result.Contains(9) == true);

            result = (List<int>)g.Adj(4);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(2) == true);
            Assert.IsTrue(result.Contains(3) == true);
        }

        [Test]
        public void ReverseTest()
        {
            DiGraph rG = g.Reverse();
            Assert.IsTrue(rG.V == 13);
            Assert.IsTrue(rG.E == 22);

            List<int> result = (List<int>)rG.Adj(0);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(2) == true);
            Assert.IsTrue(result.Contains(6) == true);

            result = (List<int>)rG.Adj(6);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result.Contains(7) == true);

            result = (List<int>)rG.Adj(4);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Contains(5) == true);
            Assert.IsTrue(result.Contains(6) == true); 
            Assert.IsTrue(result.Contains(11) == true);
        }
    }
}
