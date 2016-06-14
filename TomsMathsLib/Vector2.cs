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

    }
}
