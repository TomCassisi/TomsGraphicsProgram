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
					int r = (int)Math.Floor((float)x / ClientSize.Width * 255);
					int g = (int)Math.Floor((float)y / ClientSize.Height * 255);
					int b = 0;

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

            // Matrices
		    Matrix4X4 World = Matrix4X4.Trs(
                new Vector3(), 
                new Vector3(MathUtils.DegreesToRadians(45), MathUtils.DegreesToRadians(45) ,MathUtils.DegreesToRadians(20)), 
                Vector3.One() * 1.5f);
		    Matrix4X4 Camera = Matrix4X4.Translation(new Vector3(0, 0, -20));
		    Matrix4X4 Projection = Matrix4X4.Projection(80, 1, 0.1f, 1000);
		    Matrix4X4 Final = Projection * Camera * World;

            // Taking Model space data and converting it to ScreenPosition data with the Matrices
            List<Vector2> ScreenPos = new List<Vector2>();

		    for (int index = 0; index < Vertices.Count; index++)
		    {
		        Vector3 point = Final.MultiplyPoint(Vertices[index]);

		        float x = (point.X + 1) / 2 * m_Bitmap.Width;
		        float y = (point.Y + 1) / 2 * m_Bitmap.Height;

                ScreenPos.Add(new Vector2(x, y));
		    }

            // Drawning lines
            // Vertical
            m_Bitmap.DrawLine(ScreenPos[0], ScreenPos[1], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[2], ScreenPos[3], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[4], ScreenPos[5], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[6], ScreenPos[7], Color.Azure);

            // Horizontal
            m_Bitmap.DrawLine(ScreenPos[0], ScreenPos[2], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[4], ScreenPos[6], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[1], ScreenPos[3], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[5], ScreenPos[7], Color.Azure);

            // Diagonal
            m_Bitmap.DrawLine(ScreenPos[0], ScreenPos[4], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[2], ScreenPos[6], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[1], ScreenPos[5], Color.Azure);
            m_Bitmap.DrawLine(ScreenPos[3], ScreenPos[7], Color.Azure);

			e.Graphics.DrawImage(m_Bitmap, 0, 0);
		}
	}
}
