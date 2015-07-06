using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using SaitecSolutionLib;
using FormCustomization_Sample;



namespace AARAOFMD
{
    public partial class frm_Registration : Form
    {
        #region Declared Variable
            Wrapper wrap;
            Mail mail;
            string search_regid, cphone, bphone;
            int sid, bid, cid;
            static string msginfo = "AARA TradeShow 2015";
        
        #endregion

        #region Constructor

        //Normal Constructor
                public frm_Registration()
                {
                    InitializeComponent();
                    wrap = new Wrapper();
                }
        // Parameterized Constructor
                public frm_Registration(string id)
                {
                    search_regid = id;
                }

        #endregion

        #region Button Events

                private void btn_Next_Click(object sender, EventArgs e)
                {
                    if (btn_Next.Text == "Next >>")
                    {
                        if (tb_Registration.SelectedTab.Tag == "Member")
                        {
                            if (CheckValidate_Member())
                            {
                                tb_Registration.SelectedTab = tab_PersonalInfomation;
                                ((Control)this.tab_PersonalInfomation).Enabled = true;
                            }
                            else
                            {
                                FormCustomization_Sample.MessageBox.Show("Please Fill Required Field In the Form !", Global.MsgInfo,MessageBoxStyle.Errorr);
                                tb_Registration.SelectedIndex = 0;
                                //rdb_ActiveMem.Focus();
                            }
                        }
                        else if (tb_Registration.SelectedTab.Tag == "Personal Information")
                        {
                            if (CheckValdiate_Personal())
                            {
                                tb_Registration.SelectedTab = tab_BusinessInformation;
                                ((Control)this.tab_BusinessInformation).Enabled = true;
                                btn_Next.Text = "Submit";
                            }
                            else
                            {
                                FormCustomization_Sample.MessageBox.Show("Please Fill Required Field In the Form !", "AARA TradeShow 2015 : Error", MessageBoxStyle.Errorr);
                                tb_Registration.SelectedIndex = 0;
                                tb_Registration.SelectedIndex = 1;
                                txt_FristName.Focus();
                            }
                        }
                    }
                    else
                    {
                        if (CheckValidate_Business())
                        {
                            string mem = CheckMember();
                            GenerateRandomAlphaNumericCode();

                            if (txt_State.Text != "")
                            {
                                sid = wrap.InsertData(new string[] {txt_State.Text,cmb_Country.SelectedValue.ToString()},"PROC_INSERT_STATE","State");
                            }
                            if (txt_BusiType.Text != "" || txt_BusiType.Text != string.Empty)
                            {
                                bid = wrap.InsertData(new string[] { txt_BusiType.Text }, "PROC_INSERT_BUSINESSTYPE", "BusinessType");
                            }
                            if (txt_County.Text != "" || txt_County.Text != string.Empty)
                            {
                                cid = wrap.InsertData(new string[] { cmb_State.SelectedValue.ToString(), txt_County.Text }, "PROC_INSERT_COUNTY", "County");
                            }

                            cphone = txt_CellPhone.Text.Replace("(","").Replace(")","").Replace("-","");
                            bphone = txt_CellPhone.Text.Replace("(","").Replace(")","").Replace("-","");

                            bool res = wrap.InsertData(new string[] {Global.AlphaNumericCode, txt_FristName.Text.ToString(), txt_LastName.Text.ToString(), txt_BusiName.Text.ToString(), cmb_BusiType.Text == "Others" ? bid.ToString():cmb_BusiType.SelectedValue.ToString() ,
                                txt_Address.Text,cmb_Country.SelectedValue.ToString(),txt_City.Text,cmb_County.Text == "Others" ? cid.ToString(): cmb_County.SelectedValue.ToString(),cmb_State.Text == "Others" ? sid.ToString() : cmb_State.SelectedValue.ToString(),txt_Zip.Text,txt_BusiPhone.Text,
                                txt_CellPhone.Text,txt_Email.Text,txt_Website.Text,mem.ToString()});
                            if (res == true)
                            {
                                bool result = wrap.InsertRegistrationLog(new string[] { Global.AlphaNumericCode });
                                if (result)
                                {
                                    Mail.SendMailVal(new string[] { txt_FristName.Text + " " + txt_LastName.Text, bphone, txt_Email.Text });
                                    Mail.SendMailVal_xHibitor(new string[] { txt_FristName.Text + " " + txt_LastName.Text, bphone, txt_Email.Text });
                                    FormCustomization_Sample.MessageBox.Show("Saved Data Successfully", Global.MsgInfo, MessageBoxStyle.Information);
                                    Clear_Member();
                                    Clear_PersonalInformation();
                                    Clear_BusinessInformation();
                                }
                                else
                                {
                                    FormCustomization_Sample.MessageBox.Show("Data Error in RegistrationLog Table", Global.MsgInfo, MessageBoxStyle.Information);
                                }
                            }
                            else
                            {
                                FormCustomization_Sample.MessageBox.Show("Data Error in MemberRegistration Table", Global.MsgInfo, MessageBoxStyle.Information);
                            }
                        }

                    }
                }

                private void btn_Clear_Click(object sender, EventArgs e)
                {
                    int index = tb_Registration.SelectedIndex;
                    if (tb_Registration.SelectedIndex == 1)
                    {
                        Clear_PersonalInformation();
                    }
                    else
                    {
                        Clear_BusinessInformation();
                    }
                }

                private void btn_Back_Click(object sender, EventArgs e)
                {
                    if (tb_Registration.SelectedTab.Tag == "Business Information")
                    {
                        tb_Registration.SelectedTab = tab_PersonalInfomation;
                        btn_Next.Text = "Next >>";
                        //((Control)this.tab_PersonalInfomation).Enabled = true;
                    }
                    else if (tb_Registration.SelectedTab.Tag == "Personal Information")
                    {
                        tb_Registration.SelectedTab = tab_Member;
                        //((Control)this.tab_PersonalInfomation).Enabled = true;
                    }
                }


        #endregion

        #region Contro Events

        private void tb_Registration_Selecting(object sender, TabControlCancelEventArgs e)
                {
                    if (e.TabPage != tb_Registration.SelectedTab) e.Cancel = true;
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

                    FormCustomization_Sample.MessageBox.Show("E-mail address format is not correct.", Global.MsgInfo,MessageBoxStyle.Errorr);

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

         private void tab_Member_Paint(object sender, PaintEventArgs e)
        {
            if (tb_Registration.SelectedTab.Tag.ToString() == "Member")
            {
                tb_Registration.TabPages[1].Hide();
                tb_Registration.TabPages[2].Hide();
                btn_Back.Visible = false;
                btn_Next.Text = "Next >>";
            }
            
        }

        private void tab_PersonalInfomation_Paint(object sender, PaintEventArgs e)
        {
            if (tb_Registration.SelectedTab.Tag.ToString() == "Personal Information")
            {
                btn_Back.Visible = true;
                btn_Next.Text = "Next >>";
                tb_Registration.TabPages[2].Hide();
            }
        }

        private void tab_BusinessInformation_Paint(object sender, PaintEventArgs e)
        {
                btn_Next.Text = "Submit";
                btn_Back.Visible = true;
        }

        private void tb_Registration_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush bg_backcolor = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(bg_backcolor,e.Bounds);
            tb_Registration.TabPages[0].BorderStyle = BorderStyle.None;
            tb_Registration.TabPages[1].BorderStyle = BorderStyle.None;
            tb_Registration.TabPages[2].BorderStyle = BorderStyle.None;
            
        }

       

        private void txt_CellPhone_Leave(object sender, EventArgs e)
        {
            txt_CellPhone.Text = FormattedCellNumber;
        }

        #endregion

        #region Form Events
        
                private void frm_Registration_Load(object sender, EventArgs e)
                {

                    try
                    {
                        if (tb_Registration.TabIndex == 0)
                        {
                            tb_Registration.TabStop = true;
                        }
                        ((Control)this.tab_PersonalInfomation).Enabled = false;
                        ((Control)this.tab_BusinessInformation).Enabled = false;

                        setImage(picb_Logo, 193, 117);

                                           
                        FillCombobox();

                        cmb_Country.SelectedIndex = 1;
                        cmb_Country.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                
                        throw new Exception(ex.Message);
                    }
           

                }

                    private void frm_Registration_FormClosed(object sender, FormClosedEventArgs e)
                {
                    ((Form)this.MdiParent).Controls["btn_Registration"].Visible = true;
                }

        
                private void frm_Registration_Paint(object sender, PaintEventArgs e)
                {
                    if (tb_Registration.SelectedTab.Tag.ToString() == "Member")
                    {
                        tb_Registration.TabPages[1].Hide();
                        tb_Registration.TabPages[2].Hide();
                        btn_Back.Visible = false;
                        btn_Next.Text = "Next >>";
                    }
                    if (tb_Registration.SelectedTab.Tag.ToString() == "Personal Information")
                    {
                        btn_Back.Visible = true;
                        btn_Next.Text = "Next >>";
                        tb_Registration.TabPages[2].Hide();
                    }
                    if (tb_Registration.SelectedTab.Tag.ToString() == "Business Information")
                    {
                        btn_Next.Text = "Submit";
                    }
                }

                    private void frm_Registration_KeyDown(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
 
                    }
                }

        #endregion
        
        #region MemberFunctions 
        
                private void Clear_Member()
                {
                    rdb_ActiveMem.Checked = false;
                    rdb_NonMem.Checked = false;
                    rdbExibitor.Checked = false;
                }
                private void Clear_PersonalInformation()
                {
                    txt_FristName.Text = "";
                    txt_Email.Text = "";
                    txt_CellPhone.Text = "";
                    txt_LastName.Text = "";
                }
                private void Clear_BusinessInformation()
                {
                    txt_BusiName.Text = "";
                    txt_Address.Text = "";
                    txt_BusiPhone.Text = "";
                    txt_City.Text = "";
                    txt_Website.Text = "";
                    txt_Zip.Text = "";
                    FillCombobox();

                    tb_Registration.SelectedTab = tab_Member;
                    if (tb_Registration.TabIndex == 0)
                    {
                        tb_Registration.TabStop = true;
                    }
                    ((Control)this.tab_PersonalInfomation).Enabled = false;
                    ((Control)this.tab_BusinessInformation).Enabled = false;

                    //cmb_BusiType.Items.Insert(0, "Select Any");
                    //cmb_BusiType.Items.Add("Other");
                    //cmb_BusiType.SelectedIndex = 0;

                    ////cmb_County.Items.Clear();
                    //cmb_County.Items.Insert(0, "Select Any");
                    //cmb_County.Items.Add("Other");
                    //cmb_County.SelectedIndex = 0;

                    ////cmb_State.Items.Clear();
                    //cmb_State.Items.Insert(0, "Select Any");
                    //cmb_State.Items.Add("Other");
                    //cmb_State.SelectedIndex = 0;
                }
                public void FillCombobox()
                {
                    //Fill the Business Type data:
                    DataTable dt_businesstype = wrap.GetComboData("GETDATA_FOR_BUSINESSTYPE");
                    DataTable dt_county = wrap.GetComboData("GETDATA_FOR_COUNTY");
                    //DataTable dt_country = wrap.GetComboData("GETDATA_FOR_COUNTRY");
                    DataTable dt_State = wrap.GetComboData("GETDATA_FOR_STATE");
                    DataTable dt_Country = wrap.GetComboData("GETDATA_FOR_COUNTRY");

                    cmb_BusiType.DataSource = dt_businesstype;
                    cmb_BusiType.DisplayMember = "business_typename";
                    cmb_BusiType.ValueMember = "business_id";

                    cmb_County.DataSource = dt_county;
                    cmb_County.DisplayMember = "county_name";
                    cmb_County.ValueMember = "c_id";

                    cmb_State.DataSource = dt_State;
                    cmb_State.DisplayMember = "state_name";
                    cmb_State.ValueMember = "state_id";

                    cmb_Country.DataSource = dt_Country;
                    cmb_Country.DisplayMember = "country_name";
                    cmb_Country.ValueMember = "country_id";

                }

                private bool CheckValidate_Member()
                {
                    if (rdb_ActiveMem.Checked == true || rdb_NonMem.Checked == true || rdbExibitor.Checked == true)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                private bool CheckValdiate_Personal()
                {
                    if (txt_FristName.Text != "" && txt_LastName.Text != "" && txt_CellPhone.Text != "" && txt_Email.Text != "")
                    {
                        return true;
                    }
                    else
                        return false;
                }
                private bool CheckValidate_Business()
                {
                    if (txt_BusiName.Text != "" && txt_Address.Text != "" && txt_BusiPhone.Text != "" && txt_City.Text != ""
                        && txt_Website.Text != "" && txt_Zip.Text != "")
                        return true;
                    return false;
                }
                private string CheckMember()
                {
                    if (rdb_ActiveMem.Checked == true)
                        return "Member";
                    else if (rdb_NonMem.Checked == true)
                        return "Guest";
                    else
                        return "Exibitor";
                }
                public static string GenerateRandomAlphaNumericCode()
                {
                    return GenerateRandomAlphaNumericCode(4);
                }
                public static string GenerateRandomAlphaNumericCode(int length)
                {
                    string characterSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    Random random = new Random();

                    //The below code will select the random characters from the set
                    //and then the array of these characters are passed to string 
                    //constructor to make an alphanumeric string
                    string randomCode = new string(
                        Enumerable.Repeat(characterSet, length)
                            .Select(set => set[random.Next(set.Length)])
                            .ToArray());
                    //alphanumericid = randomCode;
                    Global.AlphaNumericCode = randomCode;
                    return randomCode;
                }
       

                public static void setImage(PictureBox Pic,int sizex,int sizey)
                {
                    Bitmap bt = new Bitmap(sizex,sizey);
                    Bitmap bitmap = new Bitmap(Pic.Image);
                    System.Drawing.Graphics graphic;
                    graphic = Graphics.FromImage(bt);
                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                    graphic.DrawImage(bitmap, new Rectangle(0, 0, sizex, sizey), new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);

                    Pic.Image = null;
                    Pic.Image = (System.Drawing.Image)bt;
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

        
    }
}
