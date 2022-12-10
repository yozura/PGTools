namespace PGToolsApp
{
    partial class OptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.gbPixelWidth = new System.Windows.Forms.GroupBox();
            this.rbPixelWidth3 = new System.Windows.Forms.RadioButton();
            this.rbPixelWidth2 = new System.Windows.Forms.RadioButton();
            this.rbPixelWidth1 = new System.Windows.Forms.RadioButton();
            this.gbPixelHeight = new System.Windows.Forms.GroupBox();
            this.rbPixelHeight3 = new System.Windows.Forms.RadioButton();
            this.rbPixelHeight2 = new System.Windows.Forms.RadioButton();
            this.rbPixelHeight1 = new System.Windows.Forms.RadioButton();
            this.ttPixelHeight = new System.Windows.Forms.ToolTip(this.components);
            this.ttPixelWidth = new System.Windows.Forms.ToolTip(this.components);
            this.gbPixelWidth.SuspendLayout();
            this.gbPixelHeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPixelWidth
            // 
            this.gbPixelWidth.Controls.Add(this.rbPixelWidth3);
            this.gbPixelWidth.Controls.Add(this.rbPixelWidth2);
            this.gbPixelWidth.Controls.Add(this.rbPixelWidth1);
            this.gbPixelWidth.Location = new System.Drawing.Point(12, 12);
            this.gbPixelWidth.Name = "gbPixelWidth";
            this.gbPixelWidth.Size = new System.Drawing.Size(157, 50);
            this.gbPixelWidth.TabIndex = 0;
            this.gbPixelWidth.TabStop = false;
            this.gbPixelWidth.Text = "Pixel Width";
            this.ttPixelWidth.SetToolTip(this.gbPixelWidth, "Determines the width size of the pixels being drawn in the window. default is 5");
            // 
            // rbPixelWidth3
            // 
            this.rbPixelWidth3.AutoSize = true;
            this.rbPixelWidth3.Location = new System.Drawing.Point(97, 20);
            this.rbPixelWidth3.Name = "rbPixelWidth3";
            this.rbPixelWidth3.Size = new System.Drawing.Size(35, 16);
            this.rbPixelWidth3.TabIndex = 2;
            this.rbPixelWidth3.Text = "10";
            this.rbPixelWidth3.UseVisualStyleBackColor = true;
            this.rbPixelWidth3.CheckedChanged += new System.EventHandler(this.rbPixelWidth3_CheckedChanged);
            // 
            // rbPixelWidth2
            // 
            this.rbPixelWidth2.AutoSize = true;
            this.rbPixelWidth2.Location = new System.Drawing.Point(62, 20);
            this.rbPixelWidth2.Name = "rbPixelWidth2";
            this.rbPixelWidth2.Size = new System.Drawing.Size(29, 16);
            this.rbPixelWidth2.TabIndex = 1;
            this.rbPixelWidth2.Text = "5";
            this.rbPixelWidth2.UseVisualStyleBackColor = true;
            this.rbPixelWidth2.CheckedChanged += new System.EventHandler(this.rbPixelWidth2_CheckedChanged);
            // 
            // rbPixelWidth1
            // 
            this.rbPixelWidth1.AutoSize = true;
            this.rbPixelWidth1.Location = new System.Drawing.Point(27, 20);
            this.rbPixelWidth1.Name = "rbPixelWidth1";
            this.rbPixelWidth1.Size = new System.Drawing.Size(29, 16);
            this.rbPixelWidth1.TabIndex = 0;
            this.rbPixelWidth1.Text = "1";
            this.rbPixelWidth1.UseVisualStyleBackColor = true;
            this.rbPixelWidth1.CheckedChanged += new System.EventHandler(this.rbPixelWidth1_CheckedChanged);
            // 
            // gbPixelHeight
            // 
            this.gbPixelHeight.Controls.Add(this.rbPixelHeight3);
            this.gbPixelHeight.Controls.Add(this.rbPixelHeight2);
            this.gbPixelHeight.Controls.Add(this.rbPixelHeight1);
            this.gbPixelHeight.Location = new System.Drawing.Point(175, 12);
            this.gbPixelHeight.Name = "gbPixelHeight";
            this.gbPixelHeight.Size = new System.Drawing.Size(157, 50);
            this.gbPixelHeight.TabIndex = 3;
            this.gbPixelHeight.TabStop = false;
            this.gbPixelHeight.Text = "Pixel Height";
            this.ttPixelHeight.SetToolTip(this.gbPixelHeight, "Determines the height size of the pixels being drawn in the window. default is 5");
            // 
            // rbPixelHeight3
            // 
            this.rbPixelHeight3.AutoSize = true;
            this.rbPixelHeight3.Location = new System.Drawing.Point(97, 20);
            this.rbPixelHeight3.Name = "rbPixelHeight3";
            this.rbPixelHeight3.Size = new System.Drawing.Size(35, 16);
            this.rbPixelHeight3.TabIndex = 2;
            this.rbPixelHeight3.Text = "10";
            this.rbPixelHeight3.UseVisualStyleBackColor = true;
            this.rbPixelHeight3.CheckedChanged += new System.EventHandler(this.rbPixelHeight3_CheckedChanged);
            // 
            // rbPixelHeight2
            // 
            this.rbPixelHeight2.AutoSize = true;
            this.rbPixelHeight2.Location = new System.Drawing.Point(62, 20);
            this.rbPixelHeight2.Name = "rbPixelHeight2";
            this.rbPixelHeight2.Size = new System.Drawing.Size(29, 16);
            this.rbPixelHeight2.TabIndex = 1;
            this.rbPixelHeight2.Text = "5";
            this.rbPixelHeight2.UseVisualStyleBackColor = true;
            this.rbPixelHeight2.CheckedChanged += new System.EventHandler(this.rbPixelHeight2_CheckedChanged);
            // 
            // rbPixelHeight1
            // 
            this.rbPixelHeight1.AutoSize = true;
            this.rbPixelHeight1.Location = new System.Drawing.Point(27, 20);
            this.rbPixelHeight1.Name = "rbPixelHeight1";
            this.rbPixelHeight1.Size = new System.Drawing.Size(29, 16);
            this.rbPixelHeight1.TabIndex = 0;
            this.rbPixelHeight1.Text = "1";
            this.rbPixelHeight1.UseVisualStyleBackColor = true;
            this.rbPixelHeight1.CheckedChanged += new System.EventHandler(this.rbPixelHeight1_CheckedChanged);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 77);
            this.Controls.Add(this.gbPixelHeight);
            this.Controls.Add(this.gbPixelWidth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.gbPixelWidth.ResumeLayout(false);
            this.gbPixelWidth.PerformLayout();
            this.gbPixelHeight.ResumeLayout(false);
            this.gbPixelHeight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPixelWidth;
        private System.Windows.Forms.RadioButton rbPixelWidth1;
        private System.Windows.Forms.RadioButton rbPixelWidth2;
        private System.Windows.Forms.RadioButton rbPixelWidth3;
        private System.Windows.Forms.GroupBox gbPixelHeight;
        private System.Windows.Forms.RadioButton rbPixelHeight3;
        private System.Windows.Forms.RadioButton rbPixelHeight2;
        private System.Windows.Forms.RadioButton rbPixelHeight1;
        private System.Windows.Forms.ToolTip ttPixelHeight;
        private System.Windows.Forms.ToolTip ttPixelWidth;
    }
}