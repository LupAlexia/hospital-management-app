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
    public partial class ModifInfoForm : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MediciDatabase.mdf;Integrated Security=True;";
        public string nume, prenume;

        public ModifInfoForm(string nume, string prenume)
        {
            InitializeComponent();
            
            this.nume = nume;
            this.prenume = prenume;
            label1.Text = "Nume: " + nume;
            label5.Text = "Prenume: " + prenume;
            PopuleazaComboSectii();
        }

        private void PopuleazaComboSectii()
        {
            var con = new SqlConnection(connStr);
            con.Open();
            string query = "SELECT Denumire FROM Secții";
            var cmd = new SqlCommand(query, con);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbSpec.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }

        private void btnModifică_Click(object sender, EventArgs e)
        {
            string specialitate = cmbSpec.SelectedItem.ToString();
            string titul="";
            if (rdb1.Checked)
                titul = "Medic primar";
            if (rdb2.Checked)
                titul = "Medic specialist";
            string CNP = txtCNP.Text;
            string domiciliu = txtDomiciliu.Text;
            int contact = int.Parse(txtContact.Text);
            string contract = txtContr.Text;
            string studii = txtStudii.Text;
            string asig = txtAsig.Text;

            var con = new SqlConnection(connStr);
            con.Open();

            string query = "UPDATE Medici SET Specialitate = @specialitate, Titulatură = @titul, CNP = @cnp, Domiciliu = @domiciliu, Contact = @contact, Contract_angajare = @contract, Adeverinta_studii = @studii, Asigurare_malpraxis = @asig  WHERE Nume = @nume AND Prenume = @prenume";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nume", nume);
            cmd.Parameters.AddWithValue("@prenume", prenume);
            cmd.Parameters.AddWithValue("@specialitate", specialitate);
            cmd.Parameters.AddWithValue("@titul", titul);
            cmd.Parameters.AddWithValue("@cnp", CNP);
            cmd.Parameters.AddWithValue("@domiciliu", domiciliu);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@contract", contract);
            cmd.Parameters.AddWithValue("@studii", studii);
            cmd.Parameters.AddWithValue("@asig", asig);
            

            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
            cmd.Dispose();
            Close();
        }

    }
}
