using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TomsMathsLib;

namespace TomsGraphicsProgram
{
    public class Camera : AbstractWorldEntity
    {

        public float FieldOfView { get; set; }
        public float AspectRatio { get; set; }

        public float NearClipping { get; set; }
        public float FarClipping { get; set; }

        public Matrix4X4 projectionMatrix4X4()
        {
            return Matrix4X4.Projection(FieldOfView, AspectRatio, NearClipping, FarClipping);
        }

        public Matrix4X4 GetViewMatrix()
        {
            return Matrix4X4.View(Position, Rotation);
        }

        public Matrix4X4 WorldToScreenMatrix()
        {
            return projectionMatrix4X4() * GetViewMatrix();
        }

        public Matrix4X4 ScreenToWorldMatrix()
        {
            return WorldToScreenMatrix().Inverse();
        }

        public Vector3 ScreenToWorldPoint(float x, float y, float width, float height)
        {
            float Px = (2 * ((x + 0.5f) / width) - 1);
            float Py = (1 - 2 * ((y + 0.5f) / height));

            return ScreenToWorldMatrix().MultiplyPoint(Px, Py, NearClipping);
        }
    }
}
