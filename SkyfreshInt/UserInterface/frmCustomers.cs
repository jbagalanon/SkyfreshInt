using SkyfreshInt.dataValidation;
using SkyfreshInt.GetterSetter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyfreshInt.UserInterface
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        //call the getter and setter of the clients and initialize it

        customerGetSet cust = new customerGetSet();

        //call the customer validation class ang initialize it

        customerValidation custValidation = new customerValidation();

        //call the user validation 

        userFrmValidation userDetails = new userFrmValidation();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region All informartion when the add button of customer form press

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get the value from user table by implementing initialize customer getter setter variable
            // which is the variable "cust"

            cust.firstName = txtFirstName.Text;
            cust.lastName = txtLastName.Text;
            cust.companyName = txtCompanyName.Text;
            cust.customerType = cboCustomerType.Text;
            cust.customerStatus = cboClientStatus.Text;
            cust.phone = txtPhone.Text;
            cust.ext = txtExtension.Text;
            cust.mobile = txtMobile.Text;
            cust.street = txtStreet.Text;
            cust.region = txtRegion.Text;
            cust.city = txtCity.Text;
            cust.barangay = txtBarangay.Text;
            cust.zipCode = txtZip.Text;
            cust.addedDate = DateTime.Now;

            //get the username of logged user in login form
            string loggedUser = frmLogin.loggedUser;

            //get the userid based on username
             userGetSet usr = userDetails.getUsernameId(loggedUser);
             cust.addedBy = usr.userId;

            //inserting data into database
            // this is the place where database validation started

            bool success = custValidation.Insert(cust); //information of user above

            if (success == true)
            {
                //data succesfully inserted
                MessageBox.Show("Customer successfully added");
            }
            else
            {
                //failed inserting data
                MessageBox.Show("failed to add new customer");

            }
            //refreshing data table on DGV Users

            DataTable dt = custValidation.Select();
            dgvClients.DataSource = dt;
            clearTxtBoxes();
        
        }
        #endregion

        #region method in clearing text boxes
        private void clearTxtBoxes()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            cboCustomerType.Text = string.Empty;
            cboClientStatus.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtExtension.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtRegion.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtBarangay.Text = string.Empty;
            txtZip.Text = string.Empty;
            txtCustomerId.Text = string.Empty;
        }

        #endregion

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            DataTable dt = custValidation.Select();
            dgvClients.DataSource = dt;
        }
    }
}

