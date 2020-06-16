using System;
using System.Windows.Forms;

namespace BrickBreaker
{

   public enum BrickType
    {
       Basic,
       Silver,
    };


    [Serializable]
    public class Brick
    {

        public Brick(BrickType type, int breakCount, int width, int height)
        {
            Type = type;
            BreakCount = breakCount;
            Width = width;
            Height = height;
        }
        public void SetValues()
        {
            Box.Width = Width;
            Box.Height = Height;
            Box.Image = Type == BrickType.Basic?Properties.Resources.redBrick :  Box.Image = Properties.Resources.blueBrick;
        }

        [field: NonSerialized]
        public PictureBox Box { get; set; }
        public BrickType Type { get; set; }
        public int BreakCount { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Gift BrickGift { get; set; }
  
    }
}
