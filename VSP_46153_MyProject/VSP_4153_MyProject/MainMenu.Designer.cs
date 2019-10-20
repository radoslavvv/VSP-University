namespace VSP_4153_MyProject
{
    partial class MainMenu
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
            this.EasyModeButton = new System.Windows.Forms.Button();
            this.MediumModeButton = new System.Windows.Forms.Button();
            this.HardModeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EasyModeButton
            // 
            this.EasyModeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EasyModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyModeButton.Location = new System.Drawing.Point(220, 189);
            this.EasyModeButton.Name = "EasyModeButton";
            this.EasyModeButton.Size = new System.Drawing.Size(200, 75);
            this.EasyModeButton.TabIndex = 0;
            this.EasyModeButton.Text = "4x4 - Easy";
            this.EasyModeButton.UseVisualStyleBackColor = false;
            this.EasyModeButton.Click += new System.EventHandler(this.EasyModeButton_Click);
            // 
            // MediumModeButton
            // 
            this.MediumModeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MediumModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumModeButton.Location = new System.Drawing.Point(220, 280);
            this.MediumModeButton.Name = "MediumModeButton";
            this.MediumModeButton.Size = new System.Drawing.Size(200, 75);
            this.MediumModeButton.TabIndex = 1;
            this.MediumModeButton.Text = "5x5 - Medium";
            this.MediumModeButton.UseVisualStyleBackColor = false;
            this.MediumModeButton.Click += new System.EventHandler(this.MediumModeButton_Click);
            // 
            // HardModeButton
            // 
            this.HardModeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.HardModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardModeButton.Location = new System.Drawing.Point(220, 371);
            this.HardModeButton.Name = "HardModeButton";
            this.HardModeButton.Size = new System.Drawing.Size(200, 75);
            this.HardModeButton.TabIndex = 2;
            this.HardModeButton.Text = "8x8 - Hard";
            this.HardModeButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 65.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 98);
            this.label1.TabIndex = 3;
            this.label1.Text = "MEMORy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Please select your game mode below:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(630, 457);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HardModeButton);
            this.Controls.Add(this.MediumModeButton);
            this.Controls.Add(this.EasyModeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.Text = "MEMORy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EasyModeButton;
        private System.Windows.Forms.Button MediumModeButton;
        private System.Windows.Forms.Button HardModeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}