using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaitecSolutionLib;
using FormCustomization_Sample;
using System.Collections;
using System.Windows.Forms;
using DAL;
using System.Data;

namespace BAL
{
    public class UsersBAL
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string EventId { get; set; }
        public int UserId { get; set; } 
        /// <summary>
        /// Insert record into the database
        /// </summary>
        /// <returns></returns>
        /// 

        public Hashtable Add(string[] parameters)
        {
            return new UsersDAL().InsertUserData(parameters);
        }
        /// <summary>
        /// Update record into the database
        /// </summary>
        
        /// <returns></returns>
        /// 
        public Hashtable Update(string[] parameters)
        {
            return new UsersDAL().UpdateUser(parameters);
        }
        /// <summary>
        /// Delete record from the database tbale
        /// </summary>
        /// <param name="autoId"></param>
        /// <returns></returns>
        /// 
        public Hashtable Delete(int? id = null)
        {
            return new UsersDAL().DeleteUser(id);
        }
        /// <summary>
        /// Load all records from database table
        /// </summary>
        /// <returns></returns>
        /// 
        public DataTable LoadAll(string username = null,int? id = null)
        {
            return new UsersDAL().GetUserData(username, id);
        }
        /// <summary>
        /// user Exists or not in database table
        /// </summary>
        /// <returns></returns>
        /// 
        public bool ExistUser(string[] parameters)
        {
            return new UsersDAL().ExistUser(parameters);
        }
        public int GetUserId(string username)
        {
            return new UsersDAL().GetUserId(username);
        }
        public DataTable FillCombo()
        {
            return new UsersDAL().FillEventIdCombo();
        }
    }
}
