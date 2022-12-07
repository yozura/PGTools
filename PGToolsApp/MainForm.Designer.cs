namespace PGToolsApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbAlgo = new System.Windows.Forms.ComboBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnOpt = new System.Windows.Forms.Button();
            this.panelBSP = new System.Windows.Forms.Panel();
            this.panelCA = new System.Windows.Forms.Panel();
            this.lbCARunCount = new System.Windows.Forms.Label();
            this.tbCARunCount = new System.Windows.Forms.TextBox();
            this.lbCAWallRatio = new System.Windows.Forms.Label();
            this.tbCAWallRatio = new System.Windows.Forms.TextBox();
            this.lbCAHeight = new System.Windows.Forms.Label();
            this.tbCAHeight = new System.Windows.Forms.TextBox();
            this.lbCAWidth = new System.Windows.Forms.Label();
            this.tbCAWidth = new System.Windows.Forms.TextBox();
            this.lbBSPCondition1 = new System.Windows.Forms.Label();
            this.tbBSPCondition1 = new System.Windows.Forms.TextBox();
            this.panelPN = new System.Windows.Forms.Panel();
            this.lbPNCondition1 = new System.Windows.Forms.Label();
            this.tbPNCondition1 = new System.Windows.Forms.TextBox();
            this.panelBSP.SuspendLayout();
            this.panelCA.SuspendLayout();
            this.panelPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAlgo
            // 
            this.cbAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgo.FormattingEnabled = true;
            this.cbAlgo.Location = new System.Drawing.Point(12, 12);
            this.cbAlgo.Name = "cbAlgo";
            this.cbAlgo.Size = new System.Drawing.Size(338, 20);
            this.cbAlgo.TabIndex = 0;
            this.cbAlgo.SelectedIndexChanged += new System.EventHandler(this.cbAlgo_SelectedIndexChanged);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(13, 337);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(338, 35);
            this.btnGen.TabIndex = 4;
            this.btnGen.Text = "Generation Start";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnOpt
            // 
            this.btnOpt.Location = new System.Drawing.Point(13, 296);
            this.btnOpt.Name = "btnOpt";
            this.btnOpt.Size = new System.Drawing.Size(338, 35);
            this.btnOpt.TabIndex = 5;
            this.btnOpt.Text = "Options";
            this.btnOpt.UseVisualStyleBackColor = true;
            this.btnOpt.Click += new System.EventHandler(this.btnOpt_Click);
            // 
            // panelBSP
            // 
            this.panelBSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBSP.Controls.Add(this.lbBSPCondition1);
            this.panelBSP.Controls.Add(this.tbBSPCondition1);
            this.panelBSP.Location = new System.Drawing.Point(12, 38);
            this.panelBSP.Name = "panelBSP";
            this.panelBSP.Size = new System.Drawing.Size(338, 252);
            this.panelBSP.TabIndex = 6;
            // 
            // panelCA
            // 
            this.panelCA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCA.Controls.Add(this.lbCARunCount);
            this.panelCA.Controls.Add(this.tbCARunCount);
            this.panelCA.Controls.Add(this.lbCAWallRatio);
            this.panelCA.Controls.Add(this.tbCAWallRatio);
            this.panelCA.Controls.Add(this.lbCAHeight);
            this.panelCA.Controls.Add(this.tbCAHeight);
            this.panelCA.Controls.Add(this.lbCAWidth);
            this.panelCA.Controls.Add(this.tbCAWidth);
            this.panelCA.Location = new System.Drawing.Point(386, 296);
            this.panelCA.Name = "panelCA";
            this.panelCA.Size = new System.Drawing.Size(338, 252);
            this.panelCA.TabIndex = 7;
            this.panelCA.Visible = false;
            // 
            // lbCARunCount
            // 
            this.lbCARunCount.AutoSize = true;
            this.lbCARunCount.Location = new System.Drawing.Point(19, 90);
            this.lbCARunCount.Name = "lbCARunCount";
            this.lbCARunCount.Size = new System.Drawing.Size(64, 12);
            this.lbCARunCount.TabIndex = 11;
            this.lbCARunCount.Text = "Run Count";
            // 
            // tbCARunCount
            // 
            this.tbCARunCount.Location = new System.Drawing.Point(94, 87);
            this.tbCARunCount.MaxLength = 4;
            this.tbCARunCount.Name = "tbCARunCount";
            this.tbCARunCount.Size = new System.Drawing.Size(72, 21);
            this.tbCARunCount.TabIndex = 10;
            this.tbCARunCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbCAWallRatio
            // 
            this.lbCAWallRatio.AutoSize = true;
            this.lbCAWallRatio.Location = new System.Drawing.Point(23, 63);
            this.lbCAWallRatio.Name = "lbCAWallRatio";
            this.lbCAWallRatio.Size = new System.Drawing.Size(60, 12);
            this.lbCAWallRatio.TabIndex = 9;
            this.lbCAWallRatio.Text = "Wall Ratio";
            // 
            // tbCAWallRatio
            // 
            this.tbCAWallRatio.Location = new System.Drawing.Point(94, 60);
            this.tbCAWallRatio.MaxLength = 4;
            this.tbCAWallRatio.Name = "tbCAWallRatio";
            this.tbCAWallRatio.Size = new System.Drawing.Size(72, 21);
            this.tbCAWallRatio.TabIndex = 8;
            this.tbCAWallRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbCAHeight
            // 
            this.lbCAHeight.AutoSize = true;
            this.lbCAHeight.Location = new System.Drawing.Point(6, 37);
            this.lbCAHeight.Name = "lbCAHeight";
            this.lbCAHeight.Size = new System.Drawing.Size(77, 12);
            this.lbCAHeight.TabIndex = 7;
            this.lbCAHeight.Text = "Room Height";
            // 
            // tbCAHeight
            // 
            this.tbCAHeight.Location = new System.Drawing.Point(94, 33);
            this.tbCAHeight.MaxLength = 4;
            this.tbCAHeight.Name = "tbCAHeight";
            this.tbCAHeight.Size = new System.Drawing.Size(72, 21);
            this.tbCAHeight.TabIndex = 6;
            this.tbCAHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbCAWidth
            // 
            this.lbCAWidth.AutoSize = true;
            this.lbCAWidth.Location = new System.Drawing.Point(11, 11);
            this.lbCAWidth.Name = "lbCAWidth";
            this.lbCAWidth.Size = new System.Drawing.Size(72, 12);
            this.lbCAWidth.TabIndex = 5;
            this.lbCAWidth.Text = "Room Width";
            // 
            // tbCAWidth
            // 
            this.tbCAWidth.Location = new System.Drawing.Point(94, 5);
            this.tbCAWidth.MaxLength = 4;
            this.tbCAWidth.Name = "tbCAWidth";
            this.tbCAWidth.Size = new System.Drawing.Size(72, 21);
            this.tbCAWidth.TabIndex = 4;
            this.tbCAWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBSPCondition1
            // 
            this.lbBSPCondition1.AutoSize = true;
            this.lbBSPCondition1.Location = new System.Drawing.Point(5, 6);
            this.lbBSPCondition1.Name = "lbBSPCondition1";
            this.lbBSPCondition1.Size = new System.Drawing.Size(35, 12);
            this.lbBSPCondition1.TabIndex = 1;
            this.lbBSPCondition1.Text = "조건1";
            // 
            // tbBSPCondition1
            // 
            this.tbBSPCondition1.Location = new System.Drawing.Point(46, 3);
            this.tbBSPCondition1.Name = "tbBSPCondition1";
            this.tbBSPCondition1.Size = new System.Drawing.Size(100, 21);
            this.tbBSPCondition1.TabIndex = 0;
            // 
            // panelPN
            // 
            this.panelPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPN.Controls.Add(this.lbPNCondition1);
            this.panelPN.Controls.Add(this.tbPNCondition1);
            this.panelPN.Location = new System.Drawing.Point(386, 38);
            this.panelPN.Name = "panelPN";
            this.panelPN.Size = new System.Drawing.Size(338, 252);
            this.panelPN.TabIndex = 8;
            this.panelPN.Visible = false;
            // 
            // lbPNCondition1
            // 
            this.lbPNCondition1.AutoSize = true;
            this.lbPNCondition1.Location = new System.Drawing.Point(7, 6);
            this.lbPNCondition1.Name = "lbPNCondition1";
            this.lbPNCondition1.Size = new System.Drawing.Size(35, 12);
            this.lbPNCondition1.TabIndex = 3;
            this.lbPNCondition1.Text = "조건1";
            // 
            // tbPNCondition1
            // 
            this.tbPNCondition1.Location = new System.Drawing.Point(48, 3);
            this.tbPNCondition1.Name = "tbPNCondition1";
            this.tbPNCondition1.Size = new System.Drawing.Size(100, 21);
            this.tbPNCondition1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 559);
            this.Controls.Add(this.panelCA);
            this.Controls.Add(this.panelPN);
            this.Controls.Add(this.panelBSP);
            this.Controls.Add(this.btnOpt);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.cbAlgo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGTools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelBSP.ResumeLayout(false);
            this.panelBSP.PerformLayout();
            this.panelCA.ResumeLayout(false);
            this.panelCA.PerformLayout();
            this.panelPN.ResumeLayout(false);
            this.panelPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAlgo;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnOpt;
        private System.Windows.Forms.Panel panelBSP;
        private System.Windows.Forms.Panel panelCA;
        private System.Windows.Forms.Panel panelPN;
        private System.Windows.Forms.TextBox tbBSPCondition1;
        private System.Windows.Forms.Label lbBSPCondition1;
        private System.Windows.Forms.Label lbPNCondition1;
        private System.Windows.Forms.TextBox tbPNCondition1;
        private System.Windows.Forms.Label lbCAWidth;
        private System.Windows.Forms.TextBox tbCAWidth;
        private System.Windows.Forms.Label lbCAHeight;
        private System.Windows.Forms.TextBox tbCAHeight;
        private System.Windows.Forms.Label lbCAWallRatio;
        private System.Windows.Forms.TextBox tbCAWallRatio;
        private System.Windows.Forms.Label lbCARunCount;
        private System.Windows.Forms.TextBox tbCARunCount;
    }
}

