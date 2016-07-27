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

	    private readonly Camera m_Camera;
		private readonly List<Mesh> m_Meshes;
		private readonly List<Light> m_Lights;

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			m_Meshes = new List<Mesh>();
			m_Lights = new List<Light>();

			InitializeComponent();

			m_Bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);

			// Creating Cube geometry with Vertices
			List<Vector3> vertices = new List<Vector3>();

			// Top
			vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
			vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
			vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
			vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));

			// Bottom
			vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
			vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
			vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
			vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));

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
			cube.SetVerts(vertices);

			cube.SetTriangles(triangles);

			cube.Position = new Vector3();
			cube.Rotation = new Vector3(MathUtils.DegreesToRadians(45), MathUtils.DegreesToRadians(45), MathUtils.DegreesToRadians(20));
			cube.Scale = (Vector3.One() * 1.5f);

			m_Meshes.Add(cube);

			// Create a Light
			Light light = new Light();
			light.Position = new Vector3(5, 5, 5);
			light.Color = Color.Red;

			// Matrices
			m_Camera = new Camera();
            m_Camera.Position = new Vector3(0, 0, -20);
		    m_Camera.NearClipping = 0.1f;
		    m_Camera.FarClipping = 1000.0f;
		    m_Camera.AspectRatio = 1.0f;
		    m_Camera.FieldOfView = 80.0f;
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

			Render();

			e.Graphics.DrawImage(m_Bitmap, 0, 0);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//Draw to the memory and force the form to be repainted every 10 milliseconds
			//Render();
			//Invalidate();
		}

		private void Render()
		{
			/*
			m_Cube.Rotation += new Vector3(0, MathUtils.DegreesToRadians(25), 0);

			this.Text = string.Format("{0} {1} {2}", m_Cube.Rotation.X, m_Cube.Rotation.Y, m_Cube.Rotation.Z);
			
			for (int x = 0; x < ClientSize.Width; x++)
			{
				for (int y = 0; y < ClientSize.Height; y++)
				{
					Color color = Color.Black;

					m_Bitmap.SetPixel(x, y, color);
				}
			}

			m_Bitmap.DrawMesh(m_Projection, m_Camera, m_Cube, Color.Azure);*/

			for (int x = 0; x < ClientSize.Width; x++)
			{
				for (int y = 0; y < ClientSize.Height; y++)
				{
		            // Step 1 - compute primary ray direction for pixel
				    Vector3 rayPosition = m_Camera.ScreenToWorldPoint(x, y, ClientSize.Width, ClientSize.Height);
				    Vector3 rayDirection = (rayPosition - m_Camera.Position).GetNormalized();
                    Ray ray = new Ray(m_Camera.Position, rayDirection);
				   
                    // Step 2 - find closest intersection of ray with meshes
				    float near = float.MaxValue;
				    foreach (Mesh mesh in m_Meshes)
				    {
				        int[] triangles = mesh.GetTriangles();
				        Vector3[] verts = mesh.GetVertices();

                        for (int index = 0; index < triangles.Length; index += 3)
                        {
                            Vector3 vert1 = mesh.GetWorldMatrix().MultiplyPoint(verts[triangles[index]]);
                            Vector3 vert2 = mesh.GetWorldMatrix().MultiplyPoint(verts[triangles[index + 1]]);
                            Vector3 vert3 = mesh.GetWorldMatrix().MultiplyPoint(verts[triangles[index + 2]]);

                            Vector3 intersect;
                            if (!ray.IntersectsTriangle(vert1, vert2, vert3, out intersect))
                                continue;

                            float distance = (intersect - m_Camera.Position).Magnitude;
                            if (distance < near)
                                near = distance;

                            m_Bitmap.SetPixel(x, y, Color.Red);
                        }
				    }

                    // Step 3 - get illumination of pixel (ray from pixel to lights)

                    // Step 4 - draw the pixel
					//m_Bitmap.SetPixel(x, y, color);
				}
			}
		}
	}
}
