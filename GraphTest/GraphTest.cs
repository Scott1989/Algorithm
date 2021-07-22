using NUnit.Framework;
using StdIO;
using System.Collections.Generic;

namespace GraphTest
{
    public class GraphTest
    {
        private Algorithm.GraphSpace.Graph g;

        [SetUp]
        public void Setup()
        {
            g = GraphDataParser.GetGraph("GraphData\\GraphData.txt");
          /*  g = new Algorithm.GraphSpace.Graph(13);

            g.AddEdge(0, 5);
            g.AddEdge(4, 3);
            g.AddEdge(0, 1);
            g.AddEdge(9, 12);
            g.AddEdge(6, 4);
            g.AddEdge(5, 4);
            g.AddEdge(0, 2);
            g.AddEdge(11, 12);
            g.AddEdge(9, 10);
            g.AddEdge(0, 6);
            g.AddEdge(7, 8);
            g.AddEdge(9, 11);
            g.AddEdge(5, 3);*/
        }

        [Test]
        public void HasEdgeTest()
        {
            Assert.IsTrue(g.HasEdge(0,5));
            Assert.IsTrue(g.HasEdge(4, 3));
            Assert.IsTrue(g.HasEdge(0, 1));
            Assert.IsTrue(g.HasEdge(9, 12));
            Assert.IsTrue(g.HasEdge(6, 4));
            Assert.IsTrue(g.HasEdge(5, 4));
            Assert.IsTrue(g.HasEdge(0, 2));
            Assert.IsTrue(g.HasEdge(11, 12));
            Assert.IsTrue(g.HasEdge(9, 10));
            Assert.IsTrue(g.HasEdge(0, 6));
            Assert.IsTrue(g.HasEdge(7, 8));
            Assert.IsTrue(g.HasEdge(9, 11));
            Assert.IsTrue(g.HasEdge(5, 3));

            Assert.IsFalse(g.HasEdge(1,2));
            Assert.IsFalse(g.HasEdge(2,3));
        }


        [Test]
        public void TestAdj()
        {
            List<int> result = (List<int>)g.Adj(0);
            Assert.IsTrue(result.Count == 4);

            Assert.IsTrue(result.Contains(1) == true);
            Assert.IsTrue(result.Contains(2) == true);
            Assert.IsTrue(result.Contains(5) == true);
            Assert.IsTrue(result.Contains(6) == true);


            result = (List<int>)g.Adj(9);
            Assert.IsTrue(result.Count == 3);

            Assert.IsTrue(result.Contains(10) == true);
            Assert.IsTrue(result.Contains(11) == true);
            Assert.IsTrue(result.Contains(12) == true);


            result = (List<int>)g.Adj(7);
            Assert.IsTrue(result.Count == 1);

            Assert.IsTrue(result.Contains(8) == true);

        }
    }
}