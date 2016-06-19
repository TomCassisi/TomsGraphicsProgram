using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TomsMathsLib;

namespace TomsGraphicsProgram
{
    public class Mesh
    {
        // Auto properties for Mesh
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        // Backing Fields
        private readonly List<Vector3> m_Verts;
        private readonly List<int> m_Triangles;

        // Constructor for Mesh
        public Mesh()
        {
            m_Verts = new List<Vector3>();
            m_Triangles = new List<int>();
        }

        // Setting Verts which are the Mesh
        public void SetVerts(IEnumerable<Vector3> verts)
        {
            m_Verts.Clear();
            m_Verts.AddRange(verts);
        }

        // Getting the Verts from the Mesh
        public Vector3[] GetVertices()
        {
            return m_Verts.ToArray();
        }

        //  Setting triangles within the Mesh
        public void SetTriangles(IEnumerable<int> triangles)
        {
            m_Triangles.Clear();
            m_Triangles.AddRange(triangles);
        }

        // Getting the Triangles from the Mesh
        public int[] GetTriangles()
        {
            return m_Triangles.ToArray();
        }

        // Getting the Martix for the Mesh
        public Matrix4X4 GetWorldMatrix()
        {
            return Matrix4X4.Trs(Position, Rotation, Scale);
        }
    }
}
