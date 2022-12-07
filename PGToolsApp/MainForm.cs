﻿using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace PGToolsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Dictionary<int, string> dictAlgo;
        List<Panel> listAlgoPanel;

        public enum PG_ALGORITHM { BSP = 0, CA, PN };

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            this.Size = new System.Drawing.Size(380, 420);

            dictAlgo = new Dictionary<int, string>
            {
                { 0, "BSP" },
                { 1, "Cellular Automaton" },
                { 2, "Perlin Noise" }
            };
            for (int i = 0; i < dictAlgo.Count; ++i)
                cbAlgo.Items.Add(dictAlgo[i]);

            listAlgoPanel = new List<Panel>
            {
                panelBSP,
                panelCA,
                panelPN
            };

            cbAlgo.SelectedIndex = 0;
        }

        private void cbAlgo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string algo;
            if (dictAlgo.TryGetValue(cbAlgo.SelectedIndex, out algo))
            {
                int i, j;
                for (i = 0; i < cbAlgo.Items.Count; ++i)
                {
                    if (cbAlgo.Items[i].Equals(algo))
                    {
                        listAlgoPanel[i].Location = new System.Drawing.Point(12, 38);
                        listAlgoPanel[i].Visible = true;
                        break;
                    }
                }

                for (j = 0; j < listAlgoPanel.Count; ++j)
                {
                    if (i == j) continue;
                    listAlgoPanel[j].Visible = false;
                }
            }
        }

        private void btnOpt_Click(object sender, System.EventArgs e)
        {

        }

        private void btnGen_Click(object sender, System.EventArgs e)
        {
            switch (cbAlgo.SelectedIndex)
            {
                case (int)PG_ALGORITHM.BSP: RunBSP(); break;
                case (int)PG_ALGORITHM.CA:
                    int roomWidth, roomHeight, runCount;
                    double wallRate;
                    if (!int.TryParse(tbCAWidth.Text, out roomWidth))
                    {
                        MessageBox.Show("너비 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                        break;
                    }
                    if (!int.TryParse(tbCAHeight.Text, out roomHeight))
                    {
                        MessageBox.Show("너비 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                        break;
                    }
                    if (!double.TryParse(tbCAWallRatio.Text, out wallRate))
                    {
                        MessageBox.Show("비율 입력이 잘못되었습니다. 0.0에서 0.1 사이의 소수를 입력해주세요.");
                        break;
                    }
                    if (!int.TryParse(tbCARunCount.Text, out runCount))
                    {
                        MessageBox.Show("실행 횟수 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                        break;
                    }

                    Thread t = new Thread(new ParameterizedThreadStart(RunCA));
                    TagCA tca = new TagCA();
                    tca.RoomWidth = roomWidth;
                    tca.RoomHeight = roomHeight;
                    tca.WallRatio = wallRate;
                    tca.RunCount = runCount;
                    t.Start(tca);
                    break;
                case (int)PG_ALGORITHM.PN: RunPN(); break;
            }
        }

        private void RunBSP()
        {
            MessageBox.Show("미완성, 제작중");
        }

        private void RunCA(object obj)
        {
            TagCA tca = (TagCA)obj;
            CA ca = new CA(tca);
            ca.Generate();

            // 새로운 폼에서 보여주기
            GenForm genForm = new GenForm();
            genForm.BitmapBoard = ca.Room;
            genForm.TCA = tca;
            genForm.ShowDialog();
        }

        private void RunPN()
        {
            MessageBox.Show("미완성, 제작중");
        }
    }
}
