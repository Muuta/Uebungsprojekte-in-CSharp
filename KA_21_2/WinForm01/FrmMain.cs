using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm01
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            string ori = TxtSource.Text;
            TxtDestination.Text = ori;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TxtSource.Text = "Hans Maier";
        }

        private void TxtSource_TextChanged(object sender, EventArgs e)
        {
            TxtDestination.Text = TxtSource.Text;
        }

        private void TxtSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
            }
        }

        private void TmrUhr_Tick(object sender, EventArgs e)
        {
            TxtUhr.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
