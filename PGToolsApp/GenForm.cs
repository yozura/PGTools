using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGToolsApp
{
    public partial class GenForm : Form
    {
        private Form parent;
        private BufferedGraphics BackBuffer;
        private Bitmap OriginBitmap;

        public int[,] BitmapBoard { get; set; }

        public PG_ALGORITHM CurrentAlgorithm { get; set; }

        public BinarySpacePartitioning BSP { get; set; }
        public CellularAutomata CA { get; set; }
        public PerlinNoise PN { get; set; }

        public GenForm(Form parent)
        {
            InitializeComponent();

            // Set Delegate
            Shown += GenForm_Shown;
            pbBitmap.Paint += pbBitmap_Paint;

            // Set Variable
            this.parent = parent;

            pbBitmap.Width = 256;
            pbBitmap.Height = 256;
            pbBitmap.SizeMode = PictureBoxSizeMode.Normal;
        }
        
        private void GenForm_Load(object sender, System.EventArgs e)
        {
            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                BSP.Generate();
                BitmapBoard = BSP.Room;
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                CA.Generate();
                BitmapBoard = CA.Room;
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                PN.Generate();
                BitmapBoard = PN.Room;
            }
            else
            {
#if DEBUG
                Debug.Assert(false, "Missing the current algorithm.");
#endif
                return;
            }
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
            if (BackBuffer == null)
            {
                BufferedGraphicsContext bgc = BufferedGraphicsManager.Current;
                BackBuffer = bgc.Allocate(e.Graphics, e.ClipRectangle);
            }

            DrawBitmap(BackBuffer.Graphics);
            BackBuffer.Render(e.Graphics);
        }

        private void DrawBitmap(Graphics graphics)
        {
            int roomHeight, roomWidth;
            Action<byte[], int, int, int, int> drawAction;

            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                roomHeight = BSP.Info.RoomHeight;
                roomWidth = BSP.Info.RoomWidth;
                drawAction = DrawBSP;
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                roomHeight = CA.Info.RoomHeight;
                roomWidth = CA.Info.RoomWidth;
                drawAction = DrawCA;
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                roomHeight = PN.Info.RoomHeight;
                roomWidth = PN.Info.RoomWidth;
                drawAction = DrawPN;
            }
            else
            {
#if DEBUG
                Debug.Assert(false, "Missing the current algorithm.");
#endif
                return;
            }

            OriginBitmap?.Dispose();
            OriginBitmap = new Bitmap(roomWidth, roomHeight, PixelFormat.Format24bppRgb);

            BitmapData bitmapData = OriginBitmap.LockBits(
                new Rectangle(0, 0, OriginBitmap.Width, OriginBitmap.Height),
                ImageLockMode.WriteOnly,
                OriginBitmap.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(OriginBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * OriginBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;

            Parallel.For(0, roomHeight, y =>
            {
                Parallel.For(0, roomWidth, x =>
                {
                    drawAction(pixels, x, y, bitmapData.Stride, bytesPerPixel);
                });
            });

            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            OriginBitmap.UnlockBits(bitmapData);

            graphics.DrawImage(OriginBitmap, 0, 0, 256, 256);
        }

        private void DrawBSP(byte[] pixels, int x, int y, int stride, int bytesPerPixel)
        {
            int index = y * stride + x * bytesPerPixel;
            switch (BitmapBoard[y, x])
            {
                case (int)BSP_TILE_TYPE.EMPTY:
                    pixels[index] = 0;
                    pixels[index + 1] = 0;
                    pixels[index + 2] = 0;
                    break;
                case (int)BSP_TILE_TYPE.WALL:
                case (int)BSP_TILE_TYPE.CORRIDOR:
                    pixels[index] = 255;
                    pixels[index + 1] = 255;
                    pixels[index + 2] = 255;
                    break;
            }
        }

        private void DrawCA(byte[] pixels, int x, int y, int stride, int bytesPerPixel)
        {
            int index = y * stride + x * bytesPerPixel;
            switch (BitmapBoard[y, x])
            {
                case (int)CA_TILE_TYPE.EMPTY:
                    pixels[index] = 255;
                    pixels[index + 1] = 255;
                    pixels[index + 2] = 255;
                    break;
                case (int)CA_TILE_TYPE.WALL:
                    pixels[index] = 0;
                    pixels[index + 1] = 0;
                    pixels[index + 2] = 0;
                    break;
            }
        }

        private void DrawPN(byte[] pixels, int x, int y, int stride, int bytesPerPixel)
        {
            int index = y * stride + x * bytesPerPixel;
            byte grayValue = (byte)BitmapBoard[y, x];

            pixels[index] = grayValue;
            pixels[index + 1] = grayValue;
            pixels[index + 2] = grayValue;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveBitmap();
        }

        private void SaveBitmap()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "C:\\";
            sfd.Filter = "txt files (*.txt)|*.txt|bmp files(*.bmp)|*.bmp|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
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
                        sw.Write(OriginBitmap.Height);
                        sw.WriteLine();
                        sw.Write(OriginBitmap.Width);
                        sw.WriteLine();
                        for (int y = 0; y < OriginBitmap.Height; ++y)
                        {
                            for (int x = 0; x < OriginBitmap.Width; ++x)
                            {
                                sw.Write(BitmapBoard[y, x]);
                            }
                            sw.WriteLine();
                        }
                    }
                }
                else
                {
                    ImageFormat format = ImageFormat.Bmp;
                    switch (extension)
                    {
                        case ".bmp": format = ImageFormat.Bmp; break;
                        case ".png": format = ImageFormat.Png; break;
                        case ".jpeg":
                        case ".jpg": format = ImageFormat.Jpeg; break;
                    }
                    OriginBitmap.Save(path, format);
                }

                MessageBox.Show($"{path} 경로에 파일이 저장되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnRedraw.Enabled = false;
            
            Regenerate();
            Refresh();
            
            btnSave.Enabled = true;
            btnRedraw.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Regenerate()
        {
            if (CurrentAlgorithm == PG_ALGORITHM.BSP) BSP.Generate();
            else if (CurrentAlgorithm == PG_ALGORITHM.CA) CA.Generate();
            else if (CurrentAlgorithm == PG_ALGORITHM.PN) PN.Generate();
        }
    }
}
