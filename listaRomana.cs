using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bookstore
{
    public partial class listaRomana : Form
    {
        public listaRomana()
        {
            InitializeComponent();
        }

        private void listaRomana_Load(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            string query = "SELECT denumireCarte, numeAutor, limbaCarte, nrExemplare FROM Carti ";
            query += "INNER JOIN Autori ON Carti.idAutor = Autori.idAutor ";
            query += "WHERE limbaCarte = N'Română'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
