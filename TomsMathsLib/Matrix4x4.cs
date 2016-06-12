using System;

namespace TomsMathsLib
{
	/// <summary>
	/// Left handed 4x4 matrix for vector transformations.
	/// </summary>
	public class Matrix4X4
	{
		private readonly float[] m_Values;

		#region Constructors

		/// <summary>
		/// Constructor.
		/// </summary>
		public Matrix4X4()
		{
			m_Values = new float[4 * 4];
		}

		/// <summary>
		/// Creates an identity matrix.
		/// </summary>
		/// <returns></returns>
		public static Matrix4X4 Identity()
		{
			Matrix4X4 output = new Matrix4X4();

			for (int index = 0; index < 4; index++)
				output[index, index] = 1.0f;

			return output;
		}

		/// <summary>
		/// Creates a translation matrix.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public static Matrix4X4 Translation(float x, float y, float z)
		{
			Matrix4X4 output = Identity();

			output[0, 3] = x;
			output[1, 3] = y;
			output[2, 3] = z;

			return output;
		}

		/// <summary>
		/// Creates a translation matrix.
		/// </summary>
		/// <param name="translation"></param>
		/// <returns></returns>
		public static Matrix4X4 Translation(Vector3 translation)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public static Matrix4X4 Scale(float x, float y, float z)
		{
			Matrix4X4 output = Identity();

			output[0, 0] = x;
			output[1, 1] = y;
			output[2, 2] = z;

			return output;
		}

		/// <summary>
		/// Creates a scale matrix.
		/// </summary>
		/// <param name="scale"></param>
		/// <returns></returns>
		public static Matrix4X4 Scale(Vector3 scale)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a rotation matrix.
		/// </summary>
		/// <param name="pitch"></param>
		/// <param name="yaw"></param>
		/// <param name="roll"></param>
		/// <returns></returns>
		public static Matrix4X4 Rotation(float pitch, float yaw, float roll)
		{
			float cosPitch = (float)Math.Cos(pitch);
			float sinPitch = (float)Math.Sin(pitch);

			float cosYaw = (float)Math.Cos(yaw);
			float sinYaw = (float)Math.Sin(yaw);

			float cosRoll = (float)Math.Cos(roll);
			float sinRoll = (float)Math.Sin(roll);

			Matrix4X4 x = Identity();
			x[1, 1] = cosPitch;
			x[1, 2] = -sinPitch;
			x[2, 1] = sinPitch;
			x[2, 2] = cosPitch;

			Matrix4X4 y = Identity();
			y[0, 0] = cosYaw;
			y[0, 2] = sinYaw;
			y[2, 0] = -sinYaw;
			y[2, 2] = cosYaw;

			Matrix4X4 z = Identity();
			z[0, 0] = cosRoll;
			z[0, 1] = -sinRoll;
			z[1, 0] = sinRoll;
			z[1, 1] = cosRoll;

			return z * y * x;
		}

		/// <summary>
		/// Creates a rotation matrix.
		/// </summary>
		/// <param name="rotation"></param>
		/// <returns></returns>
		public static Matrix4X4 Rotation(Vector3 rotation)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a translation, rotation and scale matrix.
		/// </summary>
		/// <param name="translation"></param>
		/// <param name="rotation"></param>
		/// <param name="scale"></param>
		/// <returns></returns>
		public static Matrix4X4 Trs(Vector3 translation, Vector3 rotation, Vector3 scale)
		{
			Matrix4X4 translationMatrix = Translation(translation);
			Matrix4X4 rotationMatrix = Rotation(rotation);
			Matrix4X4 scaleMatrix = Scale(scale);

			return translationMatrix * rotationMatrix * scaleMatrix;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Gets the value at the given row and column.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public float this[int row, int column]
		{
			get
			{
				int index = row * 4 + column;
				return m_Values[index];
			}
			set
			{
				int index = row * 4 + column;
				m_Values[index] = value;
			}
		}

		/// <summary>
		/// Handles matrix multiplication.
		/// </summary>
		/// <param name="m1"></param>
		/// <param name="m2"></param>
		/// <returns></returns>
		public static Matrix4X4 operator *(Matrix4X4 m1, Matrix4X4 m2)
		{
			Matrix4X4 output = new Matrix4X4();

			for (int row = 0; row < 4; row++)
			{
				for (int column = 0; column < 4; column++)
				{
					for (int offset = 0; offset < 4; offset++)
						output[row, column] += m1[row, offset] * m2[offset, column];
				}
			}

			return output;
		}

		/// <summary>
		/// Transforms the position vector.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public Vector3 MultiplyPoint(float x, float y, float z)
		{
			return Multiply(x, y, z, 1);
		}

		/// <summary>
		/// Transforms the position vector.
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public Vector3 MultiplyPoint(Vector3 point)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Transforms the direction vector.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public Vector3 MultiplyDirection(float x, float y, float z)
		{
			return Multiply(x, y, z, 0);
		}

		/// <summary>
		/// Transforms the direction vector.
		/// </summary>
		/// <param name="direction"></param>
		/// <returns></returns>
		public Vector3 MultiplyDirection(Vector3 direction)
		{
			throw new NotImplementedException();
		}

		#endregion

		/// <summary>
		/// Multiplies the matrix with the given vector.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		private Vector3 Multiply(float x, float y, float z, float w)
		{
			float outX = this[0, 0] * x + this[0, 1] * y + this[0, 2] * z + this[0, 3] * w;
			float outY = this[1, 0] * x + this[1, 1] * y + this[1, 2] * z + this[1, 3] * w;
			float outZ = this[2, 0] * x + this[2, 1] * y + this[2, 2] * z + this[2, 3] * w;

			throw new NotImplementedException();
		}
	}
}
