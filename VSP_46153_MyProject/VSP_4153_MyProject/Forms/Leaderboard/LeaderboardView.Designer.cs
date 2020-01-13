namespace VSP_4153_MyProject.Forms
{
    partial class LeaderboardView
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
            this.leaderboardHeader = new System.Windows.Forms.Label();
            this.leaderboardListView = new System.Windows.Forms.ListView();
            this.leaderboardPanel = new System.Windows.Forms.Panel();
            this.easyButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leaderboardHeader
            // 
            this.leaderboardHeader.AutoSize = true;
            this.leaderboardHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardHeader.Location = new System.Drawing.Point(115, 20);
            this.leaderboardHeader.Name = "leaderboardHeader";
            this.leaderboardHeader.Size = new System.Drawing.Size(210, 39);
            this.leaderboardHeader.TabIndex = 0;
            this.leaderboardHeader.Text = "Leaderboard";
            // 
            // leaderboardListView
            // 
            this.leaderboardListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardListView.HideSelection = false;
            this.leaderboardListView.Location = new System.Drawing.Point(50, 90);
            this.leaderboardListView.Name = "leaderboardListView";
            this.leaderboardListView.Size = new System.Drawing.Size(330, 302);
            this.leaderboardListView.TabIndex = 1;
            this.leaderboardListView.UseCompatibleStateImageBehavior = false;
            this.leaderboardListView.View = System.Windows.Forms.View.List;
            // 
            // leaderboardPanel
            // 
            this.leaderboardPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.leaderboardPanel.Location = new System.Drawing.Point(38, 80);
            this.leaderboardPanel.Name = "leaderboardPanel";
            this.leaderboardPanel.Size = new System.Drawing.Size(353, 324);
            this.leaderboardPanel.TabIndex = 2;
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.easyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(419, 80);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(91, 37);
            this.easyButton.TabIndex = 3;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // mediumButton
            // 
            this.mediumButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumButton.Location = new System.Drawing.Point(419, 135);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(91, 37);
            this.mediumButton.TabIndex = 4;
            this.mediumButton.Text = "Medium";
            this.mediumButton.UseVisualStyleBackColor = true;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardButton.Location = new System.Drawing.Point(419, 190);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(91, 37);
            this.hardButton.TabIndex = 5;
            this.hardButton.Text = "Hard";
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // LeaderboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 416);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.leaderboardListView);
            this.Controls.Add(this.leaderboardHeader);
            this.Controls.Add(this.leaderboardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LeaderboardView";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.LeaderboardView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label leaderboardHeader;
        private System.Windows.Forms.ListView leaderboardListView;
        private System.Windows.Forms.Panel leaderboardPanel;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button hardButton;
    }
}