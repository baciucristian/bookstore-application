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
    public partial class newBook : Form
    {
        public newBook()
        {
            InitializeComponent();
        }

        // Database connection
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String denumire = textBox1.Text;
            int provider = bunifuDropdown1.selectedIndex + 1;
            int author = bunifuDropdown2.selectedIndex + 1;
            int language = bunifuDropdown3.selectedIndex + 1;
            decimal price = numericUpDown1.Value;
            decimal year = numericUpDown2.Value;
            decimal nrExemplare = numericUpDown3.Value;

            if (denumire != "")
            {
                // Check if exists same name in DB
                string query = "SELECT * FROM Carti WHERE denumireCarte = '" + denumire + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Carte existentă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    // Insert query
                    string insertQuery = "INSERT INTO Carti (idFurnizor, denumireCarte, idAutor, anCarte, idLimba, pretCarte, nrExemplare) VALUES ";
                    insertQuery += "(@idFurnizor, @denumireCarte, @idAutor, @anCarte, @idLimba, @pretCarte, @nrExemplare)";

                    using (SqlCommand command = new SqlCommand(insertQuery, sqlcon))
                    {
                        command.Parameters.AddWithValue("@idFurnizor", provider);
                        command.Parameters.AddWithValue("@denumireCarte", denumire);
                        command.Parameters.AddWithValue("@idAutor", author);
                        command.Parameters.AddWithValue("@anCarte", year);
                        command.Parameters.AddWithValue("@idLimba", language);
                        command.Parameters.AddWithValue("@pretCarte", price);
                        command.Parameters.AddWithValue("@nrExemplare", nrExemplare);

                        sqlcon.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Înregistrarea a fost efectuată cu succes!", "Ai avut succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                    }
                }
            } else
                MessageBox.Show("Nu puteți lăsa câmpuri goale!", "Câmpuri goale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void newBook_Load(object sender, EventArgs e)
        {
            // bunifuDropdown1 providers
            string query = "SELECT * FROM Furnizori";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                bunifuDropdown1.AddItem(dr["denumireFurnizor"].ToString());
            }

            // bunifuDropdown2 author
            string query2 = "SELECT * FROM Autori";
            SqlDataAdapter sda2 = new SqlDataAdapter(query2, sqlcon);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {
                bunifuDropdown2.AddItem(dr["numeAutor"].ToString());
            }

            // bunifuDropdown3 languages
            string query3 = "SELECT * FROM Limbi ORDER BY idLimba";
            SqlDataAdapter sda3 = new SqlDataAdapter(query3, sqlcon);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);

            foreach (DataRow dr in dt3.Rows)
            {
                bunifuDropdown3.AddItem(dr["numeLimba"].ToString());
            }

            bunifuDropdown1.selectedIndex = 0;
            bunifuDropdown2.selectedIndex = 0;
            bunifuDropdown3.selectedIndex = 0;
        }
    }
}
