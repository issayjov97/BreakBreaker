namespace BrickBreaker
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playground = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.scoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.levelLab = new System.Windows.Forms.ToolStripStatusLabel();
            this.livesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStart = new System.Windows.Forms.Label();
            this.playground.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // playground
            // 
            this.playground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playground.BackgroundImage")));
            this.playground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playground.Controls.Add(this.statusStrip1);
            this.playground.Controls.Add(this.labelStart);
            this.playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground.Location = new System.Drawing.Point(0, 0);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(800, 450);
            this.playground.TabIndex = 0;
            this.playground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Platform_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scoreLabel,
            this.levelLab,
            this.livesLabel,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(152, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // levelLab
            // 
            this.levelLab.Name = "levelLab";
            this.levelLab.Size = new System.Drawing.Size(0, 17);
            // 
            // livesLabel
            // 
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(135, 17);
            this.toolStripStatusLabel1.Text = "Press ESC to open Menu";
            // 
            // labelStart
            // 
            this.labelStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStart.Location = new System.Drawing.Point(0, 395);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(800, 55);
            this.labelStart.TabIndex = 1;
            this.labelStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playground);
            this.Name = "Form1";
            this.Text = "Form1";
            this.playground.ResumeLayout(false);
            this.playground.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playground;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel scoreLabel;
        private System.Windows.Forms.ToolStripStatusLabel levelLab;
        private System.Windows.Forms.ToolStripStatusLabel livesLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

