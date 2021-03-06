using Algorithm.GraphSpace;
using NUnit.Framework;
using StdIO;
using System;
using System.Collections.Generic;

namespace GraphTest
{
    class GraphStasticTest
    {
        private Algorithm.GraphSpace.Graph g;

        [SetUp]
        public void Setup()
        {
            g = GraphDataParser.GetGraph("GraphData\\GraphData.txt");
        }

        [Test]
        public void DegreeTest()
        {
            Assert.IsTrue(GraphStatistics.Degree(g, 0) == 4);
            Assert.IsTrue(GraphStatistics.Degree(g, 1) == 1);
            Assert.IsTrue(GraphStatistics.Degree(g, 2) == 1);
            Assert.IsTrue(GraphStatistics.Degree(g, 3) == 2);
            Assert.IsTrue(GraphStatistics.Degree(g, 4) == 3);
            Assert.IsTrue(GraphStatistics.Degree(g, 5) == 3);
            Assert.IsTrue(GraphStatistics.Degree(g, 6) == 2);
            Assert.IsTrue(GraphStatistics.Degree(g, 7) == 1);
            Assert.IsTrue(GraphStatistics.Degree(g, 8) == 1);
            Assert.IsTrue(GraphStatistics.Degree(g, 9) == 3);
            Assert.IsTrue(GraphStatistics.Degree(g, 10) == 1);
            Assert.IsTrue(GraphStatistics.Degree(g, 11) == 2);
            Assert.IsTrue(GraphStatistics.Degree(g, 12) == 2);
        }

        [Test]
        public void AverageDegreeTest()
        {
            double realValue = GraphStatistics.AverageDegree(g);
            double expectedValue = ((double)26) / 13;

            //浮点数不能直接进行比较，确定精度后再进行比较
            int precision = 4;
            realValue = Math.Round(realValue, precision);
            expectedValue = Math.Round(expectedValue, precision);

            Assert.IsTrue(realValue.Equals(expectedValue));
        }


        [Test]
        public void  MaxDegreeTest()
        {
            Assert.IsTrue(GraphStatistics.MaxDegree(g) == 4);
        }

        [Test]
        public void NumberOfSelfLoopsTest()
        {
            Assert.IsTrue(GraphStatistics.NumberOfSelfLoops(g) == 0);
        }
    }
}
