using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionarePersonalSpital
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            PrezentareForm f1 = new PrezentareForm();
            this.Visible = false;
            f1.ShowDialog();
            this.Visible = true;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            RegistruForm f2 = new RegistruForm();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ProgramForm f3 = new ProgramForm();
            this.Visible = false;
            f3.ShowDialog();
            this.Visible = true;
        }
    }
}
