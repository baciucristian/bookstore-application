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
    public partial class cartiLimbaForm : Form
    {

        public cartiLimbaForm()
        {
            InitializeComponent();
        }

        private void cartiLimbaForm_Load(object sender, EventArgs e)
        {
            button1.Hide();
        }

        private void cartiLimbaForm_Shown(object sender, EventArgs e)
        {
        }

        private void cartiLimbaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void cartiLimbaForm_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string inputValue = searchForm;
            MessageBox.Show("Form is show!");
            //// Database connection
            //SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            //// Check if exists rows with inputWord
            //string query = "SELECT denumireCarte, numeAutor, anCarte, limbaCarte, pretCarte, denumireFurnizor FROM Carti ";
            //query += "INNER JOIN Autori ON Carti.idAutor = Autori.idAutor ";
            //query += "INNER JOIN Furnizori ON Carti.idFurnizor = Furnizori.idFurnizor ";
            //query += "WHERE limbaCarte = '" + inputValue + "'";
            //SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    pictureBox1.Show();
            //}
        }
    }
}
