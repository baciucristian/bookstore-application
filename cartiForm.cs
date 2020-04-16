﻿using System;
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
    public partial class cartiForm : Form
    {
        public cartiForm()
        {
            InitializeComponent();
        }

        // Show Carti table in DataGridView
        private void cartiForm_Load(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\bookstore-application\Bookstore.mdf;Integrated Security=True");
            
            string query = "SELECT denumireCarte, numeAutor, anCarte, limbaCarte, pretCarte, denumireFurnizor, nrExemplare FROM Carti ";
            query += "INNER JOIN Autori ON Carti.idAutor = Autori.idAutor ";
            query += "INNER JOIN Furnizori ON Carti.idFurnizor = Furnizori.idFurnizor";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
