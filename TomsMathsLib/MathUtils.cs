using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomsMathsLib
{
    public static class MathUtils
    {
        /// <summary>
        /// Pythagoras Theory
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Pythagoras(float x, float y)
        {
            float xSquared = x * x;
            float ySquared = y * y;

            float z = (float)Math.Sqrt(xSquared + ySquared);

            return z;
        }

        /// <summary>
        /// Converting Degress to Radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static float DegreesToRadians(float degrees)
        {
            return (float)(degrees / 180 * Math.PI);
        }
    }
}
