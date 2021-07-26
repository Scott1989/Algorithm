using Algorithm.GraphSpace;
using NUnit.Framework;
using StdIO;
using System.Collections.Generic;

namespace GraphTest
{
    public class DiGraphTest_MediumDG
    {
        private DiGraph g;

        [SetUp]
        public void Setup()
        {
            //测试用例文件 mediumDG.txt
            g = GraphDataParser.GetDiGraph("GraphData\\MediumDG.txt");
        }

        [Test]
        public void ETest()
        {
            Assert.IsTrue(g.E == 147);
        }

        [Test]
        public void AdjTest()
        {
            List<int> result = (List<int>)g.Adj(0);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(7) == true);
            Assert.IsTrue(result.Contains(34) == true);

            result = (List<int>)g.Adj(6);
            Assert.IsTrue(result.Count == 4);
            Assert.IsTrue(result.Contains(13) == true);
            Assert.IsTrue(result.Contains(28) == true);
            Assert.IsTrue(result.Contains(14) == false);

            result = (List<int>)g.Adj(4);
            Assert.IsTrue(result.Count ==3);
            Assert.IsTrue(result.Contains(17) == true);
            Assert.IsTrue(result.Contains(27) == true);
            Assert.IsTrue(result.Contains(18) == false);
        }

        [Test]
        public void ReverseTest()
        {
            DiGraph rG = g.Reverse();
            Assert.IsTrue(rG.V == 50);
            Assert.IsTrue(rG.E == 147);

            List<int> result = (List<int>)rG.Adj(0);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result.Contains(10) == true);
    
            result = (List<int>)rG.Adj(6);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Contains(18) == true);
            Assert.IsTrue(result.Contains(22) == true);
            Assert.IsTrue(result.Contains(32) == true);

            result = (List<int>)rG.Adj(4);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(3) == true);
            Assert.IsTrue(result.Contains(24) == true); 
        }
    }
}
