﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PGToolsApp
{
    public enum PG_ALGORITHM { BSP = 0, CA, PN };

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Shown += MainForm_Shown;
        }

        Dictionary<int, string> dictAlgo;
        List<Panel> listAlgoPanel;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(380, 420);
            dictAlgo = new Dictionary<int, string>
            {
                { 0, "Binary Space Partitioning" },
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void cbAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string algo;
            if (dictAlgo.TryGetValue(cbAlgo.SelectedIndex, out algo))
            {
                int i, j;
                for (i = 0; i < cbAlgo.Items.Count; ++i)
                {
                    if (cbAlgo.Items[i].Equals(algo))
                    {
                        listAlgoPanel[i].Location = new Point(12, 38);
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

        private void btnOpt_Click(object sender, EventArgs e)
        {
            OptionForm optForm = new OptionForm(this);
            optForm.ShowDialog();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            switch (cbAlgo.SelectedIndex)
            {
                case (int)PG_ALGORITHM.BSP: 
                    {
                        int roomSize, depth;
                        if (!int.TryParse(tbBSPSize.Text, out roomSize))
                        {
                            MessageBox.Show("크기 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }
                        if (!int.TryParse(cbBSPDepthCount.Text, out depth))
                        {
                            MessageBox.Show("깊이 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }

                        ShowGenFormBSP(roomSize, depth);
                    }
                    break;
                case (int)PG_ALGORITHM.CA:
                    {
                        int roomWidth, roomHeight, runCount;
                        double wallRatio;
                        if (!int.TryParse(tbCAWidth.Text, out roomWidth))
                        {
                            MessageBox.Show("너비 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }
                        if (!int.TryParse(tbCAHeight.Text, out roomHeight))
                        {
                            MessageBox.Show("높이 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }
                        if (!double.TryParse(tbCAWallRatio.Text, out wallRatio))
                        {
                            MessageBox.Show("비율 입력이 잘못되었습니다. 0.0에서 0.1 사이의 소수를 입력해주세요.");
                            break;
                        }
                        if (!int.TryParse(cbCARunCount.Text, out runCount))
                        {
                            MessageBox.Show("실행 횟수 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }

                        ShowGenFormCA(roomWidth, roomHeight, runCount, wallRatio);
                    }
                    break;
                case (int)PG_ALGORITHM.PN:
                    {
                        int roomWidth, roomHeight, octaveCount;
                        if (!int.TryParse(tbPNWidth.Text, out roomWidth))
                        {
                            MessageBox.Show("너비 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }
                        if (!int.TryParse(tbPNHeight.Text, out roomHeight))
                        {
                            MessageBox.Show("높이 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }
                        if (!int.TryParse(cbPNOctaveCount.Text, out octaveCount))
                        {
                            MessageBox.Show("옥타브 입력이 잘못되었습니다. 숫자를 입력해주세요.");
                            break;
                        }

                        ShowGenFormPN(roomWidth, roomHeight, octaveCount);
                    }
                    break;
            }
        }

        private void ShowGenFormBSP(int roomSize, int depth)
        {
            GenForm gf = new GenForm(this);
            gf.CurrentAlgorithm = PG_ALGORITHM.BSP;
            gf.BSP = new BinarySpacePartitioning(roomSize, depth);
            gf.ShowDialog();
        }

        private void ShowGenFormCA(int roomWidth, int roomHeight, int runCount, double wallRatio)
        {
            GenForm gf = new GenForm(this);
            gf.CurrentAlgorithm = PG_ALGORITHM.CA;
            gf.CA = new CellularAutomata(roomWidth, roomHeight, runCount, wallRatio);
            gf.ShowDialog();
        }

        private void ShowGenFormPN(int roomWidth, int roomHeight, int octaveCount)
        {
            GenForm gf = new GenForm(this);
            gf.CurrentAlgorithm = PG_ALGORITHM.PN;
            gf.PN = new PerlinNoise(roomWidth, roomHeight, octaveCount);
            gf.ShowDialog();
        }
    }
}
