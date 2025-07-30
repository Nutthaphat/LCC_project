using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCC
{
    public partial class LCPlus : Form
    {
        public LCPlus()
        {
            InitializeComponent();
        }

        private void btnchemsub_Click(object sender, EventArgs e)
        {
            Form1 page = new Form1();
            page.Show();
        }
    }
}
