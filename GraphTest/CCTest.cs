using NUnit.Framework;
using StdIO;

namespace GraphTest
{
    public class CCTest
    {
        private Algorithm.GraphSpace.Graph g;
        private Algorithm.GraphSpace.CC c;

        [SetUp]
        public void Setup()
        {
            g = GraphDataParser.GetGraph("GraphData\\GraphData.txt");
            c = new Algorithm.GraphSpace.CC(g);
        }

        [Test]
        public void GetConnCountTest()
        {
            Assert.IsTrue(c.GetConnCount() == 3);

        }

        [Test]
        public void IsConnectedTest()
        {
            Assert.IsTrue(c.IsConnected(0,12) == false);
            Assert.IsTrue(c.IsConnected(0, 7) == false);
            Assert.IsTrue(c.IsConnected(7, 12) == false);
            Assert.IsTrue(c.IsConnected(8, 11) == false);

            Assert.IsTrue(c.IsConnected(0,5) == true);
            Assert.IsTrue(c.IsConnected(4, 3) == true);
            Assert.IsTrue(c.IsConnected(0, 1)==true);
            Assert.IsTrue(c.IsConnected(9, 12)==true);
            Assert.IsTrue(c.IsConnected(6, 4)==true);
            Assert.IsTrue(c.IsConnected(5, 4)==true);
            Assert.IsTrue(c.IsConnected(0, 2)==true);
            Assert.IsTrue(c.IsConnected(11, 12)==true);
            Assert.IsTrue(c.IsConnected(9, 10)==true);
            Assert.IsTrue(c.IsConnected(0, 6)==true);
            Assert.IsTrue(c.IsConnected(7, 8)==true);
            Assert.IsTrue(c.IsConnected(9, 11)==true);
            Assert.IsTrue(c.IsConnected(5, 3)==true);

        }

        [Test]
        public void GetConnIdTest()
        {
            Assert.IsTrue(c.GetConnId(0) == 1);
            Assert.IsTrue(c.GetConnId(1) == 1);
            Assert.IsTrue(c.GetConnId(2) == 1);
            Assert.IsTrue(c.GetConnId(3) == 1);
            Assert.IsTrue(c.GetConnId(4) == 1);
            Assert.IsTrue(c.GetConnId(5) == 1);
            Assert.IsTrue(c.GetConnId(6) == 1);
            Assert.IsTrue(c.GetConnId(7) == 2);
            Assert.IsTrue(c.GetConnId(8) == 2);
            Assert.IsTrue(c.GetConnId(9) == 3);
            Assert.IsTrue(c.GetConnId(10) == 3);
            Assert.IsTrue(c.GetConnId(11) == 3);
            Assert.IsTrue(c.GetConnId(12) == 3);
        }
    }
}
