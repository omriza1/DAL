using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    class UserMethods
    {
        #region Insert
        //gets all the users
        public static DataTable getalluser()
        {
            string com = "select * from watts_users";
            return dal.GetTable(com);
        }

        //adds a user to the database
        public static void adduser(string user_name, string password)
        {
            string com = "insert into watts_users (user_name,user_password) VALUES ('" + user_name + "','" + password + "')";
            dal.Execute(com);
        }
        #endregion

        #region Delete
        //deletes a user from the database
        public static void deleteuser(string username)
        {
            string com = "DELETE FROM watts_users WHERE user_name='" + username + "'";
            dal.Execute(com);
        }

        #endregion

        #region Update
        //changes the password for a user
        public static void ChangePassword(string user_name, string newPassword)
        {
            //updates the password of a user
            string com = "update watts_users set user_password='" + newPassword + "' where user_name = '" + user_name + "'";
            dal.Execute(com);
        }
        #endregion

        #region Select
        //checks if the user exists for the login by counting how many times its username and password are in the database(can't be more then once for simplicity)
        public static bool userExist(string username, string password)
        {
            string com = "select user_name from watts_users where user_name = '" + username + "'";
            string com2 = "select user_password from watts_users where user_password = '" + password + "'";
            return dal.GetTable(com).Rows.Count > 0 && dal.GetTable(com2).Rows.Count > 0;
        }

        //checks if the user exists for sending a message for example by counting how many times its username and password are in the database
        public static bool userExist(string username)
        {
            string com = "select user_name from watts_users where user_name = '" + username + "'";
            return dal.GetTable(com).Rows.Count > 0;
        }

        #endregion
    }
}
