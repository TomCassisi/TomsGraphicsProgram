using TomsMathsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TomsMathsLibTest
{
    
    
    /// <summary>
    ///This is a test class for Matrix4X4Test and is intended
    ///to contain all Matrix4X4Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Matrix4X4Test
    {
        /// <summary>
        ///A test for Inverse
        ///</summary>
        [TestMethod()]
        public void InverseTest()
        {
            Matrix4X4 transform = Matrix4X4.Translation(5, 10, 5);
            Matrix4X4 inverse = transform.Inverse();

            Vector3 position = transform.MultiplyPoint(new Vector3());
            Vector3 origin = inverse.MultiplyPoint(position);

            Assert.AreEqual(new Vector3(), origin);
        }
    }
}
