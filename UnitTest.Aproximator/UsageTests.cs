using Aproximator.Std;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Aproximator
{
    [TestClass]
    public class UsageTests
    {
        /// <summary>
        /// Данных больше, чем минимальное необходимое
        /// </summary>
        [TestMethod]
        public void LinearMoreDataTest()
        {
            var info = Aproximation.Linear(new double[] { -5, 23.2, 25, 45, 50 }, new double[] { -6, 25, 32, 45, 50 });
            Assert.AreEqual(1.4699587, info.Rates[0], 1e-6);
            Assert.AreEqual(1.0032576, info.Rates[1], 1e-6);
            Assert.AreEqual(5.449, info.Error, 1e-3);
            Assert.AreEqual(3.204, info.Sigma, 1e-3);
        }

        /// <summary>
        /// Данных больше, чем минимальное необходимое
        /// </summary>
        [TestMethod]
        public void ParabolicMoreDataTest()
        {
            var info = Aproximation.Parabolic(new double[] { -5, 23.2, 25, 45, 50 }, new double[] { -6, 25, 32, 45, 50 });
            Assert.AreEqual(6.9594801e-1, info.Rates[0], 1e-6);
            Assert.AreEqual(1.3078546, info.Rates[1], 1e-6);
            Assert.AreEqual(-6.6906435e-3, info.Rates[2], 1e-6);
            Assert.AreEqual(2.789, info.Error, 1e-3);
            Assert.AreEqual(1.945, info.Sigma, 1e-3);
        }

        /// <summary>
        /// Данных больше, чем минимальное необходимое
        /// </summary>
        [TestMethod]
        public void CubeMoreDataTest()
        {
            var info = Aproximation.Cube(new double[] { -5, 23.2, 25, 45, 50 }, new double[] { -6, 25, 32, 45, 50 });
            Assert.AreEqual(1.2455929, info.Rates[0], 1e-6);
            Assert.AreEqual(1.3875891, info.Rates[1], 1e-6);
            Assert.AreEqual(-1.3132932e-2, info.Rates[2], 1e-6);
            Assert.AreEqual(9.4377967e-5, info.Rates[3], 1e-6);
            Assert.AreEqual(2.798, info.Error, 1e-3);
            Assert.AreEqual(1.934, info.Sigma, 1e-3);
        }
    }
}