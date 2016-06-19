using System;
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

            m_Bitmap.DrawLine(new Vector2(40, 50), new Vector2(80, 100), Color.Azure);

		    for (int y = 10; y < ClientSize.Height; y++)
		    {
                m_Bitmap.SetPixel(10, y, Color.White);

                m_Bitmap.SetPixel(60, y, Color.Blue);

                m_Bitmap.SetPixel(110, y, Color.Chartreuse);

                m_Bitmap.SetPixel(160, y, Color.Coral);

                m_Bitmap.SetPixel(210, y, Color.DarkOrchid);

                m_Bitmap.SetPixel(260, y, Color.DeepPink);
		    }
            
			e.Graphics.DrawImage(m_Bitmap, 0, 0);
		}
	}
}
