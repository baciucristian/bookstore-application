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
    public partial class showForm : Form
    {
        public showForm()
        {
            InitializeComponent();
        }

        #region Design

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

        // Submenu design

        private void hideSubMenu()
        {
            if (panelTabele.Visible == true) { }
                panelTabele.Visible = false;
        }

        private void showSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
        }
        #endregion


        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                menuForm menuForm = new menuForm();
                menuForm.Show();
            }
        }


        private void btnTabele_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTabele);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new furnizoriForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new autoriForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new cartiForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new cartiLimbaForm());
        }

        private void btnMaximal_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new furnMax());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new pretTotal());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new listaAutor());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            openChildForm(new listaRomana());
        }

        private void showForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            menuForm form = new menuForm();
            form.Show();
        }
    }
}
