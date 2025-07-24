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
    public partial class PrezentareForm : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MediciDatabase.mdf;Integrated Security=True;";
        public PrezentareForm()
        {
            InitializeComponent();
            PopuleazaListSectii();
        }

        private void PopuleazaListSectii()
        {
            var con = new SqlConnection(connStr);
            con.Open();
            string query = "SELECT Denumire FROM Secții";
            var cmd = new SqlCommand(query, con);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listSectii.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
        private void listSectii_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sectia = listSectii.SelectedItem.ToString();

            var con = new SqlConnection(connStr);
            con.Open();

            string query = "SELECT Nume, Prenume, Titulatură FROM Medici WHERE Specialitate = @sectia";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sectia", sectia);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMedici.DataSource = dt;

            da.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }

    }
}
