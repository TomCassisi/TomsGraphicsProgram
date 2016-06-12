using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

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
                float M1 = MathUtils.Pythagoras(X, Y);
                float M2 = MathUtils.Pythagoras(M1, Z);

                return M2;
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
            Vector3 thisNormalized = this.GetNormalized();
            Vector3 otherNormalized = other.GetNormalized();

            float axbx = thisNormalized.X * otherNormalized.X;
            float ayby = thisNormalized.Y * otherNormalized.Y;
            float azbz = thisNormalized.Z * otherNormalized.Z;

            float adotb = axbx + ayby + azbz;

            return (float)(Math.Acos(adotb) / (-2 * Math.PI));
        }
    }
}
