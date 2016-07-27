using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            if (x < 0 || x >= extends.Width)
                return;
            
            if (y < 0 || y >= extends.Height)
                return;

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

        public static void DrawMesh(this Bitmap myBitmap, Matrix4X4 projectionMatrix, Matrix4X4 cameraMatrix, Mesh mesh, Color color)
        {
            Matrix4X4 finalMatrix = projectionMatrix * cameraMatrix * mesh.GetWorldMatrix();

            int[] triangles = mesh.GetTriangles();
            Vector3[] vertices = mesh.GetVertices();

            for (int index = 0; index < triangles.Length; index += 3)
            {
                Vector3 vert1 = vertices[triangles[index]];
                Vector3 vert2 = vertices[triangles[index + 1]];
                Vector3 vert3 = vertices[triangles[index + 2]];

                DrawTriangle(myBitmap, finalMatrix, vert1, vert2, vert3, color);
            }
        }

        public static void DrawTriangle(this Bitmap myBitmap, Matrix4X4 final, Vector3 v1, Vector3 v2, Vector3 v3, Color color)
        {
            Vector2 point1 = ToBitmapSpace(myBitmap, final, v1);
            Vector2 point2 = ToBitmapSpace(myBitmap, final, v2);
            Vector2 point3 = ToBitmapSpace(myBitmap, final, v3);

            SortTriangleInY(ref point1, ref point2, ref point3);

            Vector2 point4 = new Vector2((int)(point1.X + ((point2.Y - point1.Y) / (point3.Y - point1.Y)) * (point3.X - point1.X)), point2.Y);

            FillBottomFlatTriangle(myBitmap, point1, point2, point4, color);
            FillTopFlatTriangle(myBitmap, point2, point4, point3, color);

            myBitmap.DrawLine(point1, point2, Color.Black);
            myBitmap.DrawLine(point2, point3, Color.Black);
            myBitmap.DrawLine(point3, point1, Color.Black);
        }

        private static void FillBottomFlatTriangle(this Bitmap myBitmap, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
        {
          float invslope1 = (v2.X - v1.X) / (v2.Y - v1.Y);
          float invslope2 = (v3.X - v1.X) / (v3.Y - v1.Y);

          float curx1 = v1.X;
          float curx2 = v1.X;

          for (int scanlineY = (int)v1.Y; scanlineY <= v2.Y; scanlineY++)
          {
            myBitmap.DrawLine(new Vector2(curx1, scanlineY), new Vector2(curx2, scanlineY), color);
            curx1 += invslope1;
            curx2 += invslope2;
          }
        }



        private static void FillTopFlatTriangle(this Bitmap myBitmap, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
        {
          float invslope1 = (v3.X - v1.X) / (v3.Y - v1.Y);
          float invslope2 = (v3.X - v2.X) / (v3.Y - v2.Y);

          float curx1 = v3.X;
          float curx2 = v3.X;

          for (int scanlineY = (int)v3.Y; scanlineY > v1.Y; scanlineY--)
          {
            myBitmap.DrawLine(new Vector2(curx1, scanlineY), new Vector2(curx2, scanlineY), color);
            curx1 -= invslope1;
            curx2 -= invslope2;
          }
        }

        /// <summary>
        /// Returns the triangle A, B, C in order of Y axis.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private static void SortTriangleInY(ref Vector2 a, ref Vector2 b, ref Vector2 c)
        {
            List<Vector2> pointsSortedOnYList = new List<Vector2>();
            pointsSortedOnYList.Add(a);
            pointsSortedOnYList.Add(b);
            pointsSortedOnYList.Add(c);

            pointsSortedOnYList.Sort(CompareYAxis);

            a = pointsSortedOnYList[0];
            b = pointsSortedOnYList[1];
            c = pointsSortedOnYList[2];
        }

        /// <summary>
        /// Compares the Y axis of the vectors.
        /// 
        /// Less than 0 - a is less than b
        /// 0 - a equals b.
        /// Greater than 0 - a is greater than b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int CompareYAxis(Vector2 a, Vector2 b)
        {
            if (a.Y < b.Y)
                return -1;

            if (a.Y > b.Y)
                return 1;

            return 0;
        }

        private static Vector2 ToBitmapSpace(this Bitmap myBitmap, Matrix4X4 final, Vector3 vector)
        {
            vector = final.MultiplyPoint(vector);

            float x = (vector.X + 1) / 2 * myBitmap.Width;
            float y = (vector.Y + 1) / 2 * myBitmap.Height;

            return new Vector2(x, y);
        }
    }
}