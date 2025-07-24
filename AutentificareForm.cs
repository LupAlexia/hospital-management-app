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
    public partial class AutentificareForm : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MediciDatabase.mdf;Integrated Security=True;";
        public AutentificareForm()
        {
            InitializeComponent();
        }

        private void btnLogare_Click(object sender, EventArgs e)
        {
            Logare();
        }

        private void Logare()
        {
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            string parola = txtParola.Text;
            if(string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume) || string.IsNullOrEmpty(parola))
            {
                MessageBox.Show("Nu au fost completate toate câmpurile!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNume.Text = "";
                txtPrenume.Text = "";
                txtParola.Text = "";
                return;
            }


            if (!ExistaUtilizator(nume, prenume, parola))
            {
                MessageBox.Show("Nume de utilizator sau parola incorecte!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNume.Text = "";
                txtPrenume.Text = "";
                txtParola.Text = "";
                return;
            }
            else
            {
                MainForm frm = new MainForm();
                this.Visible = false;
                frm.ShowDialog();
                Application.Exit();
            }
        }

        private bool ExistaUtilizator(string nume, string prenume, string parola)
        {
            string query = "SELECT COUNT(Nume) FROM Administratori WHERE Nume = @nume AND Prenume = @prenume AND Parola = @parola";
            var con = new SqlConnection(connStr);
            con.Open();

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nume", nume);
            cmd.Parameters.AddWithValue("@prenume", prenume);
            cmd.Parameters.AddWithValue("@parola", parola);

            int x = (int)cmd.ExecuteScalar();
            con.Close();
            cmd.Dispose();
            con.Dispose();
            return x == 1;
        }

        private void txtParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logare();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtPrenume.Focus();
            }
        }

        private void txtNume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
               txtPrenume.Focus();
               return;
            }
        }

        private void txtPrenume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtParola.Focus();
                return;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtNume.Focus();
            }
        }
    }
}
