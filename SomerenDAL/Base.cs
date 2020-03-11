using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public abstract class Base
    {
        private SqlDataAdapter adapter;
        private SqlConnection conn;
        public Base()
        {
            // DO NOT FORGET TO INSERT YOUR CONNECTION STRING NAMED 'SOMEREN DATABASE' IN YOUR APP.CONFIG!!

            

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
                adapter = new SqlDataAdapter();
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }

            /*OpenConnection();*/
            /*SqlCommand cmd = new SqlCommand("SELECT FROM * Student", conn);
            SqlDataReader reader = cmd.ExecuteReader();*/


            /*List<Student> students = new List<Student>();*/

            //CloseConnection();

        }

        protected SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        private void CloseConnection()
        {
            conn.Close();
        }

        /* For Insert/Update/Delete Queries with transaction */
        protected void ExecuteEditTranQuery(String query, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction)
        {
            SqlCommand command = new SqlCommand(query, conn, sqlTransaction);
            try
            {
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Print.ErrorLog(e);
                throw new Exception(e.ToString());
            }
        }

        /* For Insert/Update/Delete Queries */
        protected void ExecuteEditQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
               // Print.ErrorLog(e);
                throw new Exception(e.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }



        /* For Select Queries */
        protected DataTable ExecuteSelectQuery(String query, params SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException e)
            {
               // Print.ErrorLog(e);
                return null;
                throw new Exception(e.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
    }
}
