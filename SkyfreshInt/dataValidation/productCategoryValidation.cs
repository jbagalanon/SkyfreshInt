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
    class productCategoryValidation
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region Select Data in tblProductCategory Table
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblProductCategory"; //Select all the data in tblusers database
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

        public bool Insert(productCategoryGetSet prodCategory)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "INSERT INTO tblProductCategory (title, description, addedDate,addedBy) VALUES  (@title, @description, @addedDate, @addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);


                // add value to parameters
                cmd.Parameters.AddWithValue("@title", prodCategory.title);
                cmd.Parameters.AddWithValue("@description", prodCategory.description);
                cmd.Parameters.AddWithValue("@addedDate", prodCategory.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", prodCategory.addedBy);

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

        #region Update Data in tblProductCategory Table
        public bool update(productCategoryGetSet prodCategory)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Update tblProductCategory set title=@title, description=@description, addedDate=@addedDate,addedBy=@addedBy where categoryId=@categoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@title", prodCategory.title);
                cmd.Parameters.AddWithValue("@description", prodCategory.description);
                cmd.Parameters.AddWithValue("@addedDate", prodCategory.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", prodCategory.addedBy);
                cmd.Parameters.AddWithValue("@userId", prodCategory.categoryId);

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

        #region delete data in tblProductCategory Table

        public bool delete(productCategoryGetSet prodCategory)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Delete from tblProductCategory where categoryId=@categoryId";

                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@categoryId", prodCategory.categoryId);
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

        #region Search product categoy in tblProductCategory Table

        public DataTable search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblProductCategory where categoryId Like '%" + keywords + "%' or title like'%" + keywords + "%' or description like '%" + keywords + "%'";
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

    
    }
}
