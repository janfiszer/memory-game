namespace memory
{
    partial class Ranking
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
            this.toMenu_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toMenu_button
            // 
            this.toMenu_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toMenu_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toMenu_button.Location = new System.Drawing.Point(12, 399);
            this.toMenu_button.Name = "toMenu_button";
            this.toMenu_button.Size = new System.Drawing.Size(134, 39);
            this.toMenu_button.TabIndex = 51;
            this.toMenu_button.Text = "MENU";
            this.toMenu_button.UseVisualStyleBackColor = true;
            this.toMenu_button.Click += new System.EventHandler(this.toMenu_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Location = new System.Drawing.Point(273, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 222);
            this.label1.TabIndex = 52;
            this.label1.Text = "no players yet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(276, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 23);
            this.label4.TabIndex = 54;
            this.label4.Text = "BEST PLAYERS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 449);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toMenu_button);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Ranking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ranking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toMenu_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}