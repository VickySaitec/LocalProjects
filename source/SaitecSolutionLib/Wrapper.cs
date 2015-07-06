using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using FormCustomization_Sample;
using System.Collections;

namespace SaitecSolutionLib
{
    public class Wrapper
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlConnection con = null;
        DataTable dt;
        DataSet ds;
        string constring;
        public DataRow dr;


        public Wrapper()
        {
            constring = ConfigurationManager.ConnectionStrings["AARRMD"].ToString();  
        }

        public void GetConnection()
        {
            con = new SqlConnection(constring);
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
        public DataTable GetComboData(string spname)
        {
            GetConnection();
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@option", "All");
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "Select Any";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                dr = ds.Tables[0].NewRow();
                dr[0] = ds.Tables[0].Rows.Count ;
                dr[1] = "Others";
                ds.Tables[0].Rows.InsertAt(dr, ds.Tables[0].Rows.Count);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
            
        }
        public bool InsertData(string[] parameters)
        {
            GetConnection();
            try
            {
                cmd = new SqlCommand("INSERT_MEMBER_REGISTRATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@reg_id", SqlDbType.Int).Value = null;
                cmd.Parameters.AddWithValue("@registrationid", parameters[0]);
                cmd.Parameters.AddWithValue("@first_name", parameters[1]);
                cmd.Parameters.AddWithValue("@last_name", parameters[2]);
                cmd.Parameters.AddWithValue("@busi_name", parameters[3]);
                cmd.Parameters.AddWithValue("@type_busi", parameters[4]);
                cmd.Parameters.AddWithValue("@busi_Add", parameters[5]);
                cmd.Parameters.AddWithValue("@country", parameters[6]);
                cmd.Parameters.AddWithValue("@city", parameters[7]);
                cmd.Parameters.AddWithValue("@county", parameters[8]);
                cmd.Parameters.AddWithValue("@state", parameters[9]);
                cmd.Parameters.AddWithValue("@zip", parameters[10]);
                cmd.Parameters.AddWithValue("@busi_phone", parameters[11]);
                cmd.Parameters.AddWithValue("@cell_phone", parameters[12]);
                cmd.Parameters.AddWithValue("@email", parameters[13]);
                cmd.Parameters.AddWithValue("@website", parameters[14]);
                cmd.Parameters.AddWithValue("@memeber_aara", parameters[15]);


                int i = cmd.ExecuteNonQuery();
                if (i == -1)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message) ;
            }
            return true;
        }
        public DataTable SearchData(string spname,string bphone,string cphone)
        {
            GetConnection();
            ds = new DataSet();
            try
            {
                if (bphone == string.Empty)
                    bphone = null;
                if (cphone == string.Empty)
                    cphone = null;
                cmd = new SqlCommand(spname, con);
                cmd.Parameters.AddWithValue("@BusinessPhone", bphone);
                cmd.Parameters.AddWithValue("@CellPhone", cphone);
                cmd.Parameters.AddWithValue("@Option", "Software");
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SqlDataReader GetFilteredData(string spname,string bphone,string cphone,string regid)
        {
            GetConnection();
            ds = new DataSet();
            SqlDataReader dr;
            try
            {
                cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@reg_id", regid);
                cmd.Parameters.AddWithValue("@business_phone", bphone);
                cmd.Parameters.AddWithValue("@cell_phone", cphone);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dr;
        }
        public int InsertData(string[] parameters, string sp,string tab)
        {
            GetConnection();
            int i = 0;
            try
            {
                cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (tab == "State")
                {
                    cmd.Parameters.AddWithValue("@StateName", parameters[0]);
                    cmd.Parameters.AddWithValue("@CountryId", parameters[1]);
                    SqlParameter outputparam = new SqlParameter("@stateid",SqlDbType.Int);
                    outputparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputparam);
                    cmd.ExecuteNonQuery();
                    i = (int)cmd.Parameters["@stateid"].Value;
                    return i;

                    
                }
                if (tab == "BusinessType")
                {
                    cmd.Parameters.AddWithValue("@BUSITYPE", parameters[0]);
                    SqlParameter outputparam = new SqlParameter("@businessid", SqlDbType.Int);
                    outputparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputparam);
                    cmd.ExecuteNonQuery();
                    i = (int)cmd.Parameters["@businessid"].Value;
                    return i;
                }
                if (tab == "County")
                {
                    cmd.Parameters.AddWithValue("@STATE_ID", parameters[0]);
                    cmd.Parameters.AddWithValue("@COUNTY_NAME", parameters[1]);
                    SqlParameter outputparam = new SqlParameter("@lastid", SqlDbType.Int);
                    outputparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputparam);
                    cmd.ExecuteNonQuery();
                    i = (int)cmd.Parameters["@lastid"].Value;
                    return i;
                }
                
                
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, FormCustomization_Sample.MessageBoxStyle.Errorr);
            }
            return i;
        }
        public bool ExistEventId(string EventId)
        {
            GetConnection();
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PROC_GETDATA_EVENTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", EventId);
                cmd.Parameters.AddWithValue("@Option", "Filter");
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
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
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                CloseConnection();
                cmd.Dispose();
            }
            return false;
        }
        public bool UpdateMemberReg(string[] parameters)
        {
            GetConnection();
            try
            {
                cmd = new SqlCommand("PROC_UPDATE_MEMBER_REGISTRATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@reg_id", SqlDbType.Int).Value = parameters[0];
                //cmd.Parameters.AddWithValue("@registrationid", parameters[0]);
                cmd.Parameters.AddWithValue("@first_name", parameters[1]);
                cmd.Parameters.AddWithValue("@last_name", parameters[2]);
                cmd.Parameters.AddWithValue("@busi_name", parameters[3]);
                cmd.Parameters.AddWithValue("@type_busi", parameters[4]);
                cmd.Parameters.AddWithValue("@busi_Add", parameters[5]);
                cmd.Parameters.AddWithValue("@country", parameters[6]);
                cmd.Parameters.AddWithValue("@city", parameters[7]);
                cmd.Parameters.AddWithValue("@county", parameters[8]);
                cmd.Parameters.AddWithValue("@state", parameters[9]);
                cmd.Parameters.AddWithValue("@zip", parameters[10]);
                cmd.Parameters.AddWithValue("@busi_phone", parameters[11]);
                cmd.Parameters.AddWithValue("@cell_phone", parameters[12]);
                cmd.Parameters.AddWithValue("@email", parameters[13]);
                cmd.Parameters.AddWithValue("@website", parameters[14]);
                //cmd.Parameters.AddWithValue("@memeber_aara", parameters[14]);


                int i = cmd.ExecuteNonQuery();
                if (i == -1)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message) ;
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return false ;
        }

        public int GetScalarValue(string name, string table)
        {
            GetConnection();
            int id = 0;
            try
            {
                cmd = new SqlCommand("Select dbo.Fun_GetId_FromName(@Name,@Tab)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Tab", table);

                id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return id;
        }

        public bool InsertQrTable(string[] parameters,byte[] images)
        {
            GetConnection();
            try
            {
                cmd = new SqlCommand(parameters[0], con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@registration_id", parameters[1]);
                cmd.Parameters.AddWithValue("@img", images);

                int i = (int)cmd.ExecuteNonQuery();
                if (i == -1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return false;
        }

        public int GetImageId(string regid)
        {
            GetConnection();
            int i =  0;
            try
            {
                cmd = new SqlCommand("Select dbo.Fun_GetImageId_FromRegId(@RegId)", con);
                cmd.Parameters.AddWithValue("@RegId", regid);

                i = (int)cmd.ExecuteScalar();
                return i;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            return i;
        }

        public bool InsertRegistrationLog(string[] parameters)
        {
            GetConnection();
            int i;
            try
            {
                cmd = new SqlCommand("INSERT_REGISTRATION_LOG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@reg_id", SqlDbType.Int).Value = null;
                cmd.Parameters.Add("@registration_id", SqlDbType.NVarChar).Value = parameters[0];
                cmd.Parameters.Add("@registration_datetime", SqlDbType.DateTime).Value = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

                i = (int)cmd.ExecuteNonQuery();
                if (i == -1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return false;
        }

        public DataTable GetDataForQr(string regid)
        {
            GetConnection();
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PROC_GETDATA_QR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegId", regid);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            finally
            {
                cmd.Dispose();
                da.Dispose();
                CloseConnection();
                ds.Dispose();
            }
            return ds.Tables[0];
        }
        public DataSet ExecQueryReturnDataSetWithCommand(string p_qry)
        {
            GetConnection();
            DataSet _dsData = new DataSet();
            try
            {
                da = new SqlDataAdapter(p_qry, con);
                da.Fill(_dsData);
                return _dsData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Hashtable InsertUserData(string[] parameters,Byte[] password)
        {
            Hashtable ht = new Hashtable();
            GetConnection();
            try
            {
                cmd = new SqlCommand("PROC_INSERT_USERS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", parameters[0]);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@EventId", parameters[1]);
                cmd.Parameters.AddWithValue("@UserType", parameters[2]);
                cmd.Parameters.AddWithValue("@CreatedDate", parameters[3]);
                cmd.Parameters.AddWithValue("@CreatedBy", parameters[4]);
                SqlParameter[] sp = null;
                sp[0] = new SqlParameter("@UserId", null);
                sp[1] = new SqlParameter("@p_flg", null);

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

        public DataTable GetUserData(string username = null,int? id = null)
        {
            GetConnection();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("PROC_GETDATA_USERS", con);
                if ((username == null || username == string.Empty || username == "") &&
                    (id == null || id == 0 || id < 0))
                {
                    cmd.Parameters.AddWithValue("@Option", "All");
                    cmd.Parameters.AddWithValue("@UserId", null);
                    cmd.Parameters.AddWithValue("@UserName", null);
                }
                else if (id == null || id == 0 || id < 0)
                {
                    cmd.Parameters.AddWithValue("@Option", "Other");
                    cmd.Parameters.AddWithValue("@UserId", null);
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
    }
}
