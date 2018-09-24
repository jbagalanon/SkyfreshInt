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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        userLogin userIn = new userLogin(); // call the userlogin getters and setters
        loginValidation logValid = new loginValidation(); // call the login validation

        //when use successfully login 
        public static string loggedUser;


        private void btnLogin_Click(object sender, EventArgs e)
        {
            userIn.username = txtUsername.Text.Trim();
            userIn.password = txtPassword.Text.Trim();
            userIn.userType = cmbUserType.Text.Trim();

            //checking the login credentials

            bool success = logValid.loginCheck(userIn);

            //check of credentials is correct
         
            if (success == true)
            {

                MessageBox.Show("Login Successful");
                loggedUser = userIn.username;

                switch (userIn.userType)
                {
                    case "ADMIN":
                        {
                     
                           
                            //display admin dashboard
                            frmAdminDashboad admin = new frmAdminDashboad();
                            admin.Show();
                            this.Hide();
                            break;
                        }
                      
                    case "USER":
                        {
                            //show user dashboard
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                            break;

                        }
                     

                    default:
                        {
                            MessageBox.Show("Select User Type");
                            break;
                        }
                        
                }
             
            }
            else
            {
                MessageBox.Show("Login Failed.. Try Again");
            
            }
        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
;