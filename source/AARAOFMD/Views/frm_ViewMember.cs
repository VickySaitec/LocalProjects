using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaitecSolutionLib;
using System.Text.RegularExpressions;
using FormCustomization_Sample;
using System.IO;

namespace AARAOFMD.Views
{
    public partial class frm_ViewMember : Form
    {
        #region Declared Variable
        Wrapper wrap;
        string bphone;
        string cphone;
        int sid, bid, cid;
        int btid, stid, cntrid, cntyid;
        QRCodeGenerater qrcode;
        byte[] imageBytes;
        static string registrationid = frm_Search.registrationid;
        #endregion

        #region Constructor
        public frm_ViewMember()
        {
            InitializeComponent();
        }

        public frm_ViewMember(string id)
        {
            registrationid = id;
        }

        #endregion

        #region FormEvents
        public void frm_ViewMember_Load(object sender, EventArgs e)
        {
            wrap = new Wrapper();
            frm_Registration.setImage(picb_Logo, 193, 117);
            if (registrationid == null || registrationid == string.Empty || registrationid == "")
            { }
            else
            {
                ReadOnlyAllControl();
                //cphone = frm_Search.cphone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
                //bphone = frm_Search.bphone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
                //bphone = (bphone == string.Empty ? null : bphone);
                //cphone = (cphone == string.Empty ? null : cphone);
                bphone =  Global.BusinessPhone;
                cphone = Global.CellPhone;
                SqlDataReader dr = wrap.GetFilteredData("[PROC_GETDATA_MEMBER_REGISTRATION]",bphone,cphone,registrationid);

                if (dr.Read())
                {
                    lblRegistrationID.Text = dr["registration_id"].ToString();

                    lblReg_id.Text = dr["reg_id"].ToString();
                    lblReg_id.Visible = false;
                    txt_FristName.Text = dr["first_name"].ToString();


                    txt_LastName.Text = dr["last_name"].ToString();

                    txt_BusiName.Text = dr["business_name"].ToString();


                    cmb_BusiType.Text = dr["business_typename"].ToString();
                    txt_Address.Text = dr["business_address"].ToString();
                    txt_Address.Text = txt_Address.Text.ToUpper();
                    txt_City.Text = dr["city"].ToString();
                    txt_City.Text = txt_City.Text.ToUpper();
                    cmb_Country.Text = dr["country_name"].ToString();
                    cmb_County.Text = dr["county_name"].ToString();
                    cmb_State.Text = dr["state_name"].ToString();
                    txt_Zip.Text = dr["zip"].ToString();
                    txt_BusiPhone.Text = dr["business_phone"].ToString();
                    txt_CellPhone.Text = dr["cell_phone"].ToString();
                    txt_Email.Text = dr["email"].ToString();
                    txt_Website.Text = dr["website"].ToString();
                }
            }
        }
        #endregion

        #region ButtonEvents
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                txt_FristName.ReadOnly = false;
                txt_Email.ReadOnly = false;
                txt_CellPhone.ReadOnly = false;
                txt_LastName.ReadOnly = false;
                txt_BusiName.ReadOnly = false;
                txt_Address.ReadOnly = false;
                txt_BusiPhone.ReadOnly = false;
                txt_City.ReadOnly = false;
                txt_Website.ReadOnly = false;
                txt_Zip.ReadOnly = false;
                cmb_BusiType.Enabled = true;
                cmb_County.Enabled = true;
                cmb_State.Enabled = true;
                btnEdit.Text = "Update";
            }
            else
            {
                if (txt_State.Text != "")
                {
                    sid = wrap.InsertData(new string[] { txt_State.Text, cmb_Country.SelectedValue.ToString() }, "PROC_INSERT_STATE", "State");
                }
                if (txt_BusiType.Text != "" || txt_BusiType.Text != string.Empty)
                {
                    bid = wrap.InsertData(new string[] { txt_BusiType.Text }, "PROC_INSERT_BUSINESSTYPE", "BusinessType");
                }
                if (txt_County.Text != "" || txt_County.Text != string.Empty)
                {
                    cid = wrap.InsertData(new string[] { cmb_State.SelectedValue.ToString(), txt_County.Text }, "PROC_INSERT_COUNTY", "County");
                }

                btid = wrap.GetScalarValue(cmb_BusiType.Text, "business_type");
                stid = wrap.GetScalarValue(cmb_State.Text, "state");
                cntrid = wrap.GetScalarValue(cmb_Country.Text, "country");
                cntyid = wrap.GetScalarValue(cmb_County.Text, "county");

                cphone = txt_CellPhone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                bphone = txt_CellPhone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                bool res = wrap.UpdateMemberReg(new string[] {lblReg_id.Text,txt_FristName.Text.ToString(), txt_LastName.Text.ToString(), txt_BusiName.Text.ToString(), cmb_BusiType.Text == "Others" ? bid.ToString(): btid.ToString() ,
                                txt_Address.Text,cntrid.ToString(),txt_City.Text,cmb_County.Text == "Others" ? cid.ToString(): cntyid.ToString(),cmb_State.Text == "Others" ? sid.ToString() : stid.ToString(),txt_Zip.Text,txt_BusiPhone.Text,
                                txt_CellPhone.Text,txt_Email.Text,txt_Website.Text});
                if (res == true)
                {
                    string FINAL = "BEGIN:VCARD" + "\n"
                + "VERSION:4.0" + "\n"
                + "N:" + txt_LastName.Text.ToUpper() + "; AARA-" + txt_FristName.Text.ToUpper() + ";;;" + "\n"
                + "FN: AARA-" + txt_FristName.Text.ToUpper() + " " + txt_LastName.Text.ToUpper() + "\n"
                + "ORG:" + txt_BusiName.Text + "\n"
                + "TEL;TYPE=work,voice;VALUE=uri:" + bphone + "\n"
                + "TEL;TYPE=cell,voice;VALUE=uri:" + cphone + "\n"
                + "ADR;TYPE=work:;;" + txt_Address.Text.ToUpper() + ";" + txt_City.Text.ToUpper() + ";" + cmb_State.Text.ToUpper() + ";" + txt_Zip.Text + ";" + cmb_Country.Text + "\n"
                + "EMAIL:" + txt_Email.Text + "\n"
                + "END:VCARD";


                    qrcode = new QRCodeGenerater(FINAL);
                    imageBytes = qrcode.CodeGenerator();

                    bool result = wrap.InsertQrTable(new string[] {"PROC_INSERT_DATA_IN_QRTABLE",lblRegistrationID.Text},imageBytes);
                    if (result == true)
                    {
                        DataTable dt = wrap.GetDataForQr(lblRegistrationID.Text);
                        Pic_QRCode.Image = Image.FromStream(new MemoryStream(imageBytes));
                        frm_Registration.setImage(Pic_QRCode, 155, 150);
                        pnl_Qrcode.Visible = true;
                        Pic_QRCode.Visible = true;
                        btnGenerateCode.Visible = true;
                    }
                }
                Clear();
                ReadOnlyAllControl();
                btnEdit.Text = "Edit";
            }
        }
        #endregion

        #region CommonFunction

        public void ReadOnlyAllControl()
        {
            txt_FristName.ReadOnly = true;
            txt_Email.ReadOnly = true;
            txt_CellPhone.ReadOnly = true;
            txt_LastName.ReadOnly = true;

            //business control

            txt_BusiName.ReadOnly = true;
            txt_Address.ReadOnly = true;
            txt_BusiPhone.ReadOnly = true;
            txt_City.ReadOnly = true;
            txt_Website.ReadOnly = true;
            txt_Zip.ReadOnly = true;
            cmb_BusiType.Enabled = false;
            cmb_County.Enabled = false;
            cmb_State.Enabled = false;
        }

        public void FillBusinessType()
        {
            wrap = new Wrapper();
            //Fill the Business Type data:
            DataTable dt_businesstype = wrap.GetComboData("GETDATA_FOR_BUSINESSTYPE");

            cmb_BusiType.DataSource = dt_businesstype;
            cmb_BusiType.DisplayMember = "business_typename";
            cmb_BusiType.ValueMember = "business_id";

            wrap.CloseConnection();
            wrap = null;
        }

        public void FillCounty()
        {
            wrap = new Wrapper();
            DataTable dt_county = wrap.GetComboData("GETDATA_FOR_COUNTY");

            cmb_County.DataSource = dt_county;
            cmb_County.DisplayMember = "county_name";
            cmb_County.ValueMember = "c_id";

            wrap.CloseConnection();
            wrap = null;
        }

        private void FillState()
        {
            wrap = new Wrapper();
            //DataTable dt_country = wrap.GetComboData("GETDATA_FOR_COUNTRY");
            DataTable dt_State = wrap.GetComboData("GETDATA_FOR_STATE");

            cmb_State.DataSource = dt_State;
            cmb_State.DisplayMember = "state_name";
            cmb_State.ValueMember = "state_id";

            wrap.CloseConnection();
            wrap = null;
        }

        private void FillCountry()
        {
            wrap = new Wrapper();
            DataTable dt_Country = wrap.GetComboData("GETDATA_FOR_COUNTRY");
            //DataTable dt_State = wrap.GetComboData("GETDATA_FOR_STATE");

            cmb_Country.DataSource = dt_Country;
            cmb_Country.DisplayMember = "country_name";
            cmb_Country.ValueMember = "country_id";
        }

        private void Clear()
        {
            txt_FristName.Text = "";
            txt_Email.Text = "";
            txt_CellPhone.Text = "";
            txt_LastName.Text = "";
            txt_BusiName.Text = "";
            txt_Address.Text = "";
            txt_BusiPhone.Text = "";
            txt_City.Text = "";
            txt_Website.Text = "";
            txt_Zip.Text = "";
            FillBusinessType();
            FillCountry();
            FillCounty();
            FillState();
        }

        public string FormattedCellNumber
        {
            get
            {
                if (txt_CellPhone.Text == null)
                    return string.Empty;

                switch (txt_CellPhone.Text.Length)
                {
                    case 7:
                        return Regex.Replace(txt_CellPhone.Text, @"(\d{3})(\d{4})", "$1-$2");
                    case 10:
                        return Regex.Replace(txt_CellPhone.Text, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
                    case 11:
                        return Regex.Replace(txt_CellPhone.Text, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                    case 13:
                        return Regex.Replace(txt_CellPhone.Text, @"(\d{2})(\d{3})(\d{3})(\d{4})", "($1)-($2) $3-$4");
                    default:
                        return txt_CellPhone.Text;
                }
            }
        }

        public string FormattedBusinessNumber
        {
            get
            {
                if (txt_BusiPhone.Text == null)
                    return string.Empty;

                switch (txt_CellPhone.Text.Length)
                {
                    case 7:
                        return Regex.Replace(txt_BusiPhone.Text, @"(\d{3})(\d{4})", "$1-$2");
                    case 10:
                        return Regex.Replace(txt_BusiPhone.Text, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
                    case 11:
                        return Regex.Replace(txt_BusiPhone.Text, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                    case 13:
                        return Regex.Replace(txt_BusiPhone.Text, @"(\d{2})(\d{3})(\d{3})(\d{4})", "($1)-($2) $3-$4");
                    default:
                        return txt_CellPhone.Text;
                }
            }
        }

        #endregion

        #region ControlEvents

        private void cmb_BusiType_MouseDown(object sender, MouseEventArgs e)
        {
            FillBusinessType();
        }

        private void cmb_State_MouseDown(object sender, MouseEventArgs e)
        {
            FillState();
        }

        private void cmb_County_MouseDown(object sender, MouseEventArgs e)
        {
            FillCounty();
        }

        private void txt_CellPhone_Leave(object sender, EventArgs e)
        {
            txt_CellPhone.Text = FormattedCellNumber;
        }

        private void cmb_BusiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_BusiType.Text == "Others")
            {
                txt_BusiType.Visible = true;
            }
            else if (cmb_BusiType.Text != "Select Any")
            {
                cmb_BusiType.Enabled = true;
                txt_BusiType.Visible = false;
            }
            else
            {
                txt_BusiType.Visible = false;
                //MessageBox.Show("Please First Select Proper Business Type ! ");
                return;
            }
        }

        private void cmb_County_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_County.Text == "Others")
            {
                txt_County.Visible = true;
            }
            else if (cmb_County.Text != "Select Any")
            {
                cmb_County.Enabled = true;
                txt_County.Visible = false;
            }
            else
            {
                txt_County.Visible = false;
                //MessageBox.Show("Please First Select Proper County ! ");
                return;
            }
        }

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_State.Text == "Others")
            {
                txt_State.Visible = true;
            }
            else if (cmb_State.Text != "Select Any")
            {
                cmb_County.Enabled = true;
                txt_State.Visible = false;
            }
            else
            {
                txt_State.Visible = false;
                //MessageBox.Show("Please First Select Proper State ! ");
                return;
            }
        }

        private void txt_CellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '+') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txt_LastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txt_FristName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txt_Email.Text.Trim() != string.Empty)
            {

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txt_Email.Text.Trim()))
                {

                    FormCustomization_Sample.MessageBox.Show("E-mail address format is not correct.",Global.MsgInfo, MessageBoxStyle.Errorr);

                    txt_Email.Focus();

                }

            }
        }

        private void txt_BusiName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txt_Zip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txt_BusiPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '+') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txt_BusiPhone_Leave(object sender, EventArgs e)
        {
            txt_BusiPhone.Text = FormattedBusinessNumber;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            this.Close();
            frm_Search search = new frm_Search();
            search.Show();
        }
    }
}
