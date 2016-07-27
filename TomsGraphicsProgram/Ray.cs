using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomsMathsLib;

namespace TomsGraphicsProgram
{
    public struct Ray
    {
        private readonly Vector3 m_Direction;
        private readonly Vector3 m_StartPosition;

        public Vector3 Direction {get { return m_Direction; }}
        public Vector3 StartDirection {get { return m_StartPosition; }}

        /// <summary>
        /// Ray Constructor
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="Direction"></param>
        public Ray(Vector3 startPosition, Vector3 Direction)
        {
            m_StartPosition = startPosition;
            m_Direction = Direction.GetNormalized();

        }

        /// <summary>
        /// Returns true if the ray intersects the given triangle.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="intersect"></param>
        /// <returns></returns>
        public bool IntersectsTriangle(Vector3 a, Vector3 b, Vector3 c, out Vector3 intersect)
        {
            intersect = default(Vector3);

            Vector3 near = m_StartPosition;
            Vector3 far = m_StartPosition + m_Direction * float.MaxValue;

            Vector3 normal = Vector3.CrossProduct(b - a, c - a);

            // Find distance from La and Lb to the plane defined by the triangle
            float dist1 = (near - a).DotProduct(normal);
            float dist2 = (far - a).DotProduct(normal);

            // line doesn't cross the triangle.
            if ((dist1 * dist2) >= 0.0f)
                return false;

            // line and plane are parallel
            if (dist1 == dist2)
                return false;

            // Find point on the line that intersects with the plane
            intersect = near + (far - near) * (-dist1 / (dist2 - dist1));

            // Find if the interesection point lies inside the triangle by testing it against all edges
            Vector3 vTest = normal.Cross(b - a);
            if (vTest.DotProduct(intersect - a) < 0.0f) 
                return false;

            vTest = normal.Cross(c - b);
            if (vTest.DotProduct(intersect - b) < 0.0f)
                return false;

            vTest = normal.Cross(a - c);
            if (vTest.DotProduct(intersect - a) < 0.0f)
                return false;

            return true;
        }
    }
}
