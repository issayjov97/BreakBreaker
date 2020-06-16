using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {

        private Game game;
        private Ball ball2;
        private Racket racket;
        public const int formWidth = 900;
        public const int formHeight = 600;

        public Form1(Game game = null)
        {
            InitializeComponent();
            this.Width = formWidth;
            this.Height = formHeight;
            this.FormBorderStyle = FormBorderStyle.None;
            ball2 = new Ball(BallType.Basic, 4, 4);
            racket = new Racket();
            this.game = game;
            if (this.game == null)
            {
                Level level = new Level();
                this.game = new Game(level);
            }
            this.game.level.Ball = ball2;
            this.game.level.Racket = racket;
            SetBall();
            playground.Controls.Add(ball2.Box);
            playground.Controls.Add(racket.Box);
            racket.Box.Top = playground.Bottom - (playground.Bottom / 10);
            if (Game.Loaded)
            {
                this.game.LoadGame();
            }
            else
            {
                this.game.StartNewGame();
            }
            Draw();
            labelStart.Text = "Press Enter to start level " + this.game.currentLevel.ToString() + "\n Press Esc to open Menu"; ;
        }

        private void Draw()
        {
            for (int i = 0; i < game.level.Rows; i++)
            {
                for (int j = 0; j < game.level.Columns; j++)
                {
                    if (game.level[i, j] != null)
                    {
                        playground.Controls.Add(game.level[i, j].Box);
                    }
                }
            }

        }


        private void SetBall()
        {
            ball2.Box.Left = playground.Width / 2;
            ball2.Box.Top = playground.Height / 2;
            ball2.SpeedLeft = Math.Abs(ball2.SpeedLeft);
            ball2.SpeedTop = Math.Abs(ball2.SpeedTop);
        }

        private void SetValues()
        {
            levelLab.Text = "Level: " + game.currentLevel.ToString();
            scoreLabel.Text = "Score: " + game.level.Points.ToString();
            livesLabel.Text = "Lives: " + game.Lives;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {

                timer1.Start();
                labelStart.Visible = false;
                statusStrip1.Visible = true;

            }
            else if (keyData == Keys.Escape)
            {

                timer1.Stop();
                EscMenu menu = new EscMenu(game);
                menu.ShowDialog();
                labelStart.Visible = true;
                labelStart.Text = "Press Enter to Continue";

            }
            else if (keyData == Keys.D)
            {
                Application.Restart();
                Environment.Exit(0);

            }

            return base.ProcessDialogKey(keyData);
        }

        private void Platform_MouseMove(object sender, MouseEventArgs e)
        {

            racket.Box.Left = e.X - (racket.Box.Width / 2);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {

            ball2.Box.Left += ball2.SpeedLeft;
            ball2.Box.Top += ball2.SpeedTop;


            if (ball2.Box.Bounds.IntersectsWith(racket.Box.Bounds))
            {
                ball2.SpeedTop = -ball2.SpeedTop;


            }
            else if (ball2.Box.Left <= playground.Left)
            {
                ball2.SpeedLeft = -ball2.SpeedLeft;
            }
            else if (ball2.Box.Right >= playground.Right)
            {
                ball2.SpeedLeft = -ball2.SpeedLeft;
            }
            else if (ball2.Box.Top <= playground.Top)
            {
                ball2.SpeedTop = -ball2.SpeedTop;
            }
            else if (ball2.Box.Bottom > playground.Bottom)
            {
                if (game.Lives == 1)
                {
                    timer1.Enabled = false;
                    labelStart.Visible = true;
                    statusStrip1.Visible = false;
                    labelStart.Text = "Game over. Press D to strat new game";


                }
                else
                {
                    game.Lives--;
                    SetBall();
                }

            }

            if (game.CheckLevel())
            {
                Game.Loaded = false;
                labelStart.Visible = true;
                game.currentLevel++;
                timer1.Stop();
                if (game.NextLevel())
                {
                    statusStrip1.Visible = false;
                    labelStart.Text = "Press Enter to start level " + game.currentLevel.ToString() + "\n Press Esc to open Menu";

                    SetBall();
                    Draw();
                }
                else
                {
                    labelStart.Text = "Game was completed.. Press D to strat new game";
                }

            }
            else
            {
                game.level.DestroyBreaks();
                game.level.GiftsCheck(playground);
            }
            SetValues();
        }
    }
}
