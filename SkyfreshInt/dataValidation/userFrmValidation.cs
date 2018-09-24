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


//Note: select and search method is identical
//static method to connect database

namespace SkyfreshInt.dataValidation
{
    class userFrmValidation
    {

            static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;


        #region Select Data in database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblUsers"; //Select all the data in tblusers database
                SqlCommand cmd = new SqlCommand(sql, conn); // create sql command using sql query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd); //this will all get the data from database using cmd
                conn.Open(); //this will open database connection
                adapter.Fill(dt);  // all the data that is hold by the adapter inside datatable dt

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close(); // close the database

            }
            return dt; //return the data on datatable
        }

        #endregion
        
        #region Insert Data on database

        public bool Insert (userGetSet user)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "INSERT INTO tblUsers (firstName, lastName,email,username,password,contact,gender,userType, addedDate,addedBy) VALUES (@firstName, @lastName,@email,@username,@password,@contact,@gender,@userType, @addedDate,@addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);


                // add value to parameters
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@contact", user.contact);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@userType", user.userType);
                cmd.Parameters.AddWithValue("@addedDate", user.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", user.addedBy);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();  

                //if the query is executed success then the value to rows will be greater that 0 else 
                // it will be less than 0

                if (rows > 0)
                {
                    //query successfull
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close(); 

            }
            return isSuccess;
        }


        #endregion

        #region Update Data in database
        public bool update (userGetSet user)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Update tblusers set firstName=@firstName, lastName=@lastName,email=@email,username=@username,password=@password,contact=@contact,gender=@gender,userType=@userType, addedDate=@addedDate,addedBy=@addedBy where userId=@userId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@contact", user.contact);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@userType", user.userType);
                cmd.Parameters.AddWithValue("@addedDate", user.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", user.addedBy);
                cmd.Parameters.AddWithValue("@userId", user.userId);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //query successful
                    isSuccess = true;
                }
                else
                {
                    //query failed
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
                
            }
            return isSuccess;
        }


        #endregion

        #region delete data in database

        public bool delete (userGetSet user)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Delete from tblUsers where userId=@userID";

                SqlCommand cmd = new SqlCommand(sql, conn);

            
                cmd.Parameters.AddWithValue("@userID", user.userId);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //suceessful
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return isSuccess; 
        }

        #endregion

        #region Search User 

        public DataTable search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblUsers where userId Like '%"+keywords+ "%' or lastName like'%"+ keywords+ "%' or userName like '%" + keywords + "%'";
                //Select specifica  data in tblusers to search 
                SqlCommand cmd = new SqlCommand(sql, conn); // create sql command using sql query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd); //this will all get the data from database using cmd
                conn.Open(); //this will open database connection
                adapter.Fill(dt);  // all the data that is hold by the adapter inside datatable dt

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close(); // close the database

            }
            return dt; //return the data on datatable
        }

        #endregion

        #region Getting userid from username

        public userGetSet getUsernameId (string username)
        {
            userGetSet userInfo = new userGetSet ();

            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();

            try
            {

                string sql = "Select userId from tblUsers where username = '"+username+"'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count >0)
                {
                    userInfo.userId = int.Parse(dt.Rows[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return userInfo;
        }

        #endregion

    }
}
