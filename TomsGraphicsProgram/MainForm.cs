using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TomsMathsLib;

namespace TomsGraphicsProgram
{
	public partial class MainForm : Form
	{
		private readonly Bitmap m_Bitmap;

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			m_Bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
		}

		/// <summary>
		/// Destructor.
		/// </summary>
		~MainForm()
		{
			m_Bitmap.Dispose();
		}

		/// <summary>
		/// Called to repaint the form.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			for (int x = 0; x < ClientSize.Width; x++)
			{
				for (int y = 0; y < ClientSize.Height; y++)
				{
					Color color = Color.Black;

					m_Bitmap.SetPixel(x, y, color);
				}
			}

            // Creating Cube geometry with Vertices
            List<Vector3> Vertices = new List<Vector3>();

            // Top
            Vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            Vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            Vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            Vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));

            // Bottom
            Vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            Vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            Vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            Vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
  
            // List of vert indices for the triangles
            List<int> triangles = new List<int>();

            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);
            triangles.Add(1);
            triangles.Add(2);
            triangles.Add(3);

            triangles.Add(4);
            triangles.Add(5);
            triangles.Add(6);
            triangles.Add(5);
            triangles.Add(6);
            triangles.Add(7);

            triangles.Add(4);
            triangles.Add(0);
            triangles.Add(5);
            triangles.Add(5);
            triangles.Add(0);
            triangles.Add(1);

            triangles.Add(6);
            triangles.Add(2);
            triangles.Add(7);
            triangles.Add(7);
            triangles.Add(2);
            triangles.Add(3);

            triangles.Add(4);
            triangles.Add(6);
            triangles.Add(2);
            triangles.Add(4);
            triangles.Add(2);
            triangles.Add(0);

            triangles.Add(5);
            triangles.Add(7);
            triangles.Add(3);
            triangles.Add(3);
            triangles.Add(1);
            triangles.Add(5);
         
            // Creating a Mesh
            Mesh cube = new Mesh();
            cube.SetVerts(Vertices);

            cube.SetTriangles(triangles);

            cube.Position = new Vector3();
            cube.Rotation = new Vector3(MathUtils.DegreesToRadians(45), MathUtils.DegreesToRadians(45), MathUtils.DegreesToRadians(20));
            cube.Scale = (Vector3.One() * 1.5f);

            // Matrices
		    Matrix4X4 Camera = Matrix4X4.Translation(new Vector3(0, 0, -20));
		    Matrix4X4 Projection = Matrix4X4.Projection(80, 1, 0.1f, 1000);

            m_Bitmap.DrawMesh(Projection, Camera, cube, Color.Azure);

			e.Graphics.DrawImage(m_Bitmap, 0, 0);
		}
	}
}
