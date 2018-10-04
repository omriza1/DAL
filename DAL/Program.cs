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
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                
                MySqlConnection dbConn = dal.connect();
                
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("error: {0}",ex);
                Console.ReadLine();
            }
        }
    }

}
