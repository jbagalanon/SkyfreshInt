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
    class chequeValidation
    {
        //connect to database. The configuratiion is located to 
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
    

    #region Select Data in Database of Cheque

    public DataTable select()

    {
        SqlConnection conn = new SqlConnection(myconnstring);

        DataTable dt = new DataTable(); //Datatable temporary store data in database

        try
        {
            string sql = "Select * from tblCheques"; //Select all the data in tblusers database
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

    #region Insert Data in cheque tables

        public bool Insert(chequesGetSet cheque)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "INSERT INTO tblCheques (accountName, bankName, chequeNo, chequeDate, amount, remarks, addedDate, addedBy) VALUES (@accountName, @bankName, @chequeNo, @chequeDate, @amount, @remarks, @addedDate, @addedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);


                // add value to parameters
                cmd.Parameters.AddWithValue("@accountName", cheque.accountName);
                cmd.Parameters.AddWithValue("@bankName", cheque.bankName);
                cmd.Parameters.AddWithValue("@chequeNo", cheque.chequeNo);
                cmd.Parameters.AddWithValue("@chequeDate", cheque.chequeDate);
                cmd.Parameters.AddWithValue("@amount", cheque.amount);
                cmd.Parameters.AddWithValue("@remarks", cheque.remarks);
                cmd.Parameters.AddWithValue("@addedDate", cheque.addedDate);
                cmd.Parameters.AddWithValue("@addedby", cheque.addedBy);

          

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

    #region Update Data in tblCheques
        public bool update (chequesGetSet cheque)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
              
                String sql = "Update tblCheques set accountName=@accountName, bankName=@bankName, chequeNo=@chequeNo, chequeDate=@chequeDate, amount=@amount, remarks=@remarks, addedDate=@addedDate, addedBy=@addedBy  where chequeId=@chequeId";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@accountName", cheque.accountName);
                cmd.Parameters.AddWithValue("@bankName", cheque.bankName);
                cmd.Parameters.AddWithValue("@chequeNo", cheque.chequeNo);
                cmd.Parameters.AddWithValue("@chequeDate", cheque.chequeDate);
                cmd.Parameters.AddWithValue("@amount", cheque.amount);
                cmd.Parameters.AddWithValue("@remarks", cheque.remarks);
                cmd.Parameters.AddWithValue("@addedDate", cheque.addedDate);
                cmd.Parameters.AddWithValue("@addedby", cheque.addedBy);
                cmd.Parameters.AddWithValue("@chequeId", cheque.chequeId);

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

    #region delete data in tblCheques

        public bool delete(chequesGetSet cheque)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);


            try
            {
                string sql = "Delete from tblCheques where chequeId=@chequeID";

                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@chequeId", cheque.chequeId);

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

    #region Search Cheques in tblCheques

        public DataTable search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstring);

            DataTable dt = new DataTable(); //Datatable temporary store data in database

            try
            {
                string sql = "Select * from tblCheques where chqueId Like '%" + keywords + "%' or accountName like'%" + keywords + "%' or bankName like'%" + keywords + "%' or remarks like '%" + keywords + "%'";
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
