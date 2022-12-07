namespace PGToolsApp
{
    partial class GenForm
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
            this.panelBitmap = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelBitmap
            // 
            this.panelBitmap.Location = new System.Drawing.Point(12, 12);
            this.panelBitmap.Name = "panelBitmap";
            this.panelBitmap.Size = new System.Drawing.Size(397, 311);
            this.panelBitmap.TabIndex = 0;
            this.panelBitmap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBitmap_Paint);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(415, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(415, 53);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(101, 35);
            this.btnRedraw.TabIndex = 2;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(415, 94);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 35);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 335);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelBitmap);
            this.Name = "GenForm";
            this.Text = "PGTools";
            this.Load += new System.EventHandler(this.GenForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBitmap;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Button btnExit;
    }
}