using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace GestionarePersonalSpital
{
    public partial class InfoForm : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MediciDatabase.mdf;Integrated Security=True;";
        private string imgPath = $@"{Directory.GetCurrentDirectory()}\..\..\Poze\";
        public string nume, prenume;
        public InfoForm(string nume, string prenume)
        {
            InitializeComponent();

            this.nume = nume;
            this.prenume = prenume;
            lblMedic.Text = "Dr. " + nume + " " + prenume;
            PopuleazaDgvInfo();
            IncarcaImg();
        }

        private void IncarcaImg()
        {
            string fisier = GetFisierPoza();    
            pbPoza.Load("Poze\\" + fisier);
        }

        private string GetFisierPoza()
        {
            string fisier;
            var con = new SqlConnection(connStr);
            con.Open();
            string query = "SELECT Fisier_poza FROM Poze WHERE Nume_medic = @nume";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nume", nume);

            var rd = cmd.ExecuteReader();
            rd.Read();
            fisier = rd[0].ToString();
            rd.Close();
            con.Close();
            con.Dispose();
            cmd.Dispose();

            return fisier;
        }

        private void PopuleazaDgvInfo()
        {
            var con = new SqlConnection(connStr);
            con.Open();

            string query = "SELECT Specialitate, Titulatură, CNP, Domiciliu, Contact, Contract_angajare, Adeverinta_studii, Asigurare_malpraxis FROM Medici WHERE Nume = @nume AND Prenume = @prenume";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nume", nume);
            cmd.Parameters.AddWithValue("@prenume", prenume);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvInfo.DataSource = dt;

            da.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            ModifInfoForm f1 = new ModifInfoForm(nume, prenume);
            this.Visible = false;
            f1.ShowDialog();

            PopuleazaDgvInfo();
            this.Visible = true;
        }
    }
}
