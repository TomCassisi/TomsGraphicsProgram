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

    }
}
