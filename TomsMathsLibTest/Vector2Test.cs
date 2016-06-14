using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TomsMathsLib;

namespace TomsMathsLibTest
{
    /// <summary>
    ///This is a test class for Vector2Test and is intended
    ///to contain all Vector2Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Vector2Test
    {
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for X
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            Vector2 target = new Vector2(2, 4); 
            Assert.AreEqual(2, target.X);
        }

        /// <summary>
        ///A test for Y
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            Vector2 target = new Vector2(2, 4); 
            Assert.AreEqual(4, target.Y);
        }

        /// <summary>
        ///A test for Vector2 Constructor
        ///</summary>
        [TestMethod()]
        public void Vector2ConstructorTest()
        {
            float x = 2;
            float y = 4;

            Vector2 target = new Vector2(x, y);

            Assert.AreEqual(x, target.X);
            Assert.AreEqual(y, target.Y);
        }

        /// <summary>
        ///A test for Magnitude
        ///</summary>
        [TestMethod()]
        public void MagnitudeTest()
        {
            Vector2 target = new Vector2(3, 4);

            float expected = (float)Math.Sqrt(25);
            float actual = target.Magnitude;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetNormalized
        ///</summary>
        [TestMethod()]
        public void GetNormalizedTest()
        {
            Vector2 target = new Vector2(3, 4);

            float actual = target.GetNormalized().Magnitude;

            Assert.AreEqual(1, actual);
        }

        /// <summary>
        ///A test for DotProduct
        ///</summary>
        [TestMethod()]
        public void DotProductTest()
        {
            Vector2 forward = new Vector2(0, 1);
            Vector2 back = new Vector2(0, -1);
            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);

            Assert.AreEqual(1, forward.DotProduct(forward));
            Assert.AreEqual(-1, forward.DotProduct(back));
            Assert.AreEqual(0, forward.DotProduct(right));
            Assert.AreEqual(0, forward.DotProduct(left));
        }
    }
}
