using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
  public enum BallType
    {
       Fired,
       Basic
    }

    public class Ball
    {
  
        public int SpeedLeft { get; set;}
        public int SpeedTop { get; set; }
        public Ball(BallType type,int speedLeft, int speedTop)
        {
            Type = type;
            Box = new PictureBox();
            Box.Image = Properties.Resources.ball;
            Box.SizeMode = PictureBoxSizeMode.CenterImage;
            Box.BorderStyle = BorderStyle.None;
            Box.BackColor = Color.Red;
            Box.Width = 35;
            Box.Height = 35;
            SpeedLeft = speedLeft;
            SpeedTop = speedTop;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, this.Box.Width - 2, this.Box.Height - 2);
            Region rg = new Region(gp);
            this.Box.Region = rg;
        }
        public BallType Type { get; set; }
        public PictureBox Box { get;}


    }
}
