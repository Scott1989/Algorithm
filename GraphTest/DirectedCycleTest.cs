using Algorithm.GraphSpace;
using NUnit.Framework;
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
