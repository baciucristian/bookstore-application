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
    public partial class newAuthor : Form
    {
        public newAuthor()
        {
            InitializeComponent();
        }

        private void newAuthor_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String dateString = bunifuDatepicker1.Value.ToString("dd.MM.yyyy");
            DateTime date = DateTime.Parse(dateString);
            String radioButton;
            DateTime today = DateTime.Today;

            if (radioButton3.Checked)
            {
                radioButton = "F";
            } else
                radioButton = "M";

            if (name != "")
            {
                if (date <= today)
                {
                    // Database connection
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

                    // Check if exists same name in DB
                    string query = "SELECT * FROM Autori WHERE numeAutor = '" + name + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Autor existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        // Insert query
                        string insertQuery = "INSERT INTO Autori (numeAutor, dataAutor, genAutor) VALUES ";
                        insertQuery += "(N'" + name + "','" + dateString + "','" + radioButton + "')";

                        SqlCommand command = new SqlCommand(insertQuery, sqlcon);
                        sqlcon.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Înregistrarea a fost efectuată cu succes!", "Ai avut succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Clear();
                    }
                } else
                    MessageBox.Show("Ați selectat o dată din viitor!", "NU suntem în viitor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Nu puteți lăsa câmpuri goale!", "Câmpuri goale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
