﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PGToolsApp
{
    public partial class GenForm : Form
    {
        private Form parent;

        public int[,] BitmapBoard { get; set; }

        public BSPInformation BSPInfo { get; set; }
        public TagCA TCA { get; set; }
        public TagPN TPN { get; set; }

        public PG_ALGORITHM CurrentAlgorithm { get; set; }

        public GenForm(Form parent)
        {
            InitializeComponent();

            // Set Delegate
            Shown += GenForm_Shown;
            pbBitmap.Paint += pbBitmap_Paint;

            // Set Variable
            this.parent = parent;
        }
        
        private void GenForm_Load(object sender, System.EventArgs e)
        {
            int bitmapWidth, bitmapHeight;
            bitmapWidth = bitmapHeight = 256;

            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                bitmapWidth = BSPInfo.RoomWidth;
                bitmapHeight = BSPInfo.RoomHeight;

            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                bitmapWidth = TCA.RoomWidth;
                bitmapHeight = TCA.RoomHeight;
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                bitmapWidth = TPN.RoomWidth;
                bitmapHeight = TPN.RoomHeight;
            }

            this.ClientSize = new Size(bitmapWidth + panelBtns.Width, bitmapHeight);
        }

        private void GenForm_Shown(object sender, EventArgs e)
        {
            if (parent != null)
            {
                this.Location = new Point(
                    parent.Location.X + (parent.Width - this.Width) / 2,
                    parent.Location.Y + (parent.Height - this.Height) / 2);
            }
        }

        private void pbBitmap_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);

            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                for (int y = 0; y < BSPInfo.RoomHeight; ++y)
                {
                    for (int x = 0; x < BSPInfo.RoomWidth; ++x)
                    {
                        switch (BitmapBoard[y, x])
                        {
                            case (int)BSP_TILE_TYPE.EMPTY:
                                graphics.FillRectangle(Brushes.Black, x, y, 1, 1);
                                break;
                            case (int)BSP_TILE_TYPE.WALL:
                            case (int)BSP_TILE_TYPE.CORRIDOR:
                                graphics.DrawRectangle(Pens.White, x, y, 1, 1);
                                break;
                        }
                    }
                }
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                for (int y = 0; y < TCA.RoomHeight; ++y)
                {
                    for (int x = 0; x < TCA.RoomWidth; ++x)
                    {
                        switch (BitmapBoard[y, x])
                        {
                            case (int)CA_TILE_TYPE.EMPTY:
                                graphics.DrawRectangle(Pens.White, x, y, 1, 1);
                                break;
                            case (int)CA_TILE_TYPE.WALL:
                                graphics.FillRectangle(Brushes.Black, x, y, 1, 1);
                                break;
                        }
                    }
                }
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                for (int y = 0; y < TPN.RoomHeight; ++y)
                {
                    for (int x = 0; x < TPN.RoomWidth; ++x)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(BitmapBoard[y, x], Color.Black)), x, y, 1, 1);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                SaveBSP();
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                SaveCA();
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                SavePN();
            }
        }

        private void btnRedraw_Click(object sender, System.EventArgs e)
        {
            btnSave.Enabled = false;
            btnRedraw.Enabled = false;
            
            Redraw();
            Refresh();
            
            btnSave.Enabled = true;
            btnRedraw.Enabled = true;
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Redraw()
        {
            if (CurrentAlgorithm == PG_ALGORITHM.BSP) RedrawBSP();
            else if (CurrentAlgorithm == PG_ALGORITHM.CA) RedrawCA();
            else if (CurrentAlgorithm == PG_ALGORITHM.PN) RedrawPN();
        }

        private void RedrawBSP()
        {
            BSP bsp = new BSP(BSPInfo);
            bsp.Generate();
            BitmapBoard = bsp.Room;
        }

        private void RedrawCA()
        {
            CA ca = new CA(TCA);
            ca.Generate();
            BitmapBoard = ca.Room;
        }

        private void RedrawPN()
        {
            PN pn = new PN();
            TPN.Room = pn.GeneratePerlinNoise(pn.GenerateWhiteNoise(TPN.RoomWidth, TPN.RoomHeight), TPN.OctaveCount);
            for (int y = 0; y < TPN.RoomWidth; ++y)
            {
                for (int x = 0; x < TPN.RoomHeight; ++x)
                {
                    int alpha = Math.Abs((int)(TPN.Room[y][x] * 255));
                    BitmapBoard[y, x] = alpha;
                }
            }
        }

        private void SaveBSP()
        {
            // txt 파일로 저장 -> Wall은 1, Empty는 0
            // png 파일로 저장 가능
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "C:\\";
            sfd.Filter = "txt files (*.txt)|*.txt|png files (*.png)|*.png|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                string extension = Path.GetExtension(path);
                if (extension == ".txt")
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write(BSPInfo.RoomHeight);
                        sw.WriteLine();
                        sw.Write(BSPInfo.RoomWidth);
                        sw.WriteLine();
                        for (int y = 0; y < BSPInfo.RoomHeight; ++y)
                        {
                            for (int x = 0; x < BSPInfo.RoomWidth; ++x)
                            {
                                sw.Write(BitmapBoard[y, x]);
                            }
                            sw.WriteLine();
                        }
                    }
                }
                else
                {
                    using (Bitmap bitmap = new Bitmap(pbBitmap.Width, pbBitmap.Height))
                    {
                        pbBitmap.DrawToBitmap(bitmap, pbBitmap.ClientRectangle);
                        ImageFormat format = null;
                        switch (extension)
                        {
                            case ".bmp": format = ImageFormat.Bmp; break;
                            case ".png": format = ImageFormat.Png; break;
                            case ".jpeg":
                            case ".jpg": format = ImageFormat.Jpeg; break;
                            case ".gif": format = ImageFormat.Gif; break;
                        }
                        bitmap.Save(path, format);
                    }
                }
                MessageBox.Show($"{path} 파일 저장에 성공했습니다.");
            }
        }

        private void SaveCA()
        {
            // txt 파일로 저장 -> Wall은 1, Empty는 0
            // png 파일로 저장 가능
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "C:\\";
            sfd.Filter = "txt files (*.txt)|*.txt|png files (*.png)|*.png|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                string extension = Path.GetExtension(path);
                if (extension == ".txt")
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write(TCA.RoomHeight);
                        sw.WriteLine();
                        sw.Write(TCA.RoomWidth);
                        sw.WriteLine();
                        for (int y = 0; y < TCA.RoomHeight; ++y)
                        {
                            for (int x = 0; x < TCA.RoomWidth; ++x)
                            {
                                sw.Write(BitmapBoard[y, x]);
                            }
                            sw.WriteLine();
                        }
                    }
                }
                else
                {
                    using (Bitmap bitmap = new Bitmap(pbBitmap.Width, pbBitmap.Height))
                    {
                        pbBitmap.DrawToBitmap(bitmap, pbBitmap.ClientRectangle);
                        ImageFormat format = null;
                        switch (extension)
                        {
                            case ".bmp": format = ImageFormat.Bmp; break;
                            case ".png": format = ImageFormat.Png; break;
                            case ".jpeg":
                            case ".jpg": format = ImageFormat.Jpeg; break;
                            case ".gif": format = ImageFormat.Gif; break;
                        }
                        bitmap.Save(path, format);
                    }
                }
                MessageBox.Show($"{path} 파일 저장에 성공했습니다.");
            }
        }

        private void SavePN()
        {
            // png 파일로 저장
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "C:\\";
            sfd.Filter = "bmp file (*.bmp)|*.bmp|png file (*.png)|*.png|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.AddExtension = true;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                using (Bitmap bitmap = new Bitmap(pbBitmap.Width, pbBitmap.Height))
                {
                    pbBitmap.DrawToBitmap(bitmap, pbBitmap.ClientRectangle);
                    ImageFormat format = null;
                    string extension = Path.GetExtension(path);
                    switch (extension)
                    {
                        case ".bmp": format = ImageFormat.Bmp; break;
                        case ".png": format = ImageFormat.Png; break;
                        case ".jpeg":
                        case ".jpg": format = ImageFormat.Jpeg; break;
                        case ".gif": format = ImageFormat.Gif; break;
                    }
                    bitmap.Save(path, format);
                }

                MessageBox.Show($"{path} 파일 저장에 성공했습니다.");
            }
        }
    }
}
