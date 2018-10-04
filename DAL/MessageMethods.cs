using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    class MessageMethods
    {
        #region Select
        //inserts a message to the database with the sender and the reciver of the message
        public static void SendMessagePrivate(string user_name, string content, string reciver)
        {

            if (UserMethods.userExist(user_name) && UserMethods.userExist(reciver))
            {
                string com = "INSERT INTO watts_private_messages (sender,content,reciver,Mdate) VALUES ('" + user_name + "','" + content + "','" + reciver + "','" + DateTime.Now.ToString() + "')";
                dal.Execute(com);
            }
            else if (!UserMethods.userExist(reciver))
            {
                Console.WriteLine("the reciver of the message does not exist");
            }
        }

        //check if a message exists in the database
        public static DataTable searchMessage(int messageId, string content)
        {
            string com = "select content from watts_private_messages where content = '" + content + "' and messageID =" + messageId + "";
            return dal.GetTable(com);
            //Console.WriteLine(dt.Rows[0]["content"].ToString()); ככה ניגשים לתוכן של התא בטבלה  
        }
        #endregion

        #region Delete
        //deletes a message from the database
        public static void deleteMessage(int messageId)
        {
            string com = "DELETE  FROM watts_private_messages WHERE messageID=" + messageId;
            dal.Execute(com);
        }
        /*//deletes all messages from database
        public static void deleteMessageAll()
        {
            string com = "DELETE FROM watts_private_messages";
            dal.Execute(com);
        }
        */
        #endregion

        #region Update
        //edits the content of a message
        public static void EditMessage(int messageId, string newContent)
        {
            string com = "update watts_private_message set content=" + newContent + " where messageID= " + messageId;
            dal.Execute(com);
        }
        #endregion 
    }
}
