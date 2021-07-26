using Algorithm.GraphSpace;
using NUnit.Framework;
using StdIO;
using System;
using System.Collections.Generic;

namespace GraphTest
{
    public class DirectedCycleTest
    {
        private DiGraph g;
        private DirectedCycle dc;

        [SetUp]
        public void Setup()
        {
            //测试用例文件 TinyDG.txt
            g = GraphDataParser.GetDiGraph("GraphData\\TinyDG.txt");
            dc = new DirectedCycle(g);
        }

        [Test]
        public void IsDirectedCycleExistTest()
        {
            //0->5->4->3->2->0
            Assert.IsTrue(dc.HasCycle() == true);

            List<int> cycle = dc.Cycle();
            if (cycle.Count > 0)
            {
                Assert.IsTrue(cycle[0] == cycle[cycle.Count - 1]);

            }
        }

    }
}
