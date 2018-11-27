using Aproximator.Std;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Aproximator
{
    [TestClass]
    public class AproximationTests
    {
        [TestMethod]
        public void LinearTest()
        {
            var info = Aproximation.Linear(new double[] {-5, 23.2}, new double[] {-6, 25});
            Assert.AreEqual(-5.0354610e-1, info.Rates[0], 0.0001);
            Assert.AreEqual(1.0992908, info.Rates[1], 0.0001);
        }

        [TestMethod]
        public void ParabolicTest()
        {
            var info = Aproximation.Parabolic(new double[] {-5, 23.2, 25}, new double[] {-6, 25, 32});
            Assert.AreEqual(-1.1289992e+1, info.Rates[0], 0.0001);
            Assert.AreEqual(-5.9306541e-1, info.Rates[1], 0.0001);
            Assert.AreEqual(9.2986604e-2, info.Rates[2], 0.0001);
        }

        [TestMethod]
        public void CubeTest()
        {
            var info = Aproximation.Cube(new double[] {-5, 23.2, 25, 45}, new double[] {-6, 25, 32, 45});
            Assert.AreEqual(-2.5300442e+1, info.Rates[0], 0.0001);
            Assert.AreEqual(-2.2308387, info.Rates[1], 0.0001);
            Assert.AreEqual(3.0169400e-1, info.Rates[2], 0.0001);
            Assert.AreEqual(-4.8311898e-3, info.Rates[3], 0.0001);
        }
    }
}