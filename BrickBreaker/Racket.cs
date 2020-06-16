using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{

    public class Racket
    {
        [field: NonSerialized]
        public PictureBox Box { get; }

        public Racket()
        {
            Box = new PictureBox();
            Box.Image = Properties.Resources.racket;
            Box.Width = 125;
            Box.Height = 20;
            Box.SizeMode = PictureBoxSizeMode.StretchImage;
            Box.BorderStyle = BorderStyle.None;
            Box.BackColor = Color.Transparent;

        }
    }
}
