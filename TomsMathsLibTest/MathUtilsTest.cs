using TomsMathsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TomsMathsLibTest
{
    
    
    /// <summary>
    ///This is a test class for MathUtilsTest and is intended
    ///to contain all MathUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MathUtilsTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        ///A test for Pythagoras
        ///</summary>
        [TestMethod()]
        public void PythagorasTest()
        {
            float x = 3; // TODO: Initialize to an appropriate value
            float y = 4; // TODO: Initialize to an appropriate value
            float expected = 5; // TODO: Initialize to an appropriate value

            float actual = MathUtils.Pythagoras(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}
