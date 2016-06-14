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
		    return Translation(translation.X, translation.Y, translation.Z);
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
		    return Scale(scale.X, scale.Y, scale.Z);
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
		    return Rotation(rotation.X, rotation.Y, rotation.Z);
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

		/// <summary>
		/// Returns a camera view matrix.
		/// </summary>
		/// <param name="position"></param>
		/// <param name="rotation"></param>
		/// <returns></returns>
		public static Matrix4X4 View(Vector3 position, Vector3 rotation)
		{
			Matrix4X4 trans = Translation(-position);
			Matrix4X4 rot = Rotation(-rotation);

			// Move then rotate.
			return rot * trans;
		}

		/// <summary>
		/// Create an orthographic projection matrix.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="near"></param>
		/// <param name="far"></param>
		/// <returns></returns>
		public static Matrix4X4 Orthographic(float width, float height, float near, float far)
		{
			Matrix4X4 output = Identity();

			output[0, 0] = 1 / width;
			output[1, 1] = 1 / height;
			output[2, 2] = -2 / (far - near);
			output[2, 3] = -(far + near) / (far - near);

			return output;
		}

		public static Matrix4X4 Projection(float fov, float aspect, float nearDist, float farDist)
		{
			Matrix4X4 output = Identity();

			float frustumDepth = farDist - nearDist;
			float oneOverDepth = 1 / frustumDepth;

			output[1, 1] = 1 / (float)Math.Tan(0.5f * fov);
			output[0, 0] = output[1, 1] / aspect;
			output[2, 2] = farDist * oneOverDepth;
			output[3, 2] = (-farDist * nearDist) * oneOverDepth;
			output[2, 3] = 1;
			output[3, 3] = 0;

			return output;
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
		    return MultiplyPoint(point.X, point.Y, point.Z);
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
		    return MultiplyDirection(direction.X, direction.Y, direction.Z);
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
			float outW = this[3, 0] * x + this[3, 1] * y + this[3, 2] * z + this[3, 3] * w;

			outX /= outW;
			outY /= outW;
			outZ /= outW;

			return new Vector3(outX, outY, outZ);
		}
	}
}
