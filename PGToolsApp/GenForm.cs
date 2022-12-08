using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PGToolsApp
{
    public partial class GenForm : Form
    {
        public GenForm()
        {
            InitializeComponent();
        }

        public int[,] BitmapBoard { get; set; }
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }

        // 세포 자동자 전용 구조체
        public TagCA TCA { get; set; }

        public PG_ALGORITHM CurrentAlgorithm { get; set; }
        
        private void GenForm_Load(object sender, System.EventArgs e)
        {
            this.DoubleBuffered = true;

            PixelWidth = 5;
            PixelHeight = 5;

            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                // 미완성
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                int bitmapWidth = TCA.RoomWidth * PixelWidth;
                int bitmapHeight = TCA.RoomHeight * PixelHeight;
                
                this.Size = new Size(bitmapWidth + panelBtns.Size.Width, bitmapHeight);
                int diff = bitmapHeight - ClientSize.Height;

                this.Size = new Size(bitmapWidth + panelBtns.Size.Width, bitmapHeight + diff);
                panelBitmap.Size = new Size(bitmapWidth, bitmapHeight);
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                // 미완성
            }
        }

        private void panelBitmap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                // 미완성
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
                                g.DrawRectangle(Pens.White, x * PixelWidth, y * PixelHeight, PixelWidth, PixelHeight);
                                break;
                            case (int)CA_TILE_TYPE.WALL:
                                g.FillRectangle(Brushes.Black, x * PixelWidth, y * PixelHeight, PixelWidth, PixelHeight);
                                break;
                        }
                    }
                }
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                // 미완성
            }

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRedraw_Click(object sender, System.EventArgs e)
        {
            if (CurrentAlgorithm == PG_ALGORITHM.BSP)
            {
                // 미완성
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.CA)
            {
                btnSave.Enabled = false;
                btnRedraw.Enabled = false;

                Thread t = new Thread(new ThreadStart(Redarw_CA));
                t.Start();
                t.Join();

                Refresh();
                btnSave.Enabled = true;
                btnRedraw.Enabled = true;
            }
            else if (CurrentAlgorithm == PG_ALGORITHM.PN)
            {
                // 미완성
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Redarw_CA()
        {
            CA ca = new CA(TCA);
            ca.Generate();

            BitmapBoard = ca.Room;
        }
    }
}
