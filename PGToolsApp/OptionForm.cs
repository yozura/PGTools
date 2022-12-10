using System.Windows.Forms;

namespace PGToolsApp
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
        }

        private void OptionForm_Load(object sender, System.EventArgs e)
        {
            switch (GenForm.PixelHeight)
            {
                case 1: rbPixelHeight1.Checked = true; break;
                case 5: rbPixelHeight2.Checked = true; break;
                case 10: rbPixelHeight3.Checked = true; break;
            }

            switch (GenForm.PixelWidth)
            {
                case 1: rbPixelWidth1.Checked = true; break;
                case 5: rbPixelWidth2.Checked = true; break;
                case 10: rbPixelWidth3.Checked = true; break;
            }
        }

        private void rbPixelWidth1_CheckedChanged(object sender, System.EventArgs e)
        {
            GenForm.PixelWidth = 1;
        }

        private void rbPixelWidth2_CheckedChanged(object sender, System.EventArgs e)
        {
            GenForm.PixelWidth = 5;
        }

        private void rbPixelWidth3_CheckedChanged(object sender, System.EventArgs e)
        {
            GenForm.PixelWidth = 10;
        }

        private void rbPixelHeight1_CheckedChanged(object sender, System.EventArgs e)
        {
            GenForm.PixelHeight = 1;
        }

        private void rbPixelHeight2_CheckedChanged(object sender, System.EventArgs e)
        {
            GenForm.PixelHeight = 5;
        }

        private void rbPixelHeight3_CheckedChanged(object sender, System.EventArgs e)
        {
            GenForm.PixelHeight = 10;
        }
    }
}
