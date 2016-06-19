using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using TomsMathsLib;

namespace TomsGraphicsProgram
{
    public static class BitmapExtension
    {
        public static void SetPixel(this Bitmap extends, Vector2 postion , Color color)
        {
            int x = (int)postion.X;
            int y = (int)postion.Y;

            extends.SetPixel(x, y, color);
        }

        public static void DrawLine(this Bitmap myBitmap, Vector2 start, Vector2 end, Color color)
        {
            if (start == end)
            {
                myBitmap.SetPixel(start, color);
                return;
            }

            Vector2 midPoint = new Vector2();

            midPoint = (start + end) / 2;

            DrawLine(myBitmap, start, midPoint, color);
            DrawLine(myBitmap, midPoint, end, color);
        }
    }
}