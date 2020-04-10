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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void alphaBlendTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Ești sigur că dorești să ieși?", "Ieșire",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    Application.Exit();
            }
            if (e.KeyCode == Keys.Enter)
            {
                //pictureBox1.Click(pictureBox1, EventArgs.Empty);
            }
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerForm registerF = new registerForm();
            registerF.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Punem intr-o variabila datele din textbox
            string username = alphaBlendTextBox4.Text;
            string password = alphaBlendTextBox5.Text;
            
            // Validarea datelor 
            if (username == "" || password == "")
            {
                MessageBox.Show("Nu puteti lăsa câmpuri goale!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                // Conexiunea cu baza de date 
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Anul III\Practica Anul III\Bookstore\Bookstore.mdf;Integrated Security=True");
                
                // Sistemul de login
                string query = "SELECT * FROM Users WHERE Username = '" + username.Trim() + "'AND Password = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Conectat!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    //this.Hide();
                    // Form5 f5 = new Form5();
                    // f5.Show();
                } else
                {
                    MessageBox.Show("Datele introduse sunt incorecte!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loginForm_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
