using System;
using TomsMathsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TomsMathsLibTest
{
    /// <summary>
    ///This is a test class for Vector3Test and is intended
    ///to contain all Vector3Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Vector3Test
    {
        /// <summary>
        ///A test for Z
        ///</summary>
        [TestMethod()]
        public void ZTest()
        {
            Vector3 target = new Vector3(2, 4, 6); // TODO: Initialize to an appropriate value
            float actual = 6;

            Assert.AreEqual(actual, target.Z);
        }

        /// <summary>
        ///A test for Y
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            Vector3 target = new Vector3(2, 4, 6); // TODO: Initialize to an appropriate value
            float actual = 4;

            Assert.AreEqual(actual, target.Y);
        }

        /// <summary>
        ///A test for X
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            Vector3 target = new Vector3(2, 4, 6); // TODO: Initialize to an appropriate value
            float actual = 2;

            Assert.AreEqual(actual, target.X);
        }

        /// <summary>
        ///A test for Vector3 Constructor
        ///</summary>
        [TestMethod()]
        public void Vector3ConstructorTest()
        {
            float x = 2; // TODO: Initialize to an appropriate value
            float y = 4; // TODO: Initialize to an appropriate value
            float z = 6; // TODO: Initialize to an appropriate value

            Vector3 target = new Vector3(x, y, z);

            Assert.AreEqual(x, target.X);
            Assert.AreEqual(y, target.Y);
            Assert.AreEqual(z, target.Z);
        }

        /// <summary>
        ///A test for Magnitude
        ///</summary>
        [TestMethod()]
        public void MagnitudeTest()
        {
            Vector3 target = new Vector3(3, 4, 5); // TODO: Initialize to an appropriate value
            float actual;
            float expected = (float)Math.Sqrt(50);

            actual = target.Magnitude;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetNormalized
        ///</summary>
        [TestMethod()]
        public void GetNormalizedTest()
        {
            Vector3 target = new Vector3(3, 4, 5);

            float expected = 1;
            float actual = target.GetNormalized().Magnitude;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DotProduct
        ///</summary>
        [TestMethod()]
        public void DotProductTest()
        {
            Vector3 target = new Vector3(1, 0, 0);
            Vector3 other = new Vector3(-1, 0, 0);

            float expected = 0;
            float actual;
            actual = target.DotProduct(other);

            Assert.AreEqual(expected, actual);
        }
    }
}
