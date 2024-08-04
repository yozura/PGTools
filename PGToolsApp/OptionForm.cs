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
    }
}
