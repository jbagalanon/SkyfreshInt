using SkyfreshInt.dataValidation;
using SkyfreshInt.GetterSetter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyfreshInt.UserInterface
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // this code will refresh the data grid view table

        private void frmUsers_Load(object sender, EventArgs e)
        {

            DataTable dt = userDetails.Select();
            dgvUsers.DataSource = dt;
        }


        //create the class, to access the data stored

        userGetSet userData = new userGetSet(); //user data get and set

        userFrmValidation userDetails = new userFrmValidation();
        // this data is responsible for data or inout validation 

        //create class for the database code, use for updating deleting data on database


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //getting the username of logged user during login which will initialiazed the login form
            //get the data from user interface

            userData.firstName = txtFirstName.Text;
            userData.lastName = txtLastName.Text;
            userData.email = txtEmail.Text;
            userData.username = txtUsername.Text;
            userData.password = txtPassword.Text;
            userData.contact = txtContact.Text;
            userData.gender = cmbGender.Text;
            userData.userType = cmbUserType.Text;
            userData.addedDate = DateTime.Now;

            //get the username of logged user in login form
            string loggedUser = frmLogin.loggedUser;

            //get the userid based on username
            userGetSet usr = userDetails.getUsernameId(loggedUser);

            userData.addedBy = usr.userId;

            //inserting data into database
            // this is the place where database validation started

            bool success = userDetails.Insert(userData); //information of user above

            if (success == true)
            {
                //data succesfully inserted
                MessageBox.Show("User successfully added");
            }
            else
            {
                //failed inserting data
                MessageBox.Show("failed to add new user");

            }
            //refreshing data table on DGV Users

            DataTable dt = userDetails.Select();
            dgvUsers.DataSource = dt;
            clearTxtBoxes();
        }
        private void clearTxtBoxes()
        {

                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtContact.Text = string.Empty;
                cmbGender.Text = string.Empty;
                cmbUserType.Text = string.Empty;
                txtUserId.Text = string.Empty;
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the value of  particular rows

            int rowIndex = e.RowIndex;

            txtUserId.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           //initialized the userId form userFrmValidation to display the currently slogin user
            
            //get the values of Gui after selecting the row in datagridview
            userData.userId = Convert.ToInt32(txtUserId.Text);
            userData.firstName = txtFirstName.Text;
            userData.lastName = txtLastName.Text;
            userData.email = txtEmail.Text;
            userData.username = txtUsername.Text;
            userData.password = txtPassword.Text;
            userData.contact = txtContact.Text;
            userData.gender = cmbGender.Text;
            userData.userType = cmbUserType.Text;
            userData.addedDate = DateTime.Now;


            userData.addedBy = 1;

            // updating data to database

            bool success = userDetails.update(userData);  
            // userdetails is the a variable of form validation where the function insert, update, delete are stored
            //userdetails.update calls the value of update inside the form validation
            // userdata is variable from getter and setters of users

            if (success == true)
            {
                //data will be updated
                MessageBox.Show("User Successfully Updated");
                clearTxtBoxes();
            }
            else
            {
                //data cant be updated
                MessageBox.Show("Failed to update user");
            }
            DataTable dt = userDetails.Select();
            dgvUsers.DataSource = dt;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete data on row
            userData.userId = Convert.ToInt32(txtUserId.Text);

            bool success = userDetails.delete(userData);
            // condition when deleting data

            if (success == true)
            {
                //user data deleted successfully
                MessageBox.Show("Data Successfully Deleted..");
            }
            else
            {
                //failed to delete user data
                MessageBox.Show("Failed to delete data");
            }
            DataTable dt = userDetails.Select();
            dgvUsers.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //get keywords from textbox
            string keywords = txtSearch.Text;

            //check the  value of txtsearch box
            if (keywords != null)
            {
                //show user keyword
                //show all users from database
                DataTable dt = userDetails.search(keywords);
                dgvUsers.DataSource = dt;
            }

            else
            {

                //show all tables
                DataTable dt = userDetails.Select();
                dgvUsers.DataSource = dt;

            }
               
        }
    }
}
