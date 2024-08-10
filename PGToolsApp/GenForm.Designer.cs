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

            if (disposing && (BackBuffer != null))
            {
                BackBuffer.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelBtns = new System.Windows.Forms.Panel();
            this.pbBitmap = new System.Windows.Forms.PictureBox();
            this.panelBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBitmap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(19, 52);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(101, 35);
            this.btnRedraw.TabIndex = 2;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(19, 93);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 35);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelBtns
            // 
            this.panelBtns.Controls.Add(this.btnSave);
            this.panelBtns.Controls.Add(this.btnExit);
            this.panelBtns.Controls.Add(this.btnRedraw);
            this.panelBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBtns.Location = new System.Drawing.Point(256, 0);
            this.panelBtns.Margin = new System.Windows.Forms.Padding(0);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(144, 256);
            this.panelBtns.TabIndex = 4;
            // 
            // pbBitmap
            // 
            this.pbBitmap.Location = new System.Drawing.Point(0, 0);
            this.pbBitmap.Margin = new System.Windows.Forms.Padding(0);
            this.pbBitmap.Name = "pbBitmap";
            this.pbBitmap.Size = new System.Drawing.Size(256, 256);
            this.pbBitmap.TabIndex = 5;
            this.pbBitmap.TabStop = false;
            // 
            // GenForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(400, 256);
            this.Controls.Add(this.pbBitmap);
            this.Controls.Add(this.panelBtns);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GenForm";
            this.Text = "PGTools";
            this.Load += new System.EventHandler(this.GenForm_Load);
            this.panelBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBitmap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelBtns;
        private System.Windows.Forms.PictureBox pbBitmap;
    }
}