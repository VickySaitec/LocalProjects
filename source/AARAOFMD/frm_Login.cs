using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaitecSolutionLib;
using FormCustomization_Sample;
using DAL;
using BAL;

namespace AARAOFMD
{
    public partial class frm_Login : Form
    {
        Wrapper wrap;
        bool res;

        #region Constructor
        public frm_Login()
        {
            InitializeComponent();
        }
        #endregion


        #region FormEvent
        private void frm_Login_Load(object sender, EventArgs e)
        {
            cmb_EventId.Focus();
            FillCombo();
            frm_Registration.setImage(picb_Logo, 90, 90);
        }

        #endregion

        #region ControlEvents

        
        #endregion



        #region ButtonEvents
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
            this.Close();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                try
                {
                    wrap = new Wrapper();


                    if (cmb_EventId.Text != "Select Any" && cmb_EventId.Text != string.Empty && cmb_EventId.Text != null)
                    {
                        res = new UsersBAL().ExistUser(new string[] { txt_UserName.Text.Trim(), Global.EncryptedPassword(txt_Password.Text.Trim()), "Xhibitor", cmb_EventId.Text });
                        if (res)
                        {
                            int id = GetUserId(txt_UserName.Text.Trim());
                            Global.UserId = id.ToString();
                            Global.UserName = txt_UserName.Text.Trim();
                            this.Close();
                            frm_Search frm = new frm_Search();
                            frm.MdiParent = this.MdiParent;
                            frm.Show();
                        }
                        else
                        {
                            FormCustomization_Sample.MessageBox.Show("Please Check UserName and Password !!!", Global.MsgInfo, MessageBoxStyle.Errorr);
                            txt_UserName.Focus();
                            Clear();
                        }
                    }
                    else
                    {
                        res = new UsersBAL().ExistUser(new string[] { txt_UserName.Text.Trim(), Global.EncryptedPassword(txt_Password.Text.Trim()), "Authorised", null });
                        if (res)
                        {
                            int id = GetUserId(txt_UserName.Text.Trim());
                            Global.UserId = id.ToString();
                            Global.UserName = txt_UserName.Text.Trim();
                            this.Close();
                            frm_UserSetup frm = new frm_UserSetup();
                            frm.MdiParent = this.MdiParent;
                            frm.Show();
                        }
                        else
                        {
                            FormCustomization_Sample.MessageBox.Show("Please Check UserName and Password !!!", Global.MsgInfo, MessageBoxStyle.Errorr);
                            txt_UserName.Focus();
                            Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    FormCustomization_Sample.MessageBox.Show(ex.Message, Global.MsgInfo, MessageBoxStyle.Errorr);
                }
            }
        }

        #endregion

        #region CommonFunction
        private void Clear()
        {
            cmb_EventId.Items.Insert(0, "Select Any");
            cmb_EventId.SelectedIndex = 0;
            txt_Password.Text = "";
            txt_UserName.Text = "";
            cmb_EventId.Focus();
        }
        protected bool CheckValidation()
        {
            if ((txt_UserName.Text != null || txt_UserName.Text != string.Empty || txt_UserName.Text != "") &&
                (txt_Password.Text != null || txt_Password.Text != string.Empty || txt_Password.Text != "") &&
                (cmb_EventId.Text != null || cmb_EventId.Text != string.Empty || cmb_EventId.Text != "Select Any"))
            {
                return true;
            }
            else
                return false;
        }
        protected int GetUserId(string username)
        {
            return new UsersBAL().GetUserId(username);
        }
        protected void FillCombo()
        {
            DataTable dt = new UsersBAL().FillCombo();
            cmb_EventId.Items.Insert(0, "Select Any");
            cmb_EventId.SelectedIndex = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cmb_EventId.Items.Add(dr["EventId"].ToString());
            }
        }
        #endregion

        private void pic_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
