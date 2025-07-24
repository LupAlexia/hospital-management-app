using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionarePersonalSpital
{
    public partial class RegistruForm : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MediciDatabase.mdf;Integrated Security=True;";
        public RegistruForm()
        {
            InitializeComponent();
        }


        private void btnCauta_Click(object sender, EventArgs e)
        {
            CautaMedic();
        }

        private void CautaMedic()
        {
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;

            if (ExistaMedic(nume, prenume))
            {
                InfoForm f1 = new InfoForm(nume, prenume);
                this.Visible = false;
                f1.ShowDialog();
            }
        }

        private bool ExistaMedic(string nume, string prenume)
        {
            string query = "SELECT COUNT(Nume) FROM Medici WHERE Nume = @nume AND Prenume = @prenume";
            var con = new SqlConnection(connStr);
            con.Open();

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nume", nume);
            cmd.Parameters.AddWithValue("@prenume", prenume);

            int x = (int)cmd.ExecuteScalar();
            con.Close();
            cmd.Dispose();
            con.Dispose();
            return x == 1;
        }

        private void txtPrenume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CautaMedic();
            }
        }
    }
}
