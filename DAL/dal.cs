using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DAL
{
    //singelton
    class dal
    {
        //Methods:
        //connect - using connection pool
        public static MySqlConnection connect()
        {

            MySqlConnection conn = null;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DATABASE"].ConnectionString;
                conn = new MySqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("MySQL version : {0}", conn.ServerVersion);
                return conn;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                throw ex;

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public static void Execute(string com)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DATABASE"].ConnectionString);

            cn.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = cn;

            command.CommandText = com;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


        public static DataTable GetTable(string com)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DATABASE"].ConnectionString);

            MySqlCommand command = new MySqlCommand();
            command.Connection = cn;
            command.CommandText = com;

            DataTable dt = new DataTable();
            dt.TableName = "tbl";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            try
            {
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }
    }
}
