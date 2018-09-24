using SkyfreshInt.GetterSetter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyfreshInt.dataValidation
{
    class loginValidation
    {

        //connect to database
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        

        public bool loginCheck(userLogin userValidation  )
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);
            //connectiong to a database



            try
            {
                //access the database table
                string sql = "Select * from tblUsers where username=@username And password=@password And userType=@userType";

                //command to pass value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //pass value to parameters using command
                cmd.Parameters.AddWithValue("@username", userValidation.username);
                cmd.Parameters.AddWithValue("@password", userValidation.password);
                cmd.Parameters.AddWithValue("@userType", userValidation.userType);


                //store data to database temporarily 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //hold the data data in adaoter temporarily

                DataTable dt = new DataTable();

                //fill the data table
                adapter.Fill(dt);

                // check the datable rows

                if (dt.Rows.Count > 0)
                {
                    //login successful
                    isSuccess = true;
                }
                else
                {
                    //login failed
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close database connection

                conn.Close();
            }

            return isSuccess;
        }
    }
}
