using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Calc(Func<double, double, double> f)
        {
            List<string> errors = new List<string>();
            
            double z1=0, z2=0, erg;
            try
            {
                z1 = double.Parse(TxtZahl1.Text);
            }
            catch (Exception)
            {
                errors.Add("Zahl 1 hat das falsche Format");
                //MessageBox.Show("Zahl 1 hat das falsche Format");
            }
            try
            {
                z2 = double.Parse(TxtZahl2.Text);
            }
            catch (Exception)
            {
                errors.Add("Zahl 2 hat das falsche Format");
                //MessageBox.Show("Zahl 2 hat das falsche Format");
            }
            if (errors.Count == 0)
            {
                erg = f(z1, z2);
                //erg = z1 + z2; // oder z1 * z2
                TxtErgebnis.Text = erg.ToString();
            }
            else
            {
                string err = string.Join("\r\n", errors);
                MessageBox.Show(err);
                TxtErgebnis.Text = "ERROR";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Calc((x1,x2) => x1+x2);
        }

        private void BtnSub_Click(object sender, EventArgs e)
        {
            Calc((x1, x2) => x1 - x2);
        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            Calc((x1, x2) => x1 * x2);
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            Calc((x1, x2) => x1 / x2);
        }

        private void BtnMod_Click(object sender, EventArgs e)
        {
            Calc((x1, x2) => x1 % x2);
        }
    }
}
