using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaitecSolutionLib;
using FormCustomization_Sample;
using System.Collections;
using System.Windows.Forms;
using System.Configuration;

namespace DAL
{
    public class UsersDAL
    {
        #region Declare Varible
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlConnection con = null;
        DataTable dt;
        DataSet ds;
        public DataRow dr;
        #endregion

        #region Constructor
        
        public static string _constring = ConfigurationManager.ConnectionStrings["AARRMD"].ToString();
        

        #endregion

        #region General Methods

        public void GetConnection()
        {
            con = new SqlConnection(_constring);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void CloseConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExistUser(string[] parameters)
        {
            GetConnection();
            int i;
            try
            {
                cmd = new SqlCommand("PROC_CHECK_AUTHORISED_USER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", parameters[0]);
                cmd.Parameters.AddWithValue("@Password", parameters[1]);
                cmd.Parameters.AddWithValue("@Option", parameters[2]);
                cmd.Parameters.AddWithValue("@EventId", parameters[3]);

                SqlParameter sqlp = new SqlParameter("@cnt", SqlDbType.Int, 3, null);
                sqlp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sqlp);

                cmd.ExecuteNonQuery();
                i = (int)cmd.Parameters["@cnt"].Value;
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(" Error Generated From USER_DAL.CS : " + ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                CloseConnection();
                cmd.Dispose();
            }
            return false;
        }

        public int GetUserId(string username)
        {
            GetConnection();
            try
            {
                cmd = new SqlCommand("Select dbo.FUN_GETUSERID_FROMUSERNAME(@UserName)", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                int retval = (int)cmd.ExecuteScalar();
                return retval;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(" Error Generated From USER_DAL.CS : " + ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return 0 ;
        }
        public DataTable FillEventIdCombo()
        {
            GetConnection();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PROC_GETDATA_EVENTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Option", "All");
                cmd.Parameters.AddWithValue("@Id", null);

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(" Error Generated From USER_DAL.CS : " + ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                cmd.Dispose();
                ds.Dispose();
                CloseConnection();
                da.Dispose();
            }
            return null;
        }

       #endregion

        #region Operation

        public Hashtable InsertUserData(string[] parameters)
        {
            Hashtable ht = new Hashtable();
            GetConnection();
            try
            {
                cmd = new SqlCommand("PROC_INSERT_USERS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", parameters[0]);
                cmd.Parameters.AddWithValue("@Password", parameters[1]);
                cmd.Parameters.AddWithValue("@EventId", parameters[2]);
                cmd.Parameters.AddWithValue("@UserType", parameters[3]);
                cmd.Parameters.AddWithValue("@CreatedDate", parameters[4]);
                cmd.Parameters.AddWithValue("@CreatedBy", parameters[5]);
                SqlParameter[] sp = new SqlParameter[2];
                sp[0] = new SqlParameter("@UserId",DbType.Int32);
                sp[0].Value = null;
                sp[0].Size = 5;
                sp[0].Direction = ParameterDirection.Output;
                sp[1] = new SqlParameter("@p_flg",DbType.String);
                sp[1].Value = null;
                sp[1].Size = 100;
                sp[1].Direction = ParameterDirection.Output;
                

                cmd.Parameters.AddRange(sp);
                //cmd.Parameters.AddWithValue("@UserId", parameters[0]);
                //cmd.Parameters.AddWithValue("@p_flg", parameters[1]);

                cmd.ExecuteNonQuery();
                ht.Add("UserId", cmd.Parameters["@UserId"].Value);
                ht.Add("p_flg", cmd.Parameters["@p_flg"].Value);

                return ht;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
                cmd.Dispose();
            }
            return null;
        }

        public DataTable GetUserData(string username = null, int? id = null)
        {
            GetConnection();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PROC_GETDATA_USERS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if ((username == null || username == string.Empty || username == "") &&
                    (id == null || id == 0 || id < 0))
                {
                    cmd.Parameters.AddWithValue("@Option", "All");
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.Parameters.AddWithValue("@UserName", username);
                }
                else if (id == null || id == 0 || id < 0)
                {
                    cmd.Parameters.AddWithValue("@Option", "Other");
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.Parameters.AddWithValue("@UserName", username);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Option", "Filter");
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.Parameters.AddWithValue("@UserName", username);
                }

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                da.Dispose();
                CloseConnection();
                ds.Dispose();
            }
        }

        public Hashtable DeleteUser(int? id = null)
        {
            Hashtable ht = new Hashtable();
            GetConnection();
            try
            {
                cmd = new SqlCommand("PROC_DELETE_USERS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
                SqlParameter sqlp = new SqlParameter("@p_flg", null);
                sqlp.Direction = ParameterDirection.Output;
                sqlp.Size = 5;
                cmd.Parameters.Add(sqlp);

                cmd.ExecuteNonQuery();
                ht.Add("p_flg", cmd.Parameters["@p_flg"].Value);
                return ht;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show("Error Show At 191 in USERDAL.CS : " + ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr); ;
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return null;
        }

        public Hashtable UpdateUser(string[] parameters)
        {
            Hashtable ht = new Hashtable();
            GetConnection();
            try
            {
                cmd = new SqlCommand("PROC_UPDATE_USERS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", parameters[0]);
                cmd.Parameters.AddWithValue("@Password", parameters[1]);
                cmd.Parameters.AddWithValue("@EventId", parameters[2]);
                cmd.Parameters.AddWithValue("@UserType", parameters[3]);
                cmd.Parameters.AddWithValue("@UpdatedDate", parameters[4]);
                cmd.Parameters.AddWithValue("@UpdatedBy", parameters[5]);
                cmd.Parameters.AddWithValue("@UserId", parameters[6]);
                SqlParameter sp = new SqlParameter("@p_flg", null);
                sp.Direction = ParameterDirection.Output;
                sp.Size = 100;
                cmd.Parameters.Add(sp);
                //cmd.Parameters.AddWithValue("@UserId", parameters[0]);
                //cmd.Parameters.AddWithValue("@p_flg", parameters[1]);

                cmd.ExecuteNonQuery();
                ht.Add("p_flg", cmd.Parameters["@p_flg"].Value);

                return ht;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
                cmd.Dispose();
            }
            return null;
        }

        #endregion
    }
}
