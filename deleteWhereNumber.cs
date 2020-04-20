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
    public partial class deleteWhereNumber : Form
    {
        public deleteWhereNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            // TextBox variable
            string inputNumber = textBox1.Text;

            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            // Check if exists provider in DB
            string testQuery = "SELECT * FROM Carti WHERE NrExemplare = '" + inputNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(testQuery, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                pictureBox2.Show();
            }
            else
            {
                // Query
                string query = "DELETE FROM Carti WHERE NrExemplare = '" + inputNumber + "'";
                SqlCommand command = new SqlCommand(query, sqlcon);
                sqlcon.Open();
                command.ExecuteNonQuery();

                pictureBox3.Show();
                textBox1.Clear();
            }
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
