using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AARAOFMD.Properties;
using SaitecSolutionLib;
using LTPLControl;
using System.Collections;
using FormCustomization_Sample;
using DAL;
using BAL;
using System.Drawing.Drawing2D;

namespace AARAOFMD
{
    public partial class frm_UserSetup : frmMaster
    {
        #region Declare Varible
        string _strActionType;
        #endregion


        #region Constructor

        public frm_UserSetup()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Events

        private void BtnPanel_btnAddClick(object sender, EventArgs e)
        {
            if (BtnPanel.ButtonAddText == "&Add")
            {
                BtnPanel.ButtonAddText = "&Save";
                BtnPanel.ButtonEditText = "&Cancel";
                BtnPanel.ButtonRefreshEnable = false;
                BtnPanel.ButtonSearchEnable = false;
                BtnPanel.ButtonEditEnable = true;
                BtnPanel.ButtonDeleteEnable = true;
                BtnPanel.ButtonCloseEnable = true;
                BtnPanel.ButtonAddEnable = true;
                _strActionType = "Add";
                ReadOnly_False();
            }
            else
            {
                SaveData();
                LoadData();
                Clear();
                ReadOnly_True();
                BtnPanel.ButtonAddText = "&Add";
                BtnPanel.ButtonEditText = "&Edit";
                BtnPanel.ButtonRefreshEnable = true;
                BtnPanel.ButtonSearchEnable = true;
            }
        }
        

        private void BtnPanel_btnCloseClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Global.Error(ex, Resources.DialogText);
            }
        }

        private void BtnPanel_btnDeleteClick(object sender, EventArgs e)
        {
            DeleteRecord(Convert.ToInt32(dgv_Users.SelectedRows[0].Cells[0].Value));
            LoadData();
            Clear();
        }

        private void BtnPanel_btnEditClick(object sender, EventArgs e)
        {
            if (BtnPanel.ButtonEditText == "&Edit")
            {
                BtnPanel.ButtonAddText = "&Save";
                BtnPanel.ButtonEditText = "&Cancel";
                _strActionType = "Edit";
                BtnPanel.ButtonAddEnable = true;
                BtnPanel.ButtonEditEnable = true;
                BtnPanel.ButtonRefreshEnable = false;
                BtnPanel.ButtonSearchEnable = false;
                ReadOnly_False();
                LoadRecord();
            }
            else
            {
                BtnPanel.ButtonAddText = "&Add";
                BtnPanel.ButtonEditText = "&Edit";
                BtnPanel.ButtonRefreshEnable = true;
                BtnPanel.ButtonSearchEnable = true;
                BtnPanel.ButtonAddEnable = true;
                Clear();
                ReadOnly_True();
                LoadData();
            }
        }

        private void BtnPanel_btnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                if (!_strActionType.Equals("Search"))
                    _strActionType = "Refresh";
                BtnPanel.ButtonSearchEnable = false;

                SearchData(txt_UserName.Text.Trim());
                BtnPanel.ButtonEditText = "&Edit";
                BtnPanel.ButtonEditEnable = true;
                BtnPanel.ButtonAddEnable = true;
                BtnPanel.ButtonDeleteEnable = true;
                BtnPanel.ButtonRefreshEnable = true;
                BtnPanel.ButtonSearchEnable = true;
                BtnPanel.SetFocus(LTPLControl.LTPLButtonControl.Action.Edit);
                txt_UserName.ReadOnly = true;
                Clear();

            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(" Error Generated From frm_UserSetup.CS : " + ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            
            
        }

        private void BtnPanel_btnSearchClick(object sender, EventArgs e)
        {
            try
            {
                txt_UserName.ReadOnly = false;
                _strActionType = "Search";
                BtnPanel.ButtonAddText = "&Add";
                BtnPanel.ButtonEditText = "&Cancel";
                BtnPanel.ButtonAddEnable = false;
            }
            catch (Exception ex)
            {
                FormCustomization_Sample.MessageBox.Show(" Error Generated From frm_UserSetup.CS : " + ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
            }
            
            
        }

        #endregion

        #region Methods

        public void LoadRecord()
        {
            txt_UserName.Text = dgv_Users.SelectedRows[0].Cells["UserName"].Value.ToString();
            txt_Password.Text = Global.DecryptedPassword(dgv_Users.SelectedRows[0].Cells["Password"].Value.ToString());
            cmb_EventId.Text = dgv_Users.SelectedRows[0].Cells["EventId"].Value.ToString();
            cmb_UserType.Text = dgv_Users.SelectedRows[0].Cells["UserType"].Value.ToString();
            lblUserId.Text = dgv_Users.SelectedRows[0].Cells["UserId"].Value.ToString();
        }

        private void ReadOnly_True()
        {
            txt_Password.ReadOnly = true;
            txt_UserName.ReadOnly = true;
            cmb_UserType.Enabled = false;
            cmb_EventId.Enabled = false ;
        }

        private void ReadOnly_False()
        {
            txt_Password.ReadOnly = false;
            txt_UserName.ReadOnly = false;
            cmb_UserType.Enabled = true;
            cmb_EventId.Enabled = true;
        }

        private void Clear()
        {
            txt_Password.Text = "";
            txt_UserName.Text = "";
            cmb_EventId.Text = "Select Any";
            cmb_UserType.Text = "Select Any";
            BtnPanel.ButtonAddText = "&Add";
        }

        private void LoadData()
        {
            DataTable Dt = new UsersBAL().LoadAll();
            BindData(Dt);
            
        }

        private void SearchData(string username)
        {
            DataTable dt = new UsersBAL().LoadAll(username);
            BindData(dt);
        }

        private void BindData(DataTable Dt)
        {
            dgv_Users.DataSource = Dt;
            dgv_Users.Columns["UserId"].Visible = false;
            dgv_Users.Columns["Password"].Visible = false;
        }

        private void SaveData()
        {
            Hashtable _ht = new Hashtable();
            try
            {
                if (CheckFormValidation())
                {
                    if (_strActionType == "Add")
                    {
                        _ht = new UsersBAL().Add(new string[]{txt_UserName.Text.Trim(),Global.EncryptedPassword(txt_Password.Text.Trim()),
                                                cmb_EventId.Text, cmb_UserType.Text,
                                            null, Global.UserId});
                        if (_ht["p_flg"].ToString() == "1")
                        {
                            FormCustomization_Sample.MessageBox.Show("Saved Successfully", Global.MsgInfo, MessageBoxStyle.Information);
                            return;
                        }
                    }
                    else if (_strActionType == "Edit")
                    {
                        _ht = new UsersBAL().Update(new string[]{txt_UserName.Text.Trim(),Global.EncryptedPassword(txt_Password.Text.Trim()),
                                                    cmb_EventId.Text, cmb_UserType.Text,
                                            null, Global.UserId,lblUserId.Text} );
                        if (_ht["p_flg"].ToString() == "1")
                        {
                            FormCustomization_Sample.MessageBox.Show("Updated Successfully", Global.MsgInfo, MessageBoxStyle.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool CheckFormValidation()
        {
            if ((cmb_EventId.Text != "" || cmb_EventId.Text != string.Empty || cmb_EventId.Text != null) &&
                (txt_Password.Text != "" || txt_Password.Text != string.Empty || txt_Password.Text != null) &&
                (txt_UserName.Text != "" || txt_UserName.Text != string.Empty || txt_UserName.Text != null) &&
                (cmb_UserType.Text != "" || cmb_UserType.Text != string.Empty || cmb_UserType.Text != null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteRecord(int? id = null)
        {
            Hashtable _ht = new Hashtable();
            _ht = new UsersBAL().Delete(id);
            if (_ht["p_flg"].ToString() == "1")
            {
                FormCustomization_Sample.MessageBox.Show("Record Deleted Successfully", Global.MsgInfo, MessageBoxStyle.Information);
                return;
            }
        }

        private void FillCombo()
        {
            DataTable dt = new UsersBAL().FillCombo();
            cmb_EventId.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cmb_EventId.Items.Add(dr["EventId"].ToString());
            }
            cmb_EventId.Items.Insert(0, "Select Any");
            cmb_EventId.SelectedIndex = 0;
            cmb_UserType.Items.Insert(0, "Select Any");
            cmb_UserType.SelectedIndex = 0;
        }
        ~frm_UserSetup()
        {
            this.Dispose();
        }

        #endregion

        #region Form Event

        private void frm_UserSetup_Load(object sender, EventArgs e)
        {
            ReadOnly_True();
            FillCombo();
        }


        #endregion

       

    }
}
