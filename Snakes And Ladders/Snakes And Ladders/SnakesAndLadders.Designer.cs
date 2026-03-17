namespace Snakes_And_Ladders
{
    partial class SnakesAndLadders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playerRollDiceBtn = new System.Windows.Forms.Button();
            this.oppRollDiceBtn = new System.Windows.Forms.Button();
            this.playerRollDiceTimer = new System.Windows.Forms.Timer(this.components);
            this.oppRollDiceTimer = new System.Windows.Forms.Timer(this.components);
            this.playerMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.oppMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.playerLbl = new System.Windows.Forms.Label();
            this.oppLbl = new System.Windows.Forms.Label();
            this.restartBtn = new System.Windows.Forms.Button();
            this.refreshScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.randomizeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerRollDiceBtn
            // 
            this.playerRollDiceBtn.BackColor = System.Drawing.Color.White;
            this.playerRollDiceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerRollDiceBtn.Location = new System.Drawing.Point(49, 729);
            this.playerRollDiceBtn.Name = "playerRollDiceBtn";
            this.playerRollDiceBtn.Size = new System.Drawing.Size(100, 100);
            this.playerRollDiceBtn.TabIndex = 0;
            this.playerRollDiceBtn.UseVisualStyleBackColor = false;
            this.playerRollDiceBtn.Click += new System.EventHandler(this.playerRollDiceBtn_Click);
            // 
            // oppRollDiceBtn
            // 
            this.oppRollDiceBtn.BackColor = System.Drawing.Color.White;
            this.oppRollDiceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oppRollDiceBtn.Location = new System.Drawing.Point(580, 729);
            this.oppRollDiceBtn.Name = "oppRollDiceBtn";
            this.oppRollDiceBtn.Size = new System.Drawing.Size(100, 100);
            this.oppRollDiceBtn.TabIndex = 1;
            this.oppRollDiceBtn.UseVisualStyleBackColor = false;
            // 
            // playerRollDiceTimer
            // 
            this.playerRollDiceTimer.Interval = 10;
            this.playerRollDiceTimer.Tick += new System.EventHandler(this.playerRollDiceTimer_Tick);
            // 
            // oppRollDiceTimer
            // 
            this.oppRollDiceTimer.Interval = 10;
            this.oppRollDiceTimer.Tick += new System.EventHandler(this.oppRollDiceTimer_Tick);
            // 
            // playerMoveTimer
            // 
            this.playerMoveTimer.Interval = 10;
            this.playerMoveTimer.Tick += new System.EventHandler(this.playerMoveTimer_Tick);
            // 
            // oppMoveTimer
            // 
            this.oppMoveTimer.Interval = 10;
            this.oppMoveTimer.Tick += new System.EventHandler(this.oppMoveTimer_Tick);
            // 
            // playerLbl
            // 
            this.playerLbl.AutoSize = true;
            this.playerLbl.Location = new System.Drawing.Point(78, 832);
            this.playerLbl.Name = "playerLbl";
            this.playerLbl.Size = new System.Drawing.Size(38, 20);
            this.playerLbl.TabIndex = 2;
            this.playerLbl.Text = "You";
            // 
            // oppLbl
            // 
            this.oppLbl.AutoSize = true;
            this.oppLbl.Location = new System.Drawing.Point(591, 832);
            this.oppLbl.Name = "oppLbl";
            this.oppLbl.Size = new System.Drawing.Size(80, 20);
            this.oppLbl.TabIndex = 3;
            this.oppLbl.Text = "Opponent";
            // 
            // restartBtn
            // 
            this.restartBtn.BackColor = System.Drawing.Color.White;
            this.restartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartBtn.Location = new System.Drawing.Point(709, 316);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(100, 100);
            this.restartBtn.TabIndex = 4;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = false;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // refreshScreenTimer
            // 
            this.refreshScreenTimer.Interval = 10;
            this.refreshScreenTimer.Tick += new System.EventHandler(this.refreshScreenTimer_Tick);
            // 
            // randomizeBtn
            // 
            this.randomizeBtn.BackColor = System.Drawing.Color.White;
            this.randomizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.randomizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomizeBtn.Location = new System.Drawing.Point(709, 429);
            this.randomizeBtn.Name = "randomizeBtn";
            this.randomizeBtn.Size = new System.Drawing.Size(100, 100);
            this.randomizeBtn.TabIndex = 5;
            this.randomizeBtn.Text = "Random";
            this.randomizeBtn.UseVisualStyleBackColor = false;
            this.randomizeBtn.Click += new System.EventHandler(this.randomizeBtn_Click);
            // 
            // SnakesAndLadders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(863, 874);
            this.Controls.Add(this.randomizeBtn);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.oppLbl);
            this.Controls.Add(this.playerLbl);
            this.Controls.Add(this.oppRollDiceBtn);
            this.Controls.Add(this.playerRollDiceBtn);
            this.Name = "SnakesAndLadders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakes And Ladders";
            this.Load += new System.EventHandler(this.SnakesAndLadders_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.onDraw);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playerRollDiceBtn;
        private System.Windows.Forms.Button oppRollDiceBtn;
        private System.Windows.Forms.Timer playerRollDiceTimer;
        private System.Windows.Forms.Timer oppRollDiceTimer;
        private System.Windows.Forms.Timer playerMoveTimer;
        private System.Windows.Forms.Timer oppMoveTimer;
        private System.Windows.Forms.Label playerLbl;
        private System.Windows.Forms.Label oppLbl;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.Timer refreshScreenTimer;
        private System.Windows.Forms.Button randomizeBtn;
    }
}

