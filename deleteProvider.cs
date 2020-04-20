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
    public partial class deleteProvider : Form
    {
        public deleteProvider()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();

            // TextBox variable
            string inputProvider = textBox1.Text;

            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            // Check if exists provider in DB
            string testQuery = "SELECT * FROM Furnizori WHERE denumireFurnizor = '" + inputProvider + "'";
            SqlDataAdapter sda = new SqlDataAdapter(testQuery, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                pictureBox3.Hide();
                pictureBox2.Show();
            }
            else
            {
                pictureBox3.Hide();
                // Query
                string query = "DELETE Carti FROM Carti INNER JOIN Furnizori ON Carti.idFurnizor = Furnizori.idFurnizor ";
                query += "WHERE denumireFurnizor = N'" + inputProvider + "'";
                string query2 = "DELETE FROM Furnizori WHERE denumireFurnizor = N'" + inputProvider + "'";

                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlCommand command2 = new SqlCommand(query2, sqlcon);
                sqlcon.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                pictureBox1.Show();
            }
        }

        private void deleteProvider_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
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
