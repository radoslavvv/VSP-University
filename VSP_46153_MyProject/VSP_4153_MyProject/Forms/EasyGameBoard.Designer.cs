namespace VSP_4153_MyProject
{
    partial class EasyGameBoard
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
            this.GameBoard = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.panel42 = new System.Windows.Forms.Panel();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.ScoreValue = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.ReturnHomeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GameBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.GameBoard.Controls.Add(this.panel44);
            this.GameBoard.Controls.Add(this.panel43);
            this.GameBoard.Controls.Add(this.panel42);
            this.GameBoard.Controls.Add(this.panel41);
            this.GameBoard.Controls.Add(this.panel34);
            this.GameBoard.Controls.Add(this.panel33);
            this.GameBoard.Controls.Add(this.panel32);
            this.GameBoard.Controls.Add(this.panel31);
            this.GameBoard.Controls.Add(this.panel24);
            this.GameBoard.Controls.Add(this.panel23);
            this.GameBoard.Controls.Add(this.panel22);
            this.GameBoard.Controls.Add(this.panel21);
            this.GameBoard.Controls.Add(this.panel14);
            this.GameBoard.Controls.Add(this.panel13);
            this.GameBoard.Controls.Add(this.panel12);
            this.GameBoard.Controls.Add(this.panel11);
            this.GameBoard.Location = new System.Drawing.Point(97, 105);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(437, 436);
            this.GameBoard.TabIndex = 0;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.Color.LightGray;
            this.panel44.Location = new System.Drawing.Point(331, 331);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(95, 95);
            this.panel44.TabIndex = 15;
            this.panel44.Tag = "GameBlock";
            this.panel44.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel43
            // 
            this.panel43.BackColor = System.Drawing.Color.LightGray;
            this.panel43.Location = new System.Drawing.Point(225, 331);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(95, 95);
            this.panel43.TabIndex = 14;
            this.panel43.Tag = "GameBlock";
            this.panel43.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel42
            // 
            this.panel42.BackColor = System.Drawing.Color.LightGray;
            this.panel42.Location = new System.Drawing.Point(119, 331);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(95, 95);
            this.panel42.TabIndex = 13;
            this.panel42.Tag = "GameBlock";
            this.panel42.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel41
            // 
            this.panel41.BackColor = System.Drawing.Color.LightGray;
            this.panel41.Location = new System.Drawing.Point(13, 331);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(95, 95);
            this.panel41.TabIndex = 12;
            this.panel41.Tag = "GameBlock";
            this.panel41.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.LightGray;
            this.panel34.Location = new System.Drawing.Point(331, 225);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(95, 95);
            this.panel34.TabIndex = 11;
            this.panel34.Tag = "GameBlock";
            this.panel34.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.LightGray;
            this.panel33.Location = new System.Drawing.Point(225, 225);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(95, 95);
            this.panel33.TabIndex = 10;
            this.panel33.Tag = "GameBlock";
            this.panel33.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.LightGray;
            this.panel32.Location = new System.Drawing.Point(119, 225);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(95, 95);
            this.panel32.TabIndex = 9;
            this.panel32.Tag = "GameBlock";
            this.panel32.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.LightGray;
            this.panel31.Location = new System.Drawing.Point(13, 225);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(95, 95);
            this.panel31.TabIndex = 8;
            this.panel31.Tag = "GameBlock";
            this.panel31.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.LightGray;
            this.panel24.Location = new System.Drawing.Point(331, 119);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(95, 95);
            this.panel24.TabIndex = 7;
            this.panel24.Tag = "GameBlock";
            this.panel24.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.LightGray;
            this.panel23.Location = new System.Drawing.Point(225, 119);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(95, 95);
            this.panel23.TabIndex = 6;
            this.panel23.Tag = "GameBlock";
            this.panel23.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.LightGray;
            this.panel22.Location = new System.Drawing.Point(119, 119);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(95, 95);
            this.panel22.TabIndex = 5;
            this.panel22.Tag = "GameBlock";
            this.panel22.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.LightGray;
            this.panel21.Location = new System.Drawing.Point(13, 119);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(95, 95);
            this.panel21.TabIndex = 4;
            this.panel21.Tag = "GameBlock";
            this.panel21.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.LightGray;
            this.panel14.Location = new System.Drawing.Point(331, 13);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(95, 95);
            this.panel14.TabIndex = 3;
            this.panel14.Tag = "GameBlock";
            this.panel14.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.LightGray;
            this.panel13.Location = new System.Drawing.Point(225, 13);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(95, 95);
            this.panel13.TabIndex = 2;
            this.panel13.Tag = "GameBlock";
            this.panel13.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.LightGray;
            this.panel12.Location = new System.Drawing.Point(119, 13);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(95, 95);
            this.panel12.TabIndex = 1;
            this.panel12.Tag = "GameBlock";
            this.panel12.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.LightGray;
            this.panel11.Location = new System.Drawing.Point(13, 13);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(95, 95);
            this.panel11.TabIndex = 0;
            this.panel11.Tag = "GameBlock";
            this.panel11.Click += new System.EventHandler(this.GameBlockClick);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(115, 600);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(220, 35);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ScoreValue
            // 
            this.ScoreValue.AutoSize = true;
            this.ScoreValue.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreValue.Location = new System.Drawing.Point(340, 560);
            this.ScoreValue.Name = "ScoreValue";
            this.ScoreValue.Size = new System.Drawing.Size(24, 24);
            this.ScoreValue.TabIndex = 2;
            this.ScoreValue.Text = "0";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(255, 560);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(74, 24);
            this.ScoreLabel.TabIndex = 3;
            this.ScoreLabel.Text = "Score:";
            // 
            // ReturnHomeButton
            // 
            this.ReturnHomeButton.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnHomeButton.Location = new System.Drawing.Point(366, 600);
            this.ReturnHomeButton.Name = "ReturnHomeButton";
            this.ReturnHomeButton.Size = new System.Drawing.Size(150, 35);
            this.ReturnHomeButton.TabIndex = 4;
            this.ReturnHomeButton.Text = "Home";
            this.ReturnHomeButton.UseVisualStyleBackColor = true;
            this.ReturnHomeButton.Click += new System.EventHandler(this.ReturnHomeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(255, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "4x4 - Easy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 57);
            this.label1.TabIndex = 11;
            this.label1.Text = "MEMORy";
            // 
            // EasyGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 647);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReturnHomeButton);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.ScoreValue);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.GameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EasyGameBoard";
            this.Text = "4x4 Board";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EasyGameBoard_FormClosed);
            this.GameBoard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GameBoard;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.Panel panel43;
        private System.Windows.Forms.Panel panel42;
        private System.Windows.Forms.Panel panel41;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label ScoreValue;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Button ReturnHomeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

