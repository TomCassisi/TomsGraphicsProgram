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

            myBitmap.DrawLine(point1, point2, color);
            myBitmap.DrawLine(point2, point3, color);
            myBitmap.DrawLine(point3, point1, color);
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