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
    public partial class pretTotal : Form
    {
        public pretTotal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pretTotal_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            title1.Hide();
            title2.Hide();
            yearLabel.Hide();
            moneyLabel.Hide();
            label2.Hide();
            pictureBox3.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            // TextBox variable
            string inputYear = textBox1.Text;

            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

            // Query
            string query = "SELECT SUM(pretCarte) AS totalPret FROM Carti WHERE anCarte = '" + inputYear + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Check if exists rows with inputYear
            if (DBNull.Value.Equals(dt.Rows[0][0]))
            {
                pictureBox1.Show();
            } else
            {
                yearLabel.Text = inputYear;
                moneyLabel.Text = dt.Rows[0][0].ToString();

                title1.Show();
                title2.Show();
                yearLabel.Show();
                moneyLabel.Show();
                label2.Show();
                pictureBox3.Show();
            }


        }
    }
}
