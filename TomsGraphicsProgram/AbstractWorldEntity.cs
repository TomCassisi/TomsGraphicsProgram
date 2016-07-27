using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomsMathsLib;

namespace TomsGraphicsProgram
{
    public abstract class AbstractWorldEntity
    {
        // Auto properties for Mesh
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        // Getting the Martix for the Mesh
        public Matrix4X4 GetWorldMatrix()
        {
            return Matrix4X4.Trs(Position, Rotation, Scale);
        }
    }
}
