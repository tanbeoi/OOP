namespace TANTHEDIVER
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BG = new PictureBox();
            Player = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)BG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // BG
            // 
            BG.Image = Properties.Resources.CombinedBG;
            BG.Location = new Point(-10, -40);
            BG.Name = "BG";
            BG.Size = new Size(2000, 750);
            BG.SizeMode = PictureBoxSizeMode.AutoSize;
            BG.TabIndex = 0;
            BG.TabStop = false;
            // 
            // Player
            // 
            Player.Image = Properties.Resources.player_idle;
            Player.Location = new Point(453, 255);
            Player.Name = "Player";
            Player.Size = new Size(160, 160);
            Player.TabIndex = 1;
            Player.TabStop = false;
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += mainGameTimer;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 703);
            Controls.Add(Player);
            Controls.Add(BG);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1000, 750);
            MinimumSize = new Size(1000, 750);
            Name = "Form1";
            Text = "TAN THE DIVER";
            Load += Form1_Load;
            KeyDown += keyisdown;
            ((System.ComponentModel.ISupportInitialize)BG).EndInit();
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox BG;
        private PictureBox Player;
        private System.Windows.Forms.Timer gameTimer;
    }
}
