using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class menuForm : Form
    {
        string username;
        public menuForm(string loginUsername)
        {
            InitializeComponent();
            username = loginUsername;
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

        private void menuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Ești sigur că dorești să ieși?", "Ieșire",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            showForm f = new showForm(username);
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                this.Hide();
                registerMenu f = new registerMenu(username);
                f.Show();
            }
            else
                MessageBox.Show("Doar administratorul poate accesa această funcție!", "Eroare",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm f = new loginForm();
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (username == "admin")
            {
                this.Hide();
                deleteMenu f = new deleteMenu(username);
                f.Show();
            }
            else
                MessageBox.Show("Doar administratorul poate accesa această funcție!", "Eroare",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
        }
    }
}
