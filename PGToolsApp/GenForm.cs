using System.Drawing;
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
        
        private void GenForm_Load(object sender, System.EventArgs e)
        {
            PixelWidth = 5;
            PixelHeight = 5;
        }

        private void panelBitmap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
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

        private void btnSave_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRedraw_Click(object sender, System.EventArgs e)
        {
            CA ca = new CA(TCA);
            ca.Generate();

            BitmapBoard = ca.Room;
            Refresh();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {

        }
    }
}
