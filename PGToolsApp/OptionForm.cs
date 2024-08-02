using System.Drawing;
using System;
using System.Windows.Forms;

namespace PGToolsApp
{
    public partial class OptionForm : Form
    {
        private Form parent;

        public OptionForm(Form parent)
        {
            InitializeComponent();
            
            Shown += OptionForm_Shown;

            this.parent = parent;
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

        private void OptionForm_Shown(object sender, EventArgs e)
        {
            if (parent != null)
            {
                this.Location = new Point(
                    parent.Location.X + (parent.Width - this.Width) / 2,
                    parent.Location.Y + (parent.Height - this.Height) / 2);
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
