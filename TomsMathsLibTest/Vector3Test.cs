using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TomsMathsLib;

namespace TomsMathsLibTest
{
	/// <summary>
	///This is a test class for Vector3Test and is intended
	///to contain all Vector3Test Unit Tests
	///</summary>
	[TestClass]
	public class Vector3Test
	{
		/// <summary>
		///A test for Z
		///</summary>
		[TestMethod]
		public void ZTest()
		{
			Vector3 target = new Vector3(2, 4, 6);
			Assert.AreEqual(6, target.Z);
		}

		/// <summary>
		///A test for Y
		///</summary>
		[TestMethod]
		public void YTest()
		{
			Vector3 target = new Vector3(2, 4, 6);
			Assert.AreEqual(4, target.Y);
		}

		/// <summary>
		///A test for X
		///</summary>
		[TestMethod]
		public void XTest()
		{
			Vector3 target = new Vector3(2, 4, 6);
			Assert.AreEqual(2, target.X);
		}

		/// <summary>
		///A test for Vector3 Constructor
		///</summary>
		[TestMethod]
		public void Vector3ConstructorTest()
		{
			float x = 2;
			float y = 4;
			float z = 6;

			Vector3 target = new Vector3(x, y, z);

			Assert.AreEqual(x, target.X);
			Assert.AreEqual(y, target.Y);
			Assert.AreEqual(z, target.Z);
		}

		/// <summary>
		///A test for Magnitude
		///</summary>
		[TestMethod]
		public void MagnitudeTest()
		{
			Vector3 target = new Vector3(3, 4, 5);

			float expected = (float)Math.Sqrt(50);
			float actual = target.Magnitude;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for GetNormalized
		///</summary>
		[TestMethod]
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
		[TestMethod]
		public void DotProductTest()
		{
			Vector3 forward = new Vector3(0, 0, 1);
			Vector3 back = new Vector3(0, 0, -1);
			Vector3 right = new Vector3(1, 0, 0);
			Vector3 left = new Vector3(-1, 0, 0);

			Assert.AreEqual(1, forward.DotProduct(forward));
			Assert.AreEqual(-1, forward.DotProduct(back));
			Assert.AreEqual(0, forward.DotProduct(right));
			Assert.AreEqual(0, forward.DotProduct(left));
		}
	}
}
