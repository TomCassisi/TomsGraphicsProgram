using System;
using System.Drawing;
using System.Windows.Forms;

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

					Color color = Color.FromArgb(r, g, b);

				    m_Bitmap.SetPixel(x, y, color);
			    }
		    }

			e.Graphics.DrawImage(m_Bitmap, 0, 0);
	    }
    }
}
