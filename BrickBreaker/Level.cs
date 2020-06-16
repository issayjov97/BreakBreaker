using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BrickBreaker
{
    [Serializable]
    public class Level
    {
        public Brick[,] Bricks { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Points { get; private set; }
        [field: NonSerialized]
        public Ball Ball { get; set; }
        [field: NonSerialized]
        public Racket Racket { get; set; }
        private Gift[] gifts;
        public int GiftCount { get; private set; }
        [field: NonSerialized]
        private static bool DestroyMode = false;
        public Level()
        {

        }

        private delegate void DeactivateGift(GiftType type);

        public bool StartNextLevel(int level)
        {
            Points = 0;
            int currentLevel = level;
            using (StreamReader reader = new StreamReader("levels.txt"))
            {

                string s = string.Empty;
                int skip = -1;
                int giftIndex = 0;
                char[] playgr = null;
                while ((s = reader.ReadLine()) != null)
                {
                    if (s.Equals("{"))
                    {
                        skip++;

                    }
                    else if (skip == currentLevel)
                    {
                        if (Regex.IsMatch(s, "^\\d+$"))
                        {
                            playgr = s.ToCharArray();
                            Rows = int.Parse(playgr[0].ToString());
                            Columns = int.Parse(playgr[1].ToString());
                            GiftCount = int.Parse(playgr[2].ToString());
                            Bricks = new Brick[Rows, Columns];
                            gifts = new Gift[GiftCount];
                            int j = 0;
                            while (s != "}")
                            {
                                s = reader.ReadLine();
                                playgr = s.ToCharArray();

                                for (int i = 0; i < playgr.Length; i++)
                                {
                                    if (playgr[i] == ' ')
                                    {
                                        Bricks[j, i] = null;
                                    }
                                    else if (playgr[i] == '#')
                                    {
                                        Bricks[j, i] = new Brick(BrickType.Silver, 0, 100, 25);
                                    }
                                    else if (playgr[i] == '+')
                                    {
                                        Bricks[j, i] = new Brick(BrickType.Basic, 0, 100, 25);
                                    }
                                    else if (playgr[i] == '*')
                                    {
                                        Bricks[j, i] = new Brick(BrickType.Basic, 0, 100, 25);
                                        Gift gift = new Gift(GiftType.FiredBall);
                                        Bricks[j, i].BrickGift = gift;
                                        gifts[giftIndex++] = gift;

                                    }
                                    else if (playgr[i] == '@')
                                    {
                                        Bricks[j, i] = new Brick(BrickType.Basic, 0, 100, 25);
                                        Gift gift = new Gift(GiftType.RacketModify);
                                        Bricks[j, i].BrickGift = gift;
                                        gifts[giftIndex++] = gift;

                                    }
                                }
                                j++;
                            }
                            if (s == "}") return true;

                        }
                    }

                }
                return false;

            }


        }
        public Brick this[int i, int j]
        {
            get => Bricks[i, j];
        }

        public Gift this[int i]
        {
            get => gifts[i];
        }
        public void SetBlocks()
        {

            int x = 0;
            int y = (Form1.formWidth - (Columns * 100)) / 2;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {

                    if (Bricks[i, j] != null)
                    {
                        Bricks[i, j].Box = new PictureBox();
                        Bricks[i, j].SetValues();
                        Bricks[i, j].Box.Top = x;
                        Bricks[i, j].Box.Left = y;
                        Bricks[i, j].Box.BorderStyle = BorderStyle.FixedSingle;
                        if (Bricks[i, j].BrickGift != null)
                        {
                            Bricks[i, j].BrickGift.SetValues();
                        }
                    }

                    y += 100;
                }
                x += 25;
                y = (Form1.formWidth - (Columns * 100)) / 2;
            }
        }

        public bool LevelComplete()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Bricks[i, j] != null)
                    {

                        if (Bricks[i, j].Box.Visible == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        public void GiftsCheck(Panel pl)
        {
            for (int k = 0; k < GiftCount; k++)
            {
                Gift gift = gifts[k];
                if (gift.Status == true)
                {
                    if (gift.Box.Visible == false)
                    {
                        pl.Controls.Add(gift.Box);
                        gift.Box.Visible = true;
                    }
                    if (gift.Box.Bounds.IntersectsWith(Racket.Box.Bounds))
                    {

                        gift.Box.Visible = false;
                        gift.Status = false;
                        gift.GiftTimer = new System.Timers.Timer();
                        gift.GiftTimer.Interval = 5000;

                        gift.GiftTimer.Elapsed += (sender, e) => OnTimedEvent(sender, e, gift);
                        ActivateGift(gift.Type);
                        gift.GiftTimer.Enabled = true;
                    }

                    if (gift.Box.Top > pl.Bottom)
                    {
                        gift.Box.Visible = false;
                        gift.Status = false;
                    }
                    else
                    {
                        gift.Box.Top += 2;
                    }

                }

            }
        }

        private void ActivateGift(GiftType type)
        {
            if (type == GiftType.FiredBall)
            {
                if (!DestroyMode)
                {
                    DestroyMode = true;
                    Ball.Box.Image = Properties.Resources.fball;
                }
                else
                {
                    Ball.Box.Image = Properties.Resources.ball;
                    DestroyMode = false;
                   
                }

            }
            else if (type == GiftType.RacketModify)
            {
                Deactivate(type);
            }

        }
  
        private void Deactivate(GiftType type)
        {
            if (Racket.Box.InvokeRequired)
            {
                DeactivateGift d = new DeactivateGift(ActivateGift);
                Racket.Box.Invoke(d, type);
            }
            else
            {
                Racket.Box.Width = Racket.Box.Width == 125 ? 210 : 125;
            }

        }
        public void DestroyBreaks()
        {
            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < Columns; j++)
                {
                    if (Bricks[i, j] != null)
                    {

                        if (Bricks[i, j].Box.Bounds.IntersectsWith(Ball.Box.Bounds) && Bricks[i, j].Box.Visible == true)
                        {
                            if (!DestroyMode)
                            {
                                if (Bricks[i, j].Type == BrickType.Silver)
                                {

                                    if (Bricks[i, j].BreakCount == 0)
                                    {
                                        Bricks[i, j].Box.Image = Properties.Resources.blueBrokenBrick;
                                        Bricks[i, j].BreakCount++;
                                        Ball.SpeedTop = -Ball.SpeedTop;

                                    }
                                    else if (Bricks[i, j].BreakCount == 1)
                                    {
                                        Bricks[i, j].Box.BackColor = Color.Indigo;
                                        Bricks[i, j].BreakCount++;
                                        Ball.SpeedTop = -Ball.SpeedTop;
                                    }
                                    else if (Bricks[i, j].BreakCount == 2)
                                    {
                                        Bricks[i, j].Box.Visible = false;
                                        Bricks[i, j].Box.Enabled = false;
                                        Bricks[i, j] = null;
                                        Ball.SpeedTop = -Ball.SpeedTop;
                                        Points++;

                                    }
                                }

                                else if (Bricks[i, j].Type == BrickType.Basic)
                                {
                                    Bricks[i, j].Box.Visible = false;
                                    Bricks[i, j].Box.Enabled = false;
                                    Ball.SpeedTop = -Ball.SpeedTop;
                                    Points++;
                                    if (Bricks[i, j].BrickGift != null)
                                    {
                                        SetGift(Bricks[i, j]);
                                    }
                                    Bricks[i, j] = null;
                                }
                            }
                            else
                            {
                                Bricks[i, j].Box.Visible = false;
                                Bricks[i, j].Box.Enabled = false;
                                Bricks[i, j] = null;
                                Points++;

                            }

                        }

                    }
                }
            }

        }
        private void SetGift(Brick brick)
        {
            brick.BrickGift.Status = true;
            brick.BrickGift.Box.Top = brick.Box.Top;
            brick.BrickGift.Box.Left = brick.Box.Left + brick.Box.Width / 4;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, Gift gift)
        {
            ActivateGift(gift.Type);
            gift.GiftTimer.Stop();
            gift.GiftTimer.Close();
        }

    }
}
