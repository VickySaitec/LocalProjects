using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SaitecSolutionLib
{
    public class Users : Wrapper
    {
        public Wrapper wrap;
        
        public Users()
            : base()
        {
            wrap = (Wrapper)Global.CreateInstance(typeof(Users));
        }
        public char CheckExistUserName(string p_username,string p_password,string p_option)
        {
            try
            {
                wrap.GetConnection();

                bool res = wrap.ExistUser(new string[] { p_username,p_password,p_option });
                return char.Parse(res == true ? "1" : "0");

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                wrap.CloseConnection();
            }
            return 'N';
        }
        public DataTable FetchCriteria(string p_criteria, out Error p_err)
        {
            DataSet _dsData = new DataSet();
            try
            {
                p_err = null;
                wrap.GetConnection();
                _dsData = wrap.ExecQueryReturnDataSetWithCommand("select UserId, UserName,Password, remark from shift_mas " + p_criteria + " order by shift_id ");
                return _dsData.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
            finally
            {
                wrap.CloseConnection();

            }
            return null;
        }
        private string GetValueOfObject(object p_obj)
        {
            if (p_obj == null)
                return "";
            else
                return p_obj.ToString();
        }

        public Hashtable SaveData(ref DataTable p_dtParameter)
        {
            int _intNumRecords = 0;
            string _strCriteria = "";
            Hashtable _htSave = new Hashtable();
            string _strTimeStampErrMsg = "Timestamp  Error : \n";
            string _strInsertErrMsg = "Problem In Inserting Record : \n";
            string _strUpdateErrMsg = "Problem In Updating Record : \n";
            string _strDeleteErrMsg = "Record can't deleted due to child record exist : \n";
            string _strErrMsg = "";
            _htSave.Add("TIMESTAMP", _strErrMsg);

            try
            {
                wrap.GetConnection();
                DataTable _dtTemp = p_dtParameter.GetChanges();
                DataRow[] _drRows;
                _strCriteria = "";
                foreach (DataRow _drRow in _dtTemp.Rows)
                {
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        bool _isCheckDuplicate = true;
                        if (_drRow.RowState == DataRowState.Modified)
                        {
                            if ((GetValueOfObject(_drRow["SHIFT_NAME", DataRowVersion.Current])) == (GetValueOfObject(_drRow["SHIFT_NAME", DataRowVersion.Original])))
                            {
                                _isCheckDuplicate = false;
                            }
                            if (_isCheckDuplicate)
                            {
                                if (CheckExistUserName(_drRow["UserName", DataRowVersion.Original].ToString(),_drRow["Password",DataRowVersion.Original].ToString(),"Other") == 'Y')
                                {

                                    _htSave.Add("RESULT", "true");

                                }
                            }
                            
                        }//if(modified)

                    }

                    switch (_drRow.RowState)
                    {
                        case DataRowState.Added:
                            _htSave = AddData(_drRow);

                            _strCriteria = FetchCriteria(_drRow, DataRowVersion.Current, out p_err);
                            _drRows = p_dtParameter.Select(_strCriteria);
                            if (_drRows.Length > 0)
                            {
                                if (_drRow.RowState == DataRowState.Added)
                                {
                                    p_dtParameter.Rows[p_dtParameter.Rows.IndexOf(_drRows[0])]["SHIFT_ID"] = _htSave["p_shift_id"].ToString();
                                }
                                p_dtParameter.Rows[p_dtParameter.Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["p_time_stamp"].ToString();
                            }

                            if (_htSave["p_flg"].ToString().ToUpper() == "N")
                                _strInsertErrMsg += "Shift Name = " + _drRow["SHIFT_NAME"] + "\n";
                            break;

                        case DataRowState.Modified:
                            _htSave = UpdateData(p_entTerm, p_entUser, _drRow, out p_err);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Shift Name = " + _drRow["SHIFT_NAME"] + "\n";

                                continue;
                            }
                            if (_htSave["p_flg"].ToString().ToUpper() == "N")
                                _strUpdateErrMsg += "Shift Name = " + _drRow["SHIFT_NAME"] + "\n";

                            break;

                        case DataRowState.Deleted:
                            _htSave = DeleteData(p_entUser, p_entTerm, _drRow, out p_err);

                            _strCriteria = FetchCriteria(_drRow, DataRowVersion.Original, out p_err);
                            _drRows = p_dtParameter.Select(_strCriteria);
                            if (_drRows.Length > 0)
                            {
                                if (_drRow.RowState == DataRowState.Deleted)
                                {
                                    p_dtParameter.Rows[p_dtParameter.Rows.IndexOf(_drRows[0])]["SHIFT_ID"] = _htSave["p_shift_id"].ToString();
                                }
                                p_dtParameter.Rows[p_dtParameter.Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["p_time_stamp"].ToString();
                            }
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Shift Name = " + _drRow["SHIFT_NAME", DataRowVersion.Original] + "\n";

                                continue;
                            }

                            if (_htSave["p_flg"].ToString().ToUpper() == "N")
                                _strDeleteErrMsg += "Shift = " + _drRow["SHIFT_NAME", DataRowVersion.Original] + "\n";


                            break;
                    }      //if(deleted)

                }


                if (_strTimeStampErrMsg != "Timestamp  Error : \n")
                    _strErrMsg = _strTimeStampErrMsg + "\n \n";

                if (_strInsertErrMsg != "Problem In Inserting Record : \n")
                    _strErrMsg = _strInsertErrMsg + "\n \n";

                if (_strUpdateErrMsg != "Problem In Updating Record : \n")
                    _strErrMsg = _strUpdateErrMsg + "\n \n";

                if (_strDeleteErrMsg != "Record can't deleted due to child record exist : \n")
                    _strErrMsg = _strDeleteErrMsg + "\n \n";


                _htSave.Add("RESULT", "true");
                _htSave["TIMESTAMP"] = _strErrMsg;


                return _htSave;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                wrap.CloseConnection();
            }
            return null;

        }
        public Hashtable AddData(DataRow _drRow)
        {
            try
            {
                Hashtable _htAdd = new Hashtable();
                wrap.GetConnection();
                


                
                _htAdd.Add("p_flg", _objData.GetParameterValue("p_flg"));
                _htAdd.Add("p_shift_id", _objData.GetParameterValue("p_shift_id"));
                _htAdd.Add("p_time_stamp", _objData.GetParameterValue("p_time_stamp"));
                _objData.Commit();
                return _htAdd;

            }

            catch (Exception ex)
            {
                Throws(ex, out p_err);
            }
            finally
            {
                _objData.Disconnect();
            }
            return null;
        }
    }
}
