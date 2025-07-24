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
    public partial class ProgramForm : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MediciDatabase.mdf;Integrated Security=True;";
        public ProgramForm()
        {
            InitializeComponent();
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            DateTime data = dtp.Value.Date;

            var con = new SqlConnection(connStr);
            con.Open();

            string query = "SELECT Data, Ora, NrCabinet FROM Programari WHERE Nume_medic = @nume AND Prenume_medic = @prenume AND Data = @data";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nume", nume);
            cmd.Parameters.AddWithValue("@prenume", prenume);
            cmd.Parameters.AddWithValue("@data", data);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dgvProgram.DataSource = dt;

            if (dgvProgram.RowCount == 1)
                MessageBox.Show("Momentan nu există nicio înregistrare pentru această dată", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

            da.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
    }
}
