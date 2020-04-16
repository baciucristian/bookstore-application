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
    public partial class furnMax : Form
    {
        public furnMax()
        {
            InitializeComponent();
        }

        private void furnMax_Load(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            string query = "SELECT TOP(1) denumireFurnizor, tipFurnizor, adresaFurnizor, telefonFurnizor, SUM(nrExemplare) AS nr_exemplare, COUNT(idCarte) AS nr_surse FROM Furnizori ";
            query += "INNER JOIN Carti ON Furnizori.idFurnizor = Carti.idFurnizor ";
            query += "GROUP BY denumireFurnizor, tipFurnizor, adresaFurnizor, telefonFurnizor ORDER BY nr_surse DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Show data from dataTable to labels
            denumireLabel.Text = dt.Rows[0]["denumireFurnizor"].ToString();
            tipFurnizor.Text = dt.Rows[0]["tipFurnizor"].ToString();
            adresaFurnizor.Text = dt.Rows[0]["adresaFurnizor"].ToString();
            telefonFurnizor.Text = dt.Rows[0]["telefonFurnizor"].ToString();
            nrExemplare.Text = dt.Rows[0]["nr_exemplare"].ToString();
            nrSurse.Text = dt.Rows[0]["nr_surse"].ToString();
        }
    }
}
