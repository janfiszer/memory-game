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
            this.SuspendLayout();
            // 
            // toMenu_button
            // 
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
            this.label1.Location = new System.Drawing.Point(226, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 181);
            this.label1.TabIndex = 52;
            this.label1.Text = "label1";
            // 
            // Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toMenu_button);
            this.Name = "Ranking";
            this.Text = "Ranking";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toMenu_button;
        private System.Windows.Forms.Label label1;
    }
}