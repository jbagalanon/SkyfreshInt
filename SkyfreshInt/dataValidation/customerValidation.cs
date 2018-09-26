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
    class customerValidation
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;


        #region Select Data in customer records table
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblClients"; //Select all the data in tblusers database
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

        public bool Insert (customerGetSet customer)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "INSERT INTO tblClients  (firstName, lastName, companyName, customerType, phone, ext, mobile, street, region, city, barangay, zipCode, customerStatus, addedDate, addedBy) VALUES (@firstName, @lastName, @companyName, @customerType, @phone, @ext, @mobile, @street, @region, @city, @barangay, @zipCode, @customerStatus, @addedDate, @addedBy) ";


                SqlCommand cmd = new SqlCommand(sql, conn);


                // add value to parameters
                cmd.Parameters.AddWithValue("@firstName", customer.firstName);
                cmd.Parameters.AddWithValue("@lastName", customer.lastName);
                cmd.Parameters.AddWithValue("@companyName", customer.companyName);
                cmd.Parameters.AddWithValue("@customerType", customer.customerType);
                cmd.Parameters.AddWithValue("@phone", customer.phone);
                cmd.Parameters.AddWithValue("@ext", customer.ext);
                cmd.Parameters.AddWithValue("@mobile", customer.mobile);
                cmd.Parameters.AddWithValue("@street", customer.street);
                cmd.Parameters.AddWithValue("@region", customer.region);
                cmd.Parameters.AddWithValue("@city", customer.city);
                cmd.Parameters.AddWithValue("@barangay", customer.barangay);
                cmd.Parameters.AddWithValue("@zipCode", customer.zipCode);
                cmd.Parameters.AddWithValue("@customerStatus", customer.customerStatus);
                cmd.Parameters.AddWithValue("@addedDate", customer.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", customer.addedBy);
              
                
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
        public bool update(customerGetSet customer)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Update tblClients set firstName=@firstName, lastName=@lastName, companyName=@companyName, customerType=@customerType, phone=@phone, ext=@ext, mobile=@mobile, street=@street, region=@region, city=@city, barangay=@barangay, zipCode=@zipCode, customerStatus=@customerStatus, addedDate=@addedDate, addedBy=@addedBy where customerId=@customerId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // add value to parameters
                cmd.Parameters.AddWithValue("@firstName", customer.firstName);
                cmd.Parameters.AddWithValue("@lastName", customer.lastName);
                cmd.Parameters.AddWithValue("@companyName", customer.companyName);
                cmd.Parameters.AddWithValue("@customerType", customer.customerType);
                cmd.Parameters.AddWithValue("@phone", customer.phone);
                cmd.Parameters.AddWithValue("@ext", customer.ext);
                cmd.Parameters.AddWithValue("@mobile", customer.mobile);
                cmd.Parameters.AddWithValue("@street", customer.street);
                cmd.Parameters.AddWithValue("@region", customer.region);
                cmd.Parameters.AddWithValue("@city", customer.city);
                cmd.Parameters.AddWithValue("@barangay", customer.barangay);
                cmd.Parameters.AddWithValue("@zipCode", customer.zipCode);
                cmd.Parameters.AddWithValue("@customerStatus", customer.status);
                cmd.Parameters.AddWithValue("@addedDate", customer.addedDate);
                cmd.Parameters.AddWithValue("@addedBy", customer.addedBy);
                cmd.Parameters.AddWithValue("@customerId", customer.customerId);


                //open database connection
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

        #region delete client in tblClients table

        public bool delete(customerGetSet customer)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Delete from tblClients where customerId=@customerID";

                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@customerID", customer.customerId);

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

        #region Search customer name in customer records

        public DataTable search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblClients where customerId Like '%" + keywords + "%'or companyName like'%" + keywords + "%'  or lastName like'%" + keywords + "%' or lastName like '%" + keywords + "%'";
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
