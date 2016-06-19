using System;

namespace TomsMathsLib
{
	public struct Vector3
	{
		private readonly float m_X;
		private readonly float m_Y;
		private readonly float m_Z;

		// Properties for the Vector 3 postions
		public float X { get { return m_X; } }
		public float Y { get { return m_Y; } }
		public float Z { get { return m_Z; } }

        /// <summary>
        /// Distance from origin to Vector
        /// </summary>
        public float Magnitude
        {
            get
            {
                float m1 = MathUtils.Pythagoras(X, Y);
                float m2 = MathUtils.Pythagoras(m1, Z);

                return m2;
            }
        }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public Vector3(float x, float y, float z)
		{
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

        /// <summary>
        /// Returning a 1,1,1 Vector 3
        /// </summary>
        /// <returns></returns>
	    public static Vector3 One()
	    {
	        return new Vector3(1, 1, 1);
	    }

	    /// <summary>
		/// Normalizing magnitude to 1
		/// </summary>
		/// <returns></returns>
		public Vector3 GetNormalized()
		{
			float magnitude = Magnitude;

			float x = X / magnitude;
			float y = Y / magnitude;
			float z = Z / magnitude;

			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Calculates the dot product of this vector with another vector.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public float DotProduct(Vector3 other)
		{
			Vector3 thisNormalized = GetNormalized();
			Vector3 otherNormalized = other.GetNormalized();

			float axbx = thisNormalized.X * otherNormalized.X;
			float ayby = thisNormalized.Y * otherNormalized.Y;
			float azbz = thisNormalized.Z * otherNormalized.Z;

			return axbx + ayby + azbz;
		}

		/// <summary>
		/// Adds the two vectors.
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 operator +(Vector3 v1, Vector3 v2)
		{
            return new Vector3((v1.X + v2.X), (v1.Y + v2.Y), (v1.Z + v2.Z));
		}

		/// <summary>
		/// Subtracts vector 2 from vector 1.
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector3 operator -(Vector3 v1, Vector3 v2)
		{
            return new Vector3((v1.X - v2.X), (v1.Y - v2.Y), (v1.Z - v2.Z));
		}

		/// <summary>
		/// Returns a negative vector.
		/// </summary>
		/// <param name="v1"></param>
		/// <returns></returns>
		public static Vector3 operator -(Vector3 v1)
		{
            return new Vector3(0, 0 , 0) -v1;
		}

        /// <summary>
        /// Dividing vectors by a certain value
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 v1, float value)
        {
            return new Vector3((v1.X / value), (v1.Y / value), (v1.Z / value));
        }

        /// <summary>
        /// Multiplying a Vector by a certain value
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="value"></param>
        /// <returns></returns>
	    public static Vector3 operator *(Vector3 v1, float value)
	    {
	        return new Vector3((v1.X * value),(v1.Y * value),(v1.Z * value));
	    }
	}
}
