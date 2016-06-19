using System;

namespace TomsMathsLib
{
    public struct Vector2
    {
        private readonly float m_X;
        private readonly float m_Y;

        // Properties for the Vector 2 postions
        public float X { get { return m_X; } }
        public float Y { get { return m_Y; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(float x, float y)
        {
            m_X = x;
            m_Y = y;
        }

        /// <summary>
        /// Distance from origin to Vector
        /// </summary>
        public float Magnitude
        {
            get
            {
                float magnitude = MathUtils.Pythagoras(m_X, m_Y);

                return magnitude;

            }
        }

        /// <summary>
        /// Normalizing magnitude to 1
        /// </summary>
        /// <returns></returns>
        public Vector2 GetNormalized()
        {
            float magnitude = Magnitude;

            float x = X / magnitude;
            float y = Y / magnitude;

            return  new Vector2(x, y);

        }

        /// <summary>
        /// Calculates the dot product of this vector with another vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float DotProduct(Vector2 other)
        {
            Vector2 thisNormalized = GetNormalized();
            Vector2 otherNormalized = other.GetNormalized();

            float axbx = thisNormalized.X * otherNormalized.X;
            float ayby = thisNormalized.Y * otherNormalized.Y;

            return axbx + ayby;
        }

        /// <summary>
        /// Adds the two vectors.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2((v1.X + v2.X), (v1.Y + v2.Y));
        }

        /// <summary>
        /// Subtracts vector 2 from vector 1.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2((v1.X - v2.X), (v1.Y - v2.Y));
        }

        /// <summary>
        /// Returns a negative vector.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 v1)
        {
            return new Vector2(0, 0) - v1;
        }

        /// <summary>
        /// Dividing vectors by a certain value
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 operator /(Vector2 v1, float value)
        {
            return new Vector2((v1.X / value), (v1.Y / value));
        }

        /// <summary>
        /// Checking if one Vector2 is the same as the other.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            if (Math.Abs(v1.X - v2.X) > 0.01f)
            {
                return false;
            }

            if (Math.Abs(v1.Y - v2.Y) > 0.01f)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checking if the two vectors are not the same
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }
    }
}
