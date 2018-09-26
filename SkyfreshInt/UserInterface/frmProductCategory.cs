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
    public partial class frmProductCategory : Form
    {
        public frmProductCategory()
        {
            InitializeComponent();
        }

        //initialiaze the classes connected to this form, the getter setter and the validation class
        //accessing gettter and setters of product category
        productCategoryGetSet prod = new productCategoryGetSet();

        //accessing product category validation
        productCategoryValidation prodCatValid = new productCategoryValidation();

        //accessing user validation, this class will check who is the current user and it will be added to addedBy variables

        userFrmValidation userDetails = new userFrmValidation();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region Data to be executed when pressing add button

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //get the values inserted from product category form
            prod.title = txtProductTitle.Text;
            prod.description = txtProductDesc.Text;
            prod.addedDate = DateTime.Now;
                       
            
            //getting the id of logged user, just copy back here those code
            //get the username of logged user in login form
            string loggedUser = frmLogin.loggedUser;

            //get the userid based on username
            userGetSet usr = userDetails.getUsernameId(loggedUser);

            prod.addedBy = usr.userId;

            //inserting data into database


            bool success = prodCatValid.Insert(prod); //information of user above

            if (success == true)
            {
                //data succesfully inserted
                MessageBox.Show("Product category successfully added");
            }
            else
            {
                //failed inserting data
                MessageBox.Show("failed to add new product category");

            }
            //refreshing data table on DGV Users

            DataTable dt = prodCatValid.Select();
            dgvProductCategory.DataSource = dt;
            clearTxtBoxes();


        }

        #endregion

        #region Updating records in tblproduct category buttons

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the values inserted from product category form

            prod.categoryId = int.Parse (txtProductId.Text);
            prod.title = txtProductTitle.Text;
            prod.description = txtProductDesc.Text;
            prod.addedDate = DateTime.Now;


            //getting the id of logged user, just copy back here those code
            //get the username of logged user in login form
            string loggedUser = frmLogin.loggedUser;

            //get the userid based on username
            userGetSet usr = userDetails.getUsernameId(loggedUser);

            prod.addedBy = usr.userId;

            //inserting data into database


            bool success = prodCatValid.Insert(prod); //information of user above

            if (success == true)
            {
                //data succesfully inserted
                MessageBox.Show("Product Category successfully added");
            }
            else
            {
                //failed inserting data
                MessageBox.Show("failed to add new product category");

            }
            //refreshing data table on DGV Users

            DataTable dt = prodCatValid.Select();
            dgvProductCategory.DataSource = dt;
            clearTxtBoxes();


        }
        #endregion

        #region Clearing product categories boxes


        private void clearTxtBoxes()
        {
            txtProductId.Text = string.Empty;
            txtProductTitle.Text = string.Empty;
            txtProductDesc.Text = string.Empty;

        }

        #endregion

        #region Dispalaying Value in Cells DGV

        private void dgvProductCategory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;

            txtProductId.Text = dgvProductCategory.Rows[RowIndex].Cells[0].Value.ToString();
            txtProductTitle.Text = dgvProductCategory.Rows[RowIndex].Cells[1].Value.ToString();
            txtProductDesc.Text = dgvProductCategory.Rows[RowIndex].Cells[2].Value.ToString();
        }

        #endregion

        #region deleting data in product categories 

        private void btnDelete_Click(object sender, EventArgs e)
        {

           
            //get the id of the category which we want to delete

            prod.categoryId = int.Parse(txtProductId.Text);

            //creating boolean

            bool success = prodCatValid.delete (prod);

            //if the category id deleted successfully then the value of success will be true else it will false
            if (success == true)
            {
                MessageBox.Show("Product category deleted successfully");
             
                
            }
            else
            {
                //failed to delete category
                MessageBox.Show("Failed to delete category");
            }
            DataTable dt = prodCatValid.Select();
            dgvProductCategory.DataSource = dt;

        }

        #endregion

        #region Searching the product inside the product category dgv

        private void frmProductCategory_Load(object sender, EventArgs e)
        {
            DataTable dt = prodCatValid.Select();
            dgvProductCategory.DataSource = dt;
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            //get keywords from textbox
            string keywords = txtProductSearch.Text;

            //check the  value of txtsearch box
            if (keywords != null)
            {
                //show user keyword
                //show all users from database
                DataTable dt = prodCatValid.search(keywords);
                dgvProductCategory.DataSource = dt;
            }

            else
            {

                //show all tables
                DataTable dt = prodCatValid.Select();
                dgvProductCategory.DataSource = dt;

            }
        }
        #endregion
    }
}

