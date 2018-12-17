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
            var info = Aproximation.Linear(new double[] { -5, 23.2 }, new double[] { -6, 25 });
            Assert.AreEqual(-5.0354610e-1, info.Rates[0], 1e-6);
            Assert.AreEqual(1.0992908, info.Rates[1], 1e-6);
            Assert.AreEqual(1.776e-15, info.Error, 1e-15);
            Assert.AreEqual(1.776e-15, info.Sigma, 1e-15);
        }

        [TestMethod]
        public void ParabolicTest()
        {
            var info = Aproximation.Parabolic(new double[] { -5, 23.2, 25 }, new double[] { -6, 25, 32 });
            Assert.AreEqual(-1.1289992e+1, info.Rates[0], 1e-6);
            Assert.AreEqual(-5.9306541e-1, info.Rates[1], 1e-6);
            Assert.AreEqual(9.2986604e-2, info.Rates[2], 1e-6);
            Assert.AreEqual(1.421e-14, info.Error, 1e-14);
            Assert.AreEqual(1.005e-14, info.Sigma, 1e-14);
        }

        [TestMethod]
        public void CubeTest()
        {
            var info = Aproximation.Cube(new double[] { -5, 23.2, 25, 45 }, new double[] { -6, 25, 32, 45 });
            Assert.AreEqual(-2.5300442e+1, info.Rates[0], 1e-6);
            Assert.AreEqual(-2.2308387, info.Rates[1], 1e-6);
            Assert.AreEqual(3.0169400e-1, info.Rates[2], 1e-6);
            Assert.AreEqual(-4.8311898e-3, info.Rates[3], 1e-6);
            Assert.AreEqual(2.888e-12, info.Error, 1e-6);
            Assert.AreEqual(2.011e-12, info.Sigma, 1e-6);
        }

        [TestMethod]
        public void LinearErrorTest()
        {
            var info = Aproximation.Linear(new double[] { -5, 23.2, 25, 45 }, new double[] { -6, 25, 32, 45 });
            Assert.AreEqual(1.0848135, info.Rates[0], 1e-6);
            Assert.AreEqual(1.0392375, info.Rates[1], 1e-6);
            Assert.AreEqual(4.934, info.Error, 0.001);
            Assert.AreEqual(3.468, info.Sigma, 0.001);
        }

        [TestMethod]
        public void CubeErrorTest()
        {
            var info = Aproximation.Cube(new double[] { -5, 23.2, 25, 45,50 }, new double[] { -6, 25, 32, 45,50});
            Assert.AreEqual(1.2455929, info.Rates[0], 1e-6);
            Assert.AreEqual(1.3875891, info.Rates[1], 1e-6);
            Assert.AreEqual(-1.3132932e-2, info.Rates[2], 1e-6);
            Assert.AreEqual(9.4377967e-5, info.Rates[3], 1e-6);
            Assert.AreEqual(2.798, info.Error, 1e-3);
            Assert.AreEqual(1.934, info.Sigma, 1e-3);
        }
    }
}