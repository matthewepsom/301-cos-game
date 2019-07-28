namespace assessment
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
            this.components = new System.ComponentModel.Container();
            this.pnlGallery = new System.Windows.Forms.Panel();
            this.tmrApe = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlGallery
            // 
            this.pnlGallery.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlGallery.Location = new System.Drawing.Point(12, 12);
            this.pnlGallery.Name = "pnlGallery";
            this.pnlGallery.Size = new System.Drawing.Size(500, 400);
            this.pnlGallery.TabIndex = 0;
            this.pnlGallery.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGallery_Paint);
            // 
            // tmrApe
            // 
            this.tmrApe.Enabled = true;
            this.tmrApe.Tick += new System.EventHandler(this.tmrApe_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 430);
            this.Controls.Add(this.pnlGallery);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGallery;
        private System.Windows.Forms.Timer tmrApe;
    }
}

