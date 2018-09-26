using SkyfreshInt.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyfreshInt
{
    public partial class frmAdminDashboad : Form
    {
        public frmAdminDashboad()
        {
            InitializeComponent();
        }

      

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            log.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers userInfo = new frmUsers();
            userInfo.Show();
        }

        private void frmAdminDashboad_Load(object sender, EventArgs e)
        {
            lblLoggeUser.Text = frmLogin.loggedUser; 
        }

        private void productCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductCategory prodCat = new frmProductCategory();
            prodCat.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers custForm = new frmCustomers();
            custForm.Show();
        }
    }
}
