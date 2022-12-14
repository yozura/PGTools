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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbAlgo = new System.Windows.Forms.ComboBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnOpt = new System.Windows.Forms.Button();
            this.panelBSP = new System.Windows.Forms.Panel();
            this.panelCA = new System.Windows.Forms.Panel();
            this.cbCARunCount = new System.Windows.Forms.ComboBox();
            this.lbCARunCount = new System.Windows.Forms.Label();
            this.lbCAWallRatio = new System.Windows.Forms.Label();
            this.tbCAWallRatio = new System.Windows.Forms.TextBox();
            this.lbCAHeight = new System.Windows.Forms.Label();
            this.tbCAHeight = new System.Windows.Forms.TextBox();
            this.lbCAWidth = new System.Windows.Forms.Label();
            this.tbCAWidth = new System.Windows.Forms.TextBox();
            this.panelPN = new System.Windows.Forms.Panel();
            this.cbPNOctaveCount = new System.Windows.Forms.ComboBox();
            this.lbPNOctaveCount = new System.Windows.Forms.Label();
            this.lbPNHeight = new System.Windows.Forms.Label();
            this.tbPNHeight = new System.Windows.Forms.TextBox();
            this.lbPNWidth = new System.Windows.Forms.Label();
            this.tbPNWidth = new System.Windows.Forms.TextBox();
            this.cbBSPDepthCount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBSPHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBSPWidth = new System.Windows.Forms.TextBox();
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
            this.panelBSP.Controls.Add(this.cbBSPDepthCount);
            this.panelBSP.Controls.Add(this.label1);
            this.panelBSP.Controls.Add(this.label2);
            this.panelBSP.Controls.Add(this.tbBSPHeight);
            this.panelBSP.Controls.Add(this.label3);
            this.panelBSP.Controls.Add(this.tbBSPWidth);
            this.panelBSP.Location = new System.Drawing.Point(12, 38);
            this.panelBSP.Name = "panelBSP";
            this.panelBSP.Size = new System.Drawing.Size(338, 252);
            this.panelBSP.TabIndex = 6;
            // 
            // panelCA
            // 
            this.panelCA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCA.Controls.Add(this.cbCARunCount);
            this.panelCA.Controls.Add(this.lbCARunCount);
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
            // cbCARunCount
            // 
            this.cbCARunCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCARunCount.FormattingEnabled = true;
            this.cbCARunCount.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.cbCARunCount.Location = new System.Drawing.Point(94, 87);
            this.cbCARunCount.Name = "cbCARunCount";
            this.cbCARunCount.Size = new System.Drawing.Size(72, 20);
            this.cbCARunCount.TabIndex = 9;
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
            // 
            // panelPN
            // 
            this.panelPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPN.Controls.Add(this.cbPNOctaveCount);
            this.panelPN.Controls.Add(this.lbPNOctaveCount);
            this.panelPN.Controls.Add(this.lbPNHeight);
            this.panelPN.Controls.Add(this.tbPNHeight);
            this.panelPN.Controls.Add(this.lbPNWidth);
            this.panelPN.Controls.Add(this.tbPNWidth);
            this.panelPN.Location = new System.Drawing.Point(386, 38);
            this.panelPN.Name = "panelPN";
            this.panelPN.Size = new System.Drawing.Size(338, 252);
            this.panelPN.TabIndex = 8;
            this.panelPN.Visible = false;
            // 
            // cbPNOctaveCount
            // 
            this.cbPNOctaveCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPNOctaveCount.FormattingEnabled = true;
            this.cbPNOctaveCount.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbPNOctaveCount.Location = new System.Drawing.Point(94, 60);
            this.cbPNOctaveCount.Name = "cbPNOctaveCount";
            this.cbPNOctaveCount.Size = new System.Drawing.Size(72, 20);
            this.cbPNOctaveCount.TabIndex = 8;
            // 
            // lbPNOctaveCount
            // 
            this.lbPNOctaveCount.AutoSize = true;
            this.lbPNOctaveCount.Location = new System.Drawing.Point(2, 63);
            this.lbPNOctaveCount.Name = "lbPNOctaveCount";
            this.lbPNOctaveCount.Size = new System.Drawing.Size(81, 12);
            this.lbPNOctaveCount.TabIndex = 7;
            this.lbPNOctaveCount.Text = "Octave Count";
            // 
            // lbPNHeight
            // 
            this.lbPNHeight.AutoSize = true;
            this.lbPNHeight.Location = new System.Drawing.Point(6, 36);
            this.lbPNHeight.Name = "lbPNHeight";
            this.lbPNHeight.Size = new System.Drawing.Size(77, 12);
            this.lbPNHeight.TabIndex = 5;
            this.lbPNHeight.Text = "Room Height";
            // 
            // tbPNHeight
            // 
            this.tbPNHeight.Location = new System.Drawing.Point(94, 33);
            this.tbPNHeight.MaxLength = 4;
            this.tbPNHeight.Name = "tbPNHeight";
            this.tbPNHeight.Size = new System.Drawing.Size(72, 21);
            this.tbPNHeight.TabIndex = 4;
            // 
            // lbPNWidth
            // 
            this.lbPNWidth.AutoSize = true;
            this.lbPNWidth.Location = new System.Drawing.Point(11, 12);
            this.lbPNWidth.Name = "lbPNWidth";
            this.lbPNWidth.Size = new System.Drawing.Size(72, 12);
            this.lbPNWidth.TabIndex = 3;
            this.lbPNWidth.Text = "Room Width";
            // 
            // tbPNWidth
            // 
            this.tbPNWidth.Location = new System.Drawing.Point(94, 6);
            this.tbPNWidth.MaxLength = 4;
            this.tbPNWidth.Name = "tbPNWidth";
            this.tbPNWidth.Size = new System.Drawing.Size(72, 21);
            this.tbPNWidth.TabIndex = 2;
            // 
            // cbBSPDepthCount
            // 
            this.cbBSPDepthCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBSPDepthCount.FormattingEnabled = true;
            this.cbBSPDepthCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbBSPDepthCount.Location = new System.Drawing.Point(94, 60);
            this.cbBSPDepthCount.Name = "cbBSPDepthCount";
            this.cbBSPDepthCount.Size = new System.Drawing.Size(72, 20);
            this.cbBSPDepthCount.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Depth Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Room Height";
            // 
            // tbBSPHeight
            // 
            this.tbBSPHeight.Location = new System.Drawing.Point(94, 33);
            this.tbBSPHeight.MaxLength = 4;
            this.tbBSPHeight.Name = "tbBSPHeight";
            this.tbBSPHeight.Size = new System.Drawing.Size(72, 21);
            this.tbBSPHeight.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Room Width";
            // 
            // tbBSPWidth
            // 
            this.tbBSPWidth.Location = new System.Drawing.Point(94, 6);
            this.tbBSPWidth.MaxLength = 4;
            this.tbBSPWidth.Name = "tbBSPWidth";
            this.tbBSPWidth.Size = new System.Drawing.Size(72, 21);
            this.tbBSPWidth.TabIndex = 9;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Label lbPNWidth;
        private System.Windows.Forms.TextBox tbPNWidth;
        private System.Windows.Forms.Label lbCAWidth;
        private System.Windows.Forms.TextBox tbCAWidth;
        private System.Windows.Forms.Label lbCAHeight;
        private System.Windows.Forms.TextBox tbCAHeight;
        private System.Windows.Forms.Label lbCAWallRatio;
        private System.Windows.Forms.TextBox tbCAWallRatio;
        private System.Windows.Forms.Label lbCARunCount;
        private System.Windows.Forms.Label lbPNHeight;
        private System.Windows.Forms.TextBox tbPNHeight;
        private System.Windows.Forms.Label lbPNOctaveCount;
        private System.Windows.Forms.ComboBox cbPNOctaveCount;
        private System.Windows.Forms.ComboBox cbCARunCount;
        private System.Windows.Forms.ComboBox cbBSPDepthCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBSPHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBSPWidth;
    }
}

