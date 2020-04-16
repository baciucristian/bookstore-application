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
            dataGridView1.Hide();
            pictureBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            dataGridView1.Hide();
            // TextBox variable
            string inputWord = textBox1.Text;

            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            // Query
            string query = "SELECT denumireCarte, numeAutor, anCarte, limbaCarte, pretCarte, denumireFurnizor FROM Carti ";
            query += "INNER JOIN Autori ON Carti.idAutor = Autori.idAutor ";
            query += "INNER JOIN Furnizori ON Carti.idFurnizor = Furnizori.idFurnizor ";
            query += "WHERE limbaCarte = N'" + inputWord + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            // Check if exists rows with inputValue
            if (dt.Rows.Count == 0)
            {   
                pictureBox1.Show();
            } else 
                dataGridView1.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();

                // Disable beep sound
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
