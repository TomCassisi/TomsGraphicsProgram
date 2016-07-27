using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TomsGraphicsProgram
{
    public class Light : AbstractWorldEntity
    {
        public float Intensity { get; set; }
        public Color Color { get; set; }
    }
}
