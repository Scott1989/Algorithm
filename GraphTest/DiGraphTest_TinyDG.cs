using Algorithm.GraphSpace;
using NUnit.Framework;
using StdIO;
using System.Collections.Generic;

namespace GraphTest
{
    public class DiGraphTest_TinyDG
    {
        private DiGraph g;

        [SetUp]
        public void Setup()
        {
            //测试用例文件 TinyDG.txt
            g = GraphDataParser.GetDiGraph("GraphData\\TinyDG.txt");
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
