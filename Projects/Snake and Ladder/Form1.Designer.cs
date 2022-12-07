namespace SnakesLadders
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DiceBbox = new System.Windows.Forms.PictureBox();
            this.MainGrid = new System.Windows.Forms.PictureBox();
            this.rollPbox = new System.Windows.Forms.PictureBox();
            this.PlayerTurnlbl = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BluePB = new System.Windows.Forms.PictureBox();
            this.OrangePB = new System.Windows.Forms.PictureBox();
            this.bluePoint = new System.Windows.Forms.PictureBox();
            this.orangePoint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DiceBbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollPbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BluePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangePoint)).BeginInit();
            this.SuspendLayout();
            // 
            // DiceBbox
            // 
            this.DiceBbox.BackColor = System.Drawing.SystemColors.Control;
            this.DiceBbox.Location = new System.Drawing.Point(677, 117);
            this.DiceBbox.Name = "DiceBbox";
            this.DiceBbox.Size = new System.Drawing.Size(122, 100);
            this.DiceBbox.TabIndex = 0;
            this.DiceBbox.TabStop = false;
            this.DiceBbox.Click += new System.EventHandler(this.DiceBbox_Click);
            // 
            // MainGrid
            // 
            this.MainGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainGrid.BackgroundImage")));
            this.MainGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainGrid.Location = new System.Drawing.Point(-1, 0);
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.Size = new System.Drawing.Size(645, 438);
            this.MainGrid.TabIndex = 1;
            this.MainGrid.TabStop = false;
            this.MainGrid.Click += new System.EventHandler(this.MainGrid_Click);
            // 
            // rollPbox
            // 
            this.rollPbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rollPbox.BackgroundImage")));
            this.rollPbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rollPbox.Location = new System.Drawing.Point(667, 303);
            this.rollPbox.Name = "rollPbox";
            this.rollPbox.Size = new System.Drawing.Size(121, 93);
            this.rollPbox.TabIndex = 2;
            this.rollPbox.TabStop = false;
            this.rollPbox.Click += new System.EventHandler(this.rollPbox_Click);
            // 
            // PlayerTurnlbl
            // 
            this.PlayerTurnlbl.AutoSize = true;
            this.PlayerTurnlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PlayerTurnlbl.Location = new System.Drawing.Point(674, 92);
            this.PlayerTurnlbl.Name = "PlayerTurnlbl";
            this.PlayerTurnlbl.Size = new System.Drawing.Size(81, 13);
            this.PlayerTurnlbl.TabIndex = 3;
            this.PlayerTurnlbl.Text = "Player one turn!\r\n";
            // 
            // BluePB
            // 
            this.BluePB.Image = ((System.Drawing.Image)(resources.GetObject("BluePB.Image")));
            this.BluePB.Location = new System.Drawing.Point(677, 0);
            this.BluePB.Name = "BluePB";
            this.BluePB.Size = new System.Drawing.Size(32, 50);
            this.BluePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BluePB.TabIndex = 4;
            this.BluePB.TabStop = false;
            this.BluePB.Click += new System.EventHandler(this.BluePB_Click);
            // 
            // OrangePB
            // 
            this.OrangePB.Image = ((System.Drawing.Image)(resources.GetObject("OrangePB.Image")));
            this.OrangePB.Location = new System.Drawing.Point(731, 0);
            this.OrangePB.Name = "OrangePB";
            this.OrangePB.Size = new System.Drawing.Size(32, 50);
            this.OrangePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OrangePB.TabIndex = 5;
            this.OrangePB.TabStop = false;
            // 
            // bluePoint
            // 
            this.bluePoint.Image = ((System.Drawing.Image)(resources.GetObject("bluePoint.Image")));
            this.bluePoint.Location = new System.Drawing.Point(667, 402);
            this.bluePoint.Name = "bluePoint";
            this.bluePoint.Size = new System.Drawing.Size(16, 36);
            this.bluePoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bluePoint.TabIndex = 6;
            this.bluePoint.TabStop = false;
            // 
            // orangePoint
            // 
            this.orangePoint.Image = ((System.Drawing.Image)(resources.GetObject("orangePoint.Image")));
            this.orangePoint.Location = new System.Drawing.Point(772, 402);
            this.orangePoint.Name = "orangePoint";
            this.orangePoint.Size = new System.Drawing.Size(16, 36);
            this.orangePoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.orangePoint.TabIndex = 7;
            this.orangePoint.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.orangePoint);
            this.Controls.Add(this.bluePoint);
            this.Controls.Add(this.OrangePB);
            this.Controls.Add(this.BluePB);
            this.Controls.Add(this.PlayerTurnlbl);
            this.Controls.Add(this.rollPbox);
            this.Controls.Add(this.MainGrid);
            this.Controls.Add(this.DiceBbox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DiceBbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollPbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BluePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangePoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DiceBbox;
        private System.Windows.Forms.PictureBox MainGrid;
        private System.Windows.Forms.PictureBox rollPbox;
        private System.Windows.Forms.Label PlayerTurnlbl;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox BluePB;
        private System.Windows.Forms.PictureBox OrangePB;
        private System.Windows.Forms.PictureBox bluePoint;
        private System.Windows.Forms.PictureBox orangePoint;
    }
}

