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
using System.Threading;

namespace Bookstore
{
    public partial class registerMenu : Form
    {
        public registerMenu()
        {
            InitializeComponent();
        }

        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                menuForm menuForm = new menuForm(null);
                menuForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new newFurnizor());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new newAuthor());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new newBook());
        }

        private void registerMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            menuForm menuForm = new menuForm(null);
            menuForm.Show();
        }
    }
}
