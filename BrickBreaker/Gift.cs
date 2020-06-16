using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{

    public enum GiftType
    {
        FiredBall,
        RacketModify

    }
    [Serializable]
    public class Gift
    {

        public Gift(GiftType type)
        {
            Box = new PictureBox();
            Type = type;
          

        }

        public void SetValues()
        {
            Box = new PictureBox();
            Box.Width = 60;
            Box.Height = 60;
            Box.SizeMode = PictureBoxSizeMode.StretchImage;
            Box.BorderStyle = BorderStyle.None;
            Box.BackColor = Color.Transparent;
            Box.Image = Properties.Resources.star;
            Box.Visible = false;
        }
        public int SpeedTop { get;set; }
        public GiftType Type { get; set; }
        [field: NonSerialized]
        public PictureBox Box { get; private set; }
        public bool Status { get; set; }
        [field: NonSerialized]
        public System.Timers.Timer GiftTimer { get; set; }
    }
}
