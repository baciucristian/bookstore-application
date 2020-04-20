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
    public partial class newFurnizor : Form
    {
        public newFurnizor()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String selectedValue = bunifuDropdown1.Text;
            String denumire = textBox1.Text;
            String adresa = textBox2.Text;
            String telefon = textBox3.Text;

            // Validation of textBoxes
            bool isNumeric = int.TryParse(telefon, out int n);

            if (denumire != "" && adresa != "" && telefon != "")
            {
                if (isNumeric == true && telefon.Length == 9)
                {
                    // Database connection
                    SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

                    // Check if exists same name in DB
                    string query = "SELECT * FROM Furnizori WHERE denumireFurnizor = '" + denumire.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Furnizor existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        // Insert query
                        string insertQuery = "INSERT INTO Furnizori(denumireFurnizor, tipFurnizor, adresaFurnizor, telefonFurnizor) VALUES ";
                        insertQuery += "(N'" + denumire + "',N'" + selectedValue + "',N'" + adresa + "','" + telefon + "')";

                        SqlCommand command = new SqlCommand(insertQuery, sqlcon);
                        sqlcon.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Înregistrarea a fost efectuată cu succes!", "Ai avut succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                } else
                    MessageBox.Show("Numărul de telefon nu este valid!", "Telefon nevalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Nu puteți lăsa câmpuri goale!", "Câmpuri goale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void newFurnizor_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.SelectedIndex = 0;
        }
    }
}
