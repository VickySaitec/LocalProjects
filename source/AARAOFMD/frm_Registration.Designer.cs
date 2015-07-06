namespace AARAOFMD
{
    partial class frm_Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Registration));
            this.tb_Registration = new System.Windows.Forms.TabControl();
            this.tab_Member = new System.Windows.Forms.TabPage();
            this.rdbExibitor = new System.Windows.Forms.RadioButton();
            this.rdb_NonMem = new System.Windows.Forms.RadioButton();
            this.rdb_ActiveMem = new System.Windows.Forms.RadioButton();
            this.lbl_Question = new System.Windows.Forms.Label();
            this.tab_PersonalInfomation = new System.Windows.Forms.TabPage();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_lastnm = new System.Windows.Forms.Label();
            this.lbl_firstnm = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_CellPhone = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.txt_FristName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tab_BusinessInformation = new System.Windows.Forms.TabPage();
            this.txt_County = new System.Windows.Forms.TextBox();
            this.txt_State = new System.Windows.Forms.TextBox();
            this.txt_BusiType = new System.Windows.Forms.TextBox();
            this.cmb_Country = new System.Windows.Forms.ComboBox();
            this.lbl_zip = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.lbl_cnty = new System.Windows.Forms.Label();
            this.lbl_stat = new System.Windows.Forms.Label();
            this.lbl_cntry = new System.Windows.Forms.Label();
            this.lbl_add = new System.Windows.Forms.Label();
            this.lbl_businm = new System.Windows.Forms.Label();
            this.lbl_busstype = new System.Windows.Forms.Label();
            this.lbl_Country = new System.Windows.Forms.Label();
            this.cmb_County = new System.Windows.Forms.ComboBox();
            this.txt_Website = new System.Windows.Forms.TextBox();
            this.txt_BusiPhone = new System.Windows.Forms.TextBox();
            this.txt_Zip = new System.Windows.Forms.TextBox();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_BusiName = new System.Windows.Forms.TextBox();
            this.cmb_State = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.cmb_BusiType = new System.Windows.Forms.ComboBox();
            this.lbl_County = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_BusiName = new System.Windows.Forms.Label();
            this.lbl_BusiType = new System.Windows.Forms.Label();
            this.iml_Header = new System.Windows.Forms.ImageList(this.components);
            this.lbl_Operation = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picb_Logo = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.tb_Registration.SuspendLayout();
            this.tab_Member.SuspendLayout();
            this.tab_PersonalInfomation.SuspendLayout();
            this.tab_BusinessInformation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Registration
            // 
            this.tb_Registration.Controls.Add(this.tab_Member);
            this.tb_Registration.Controls.Add(this.tab_PersonalInfomation);
            this.tb_Registration.Controls.Add(this.tab_BusinessInformation);
            this.tb_Registration.ImageList = this.iml_Header;
            this.tb_Registration.ItemSize = new System.Drawing.Size(160, 80);
            this.tb_Registration.Location = new System.Drawing.Point(-1, 154);
            this.tb_Registration.Multiline = true;
            this.tb_Registration.Name = "tb_Registration";
            this.tb_Registration.Padding = new System.Drawing.Point(0, 0);
            this.tb_Registration.SelectedIndex = 0;
            this.tb_Registration.Size = new System.Drawing.Size(964, 458);
            this.tb_Registration.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tb_Registration.TabIndex = 0;
            this.tb_Registration.Tag = "Member";
            this.tb_Registration.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tb_Registration_DrawItem);
            // 
            // tab_Member
            // 
            this.tab_Member.BackColor = System.Drawing.Color.Transparent;
            this.tab_Member.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tab_Member.Controls.Add(this.rdbExibitor);
            this.tab_Member.Controls.Add(this.rdb_NonMem);
            this.tab_Member.Controls.Add(this.rdb_ActiveMem);
            this.tab_Member.Controls.Add(this.lbl_Question);
            this.tab_Member.ImageIndex = 0;
            this.tab_Member.Location = new System.Drawing.Point(4, 84);
            this.tab_Member.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tab_Member.Name = "tab_Member";
            this.tab_Member.Padding = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tab_Member.Size = new System.Drawing.Size(956, 370);
            this.tab_Member.TabIndex = 0;
            this.tab_Member.Tag = "Member";
            this.tab_Member.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_Member_Paint);
            // 
            // rdbExibitor
            // 
            this.rdbExibitor.AutoSize = true;
            this.rdbExibitor.Location = new System.Drawing.Point(256, 178);
            this.rdbExibitor.Name = "rdbExibitor";
            this.rdbExibitor.Size = new System.Drawing.Size(137, 20);
            this.rdbExibitor.TabIndex = 3;
            this.rdbExibitor.Text = "Exihibitor/Vendor";
            this.rdbExibitor.UseVisualStyleBackColor = true;
            // 
            // rdb_NonMem
            // 
            this.rdb_NonMem.AutoSize = true;
            this.rdb_NonMem.Location = new System.Drawing.Point(256, 141);
            this.rdb_NonMem.Name = "rdb_NonMem";
            this.rdb_NonMem.Size = new System.Drawing.Size(205, 20);
            this.rdb_NonMem.TabIndex = 2;
            this.rdb_NonMem.Text = "Non-Member/Visiting Guest";
            this.rdb_NonMem.UseVisualStyleBackColor = true;
            // 
            // rdb_ActiveMem
            // 
            this.rdb_ActiveMem.AutoSize = true;
            this.rdb_ActiveMem.Checked = true;
            this.rdb_ActiveMem.Location = new System.Drawing.Point(256, 105);
            this.rdb_ActiveMem.Name = "rdb_ActiveMem";
            this.rdb_ActiveMem.Size = new System.Drawing.Size(124, 20);
            this.rdb_ActiveMem.TabIndex = 1;
            this.rdb_ActiveMem.TabStop = true;
            this.rdb_ActiveMem.Text = "Active Member";
            this.rdb_ActiveMem.UseVisualStyleBackColor = true;
            // 
            // lbl_Question
            // 
            this.lbl_Question.AutoSize = true;
            this.lbl_Question.Location = new System.Drawing.Point(59, 58);
            this.lbl_Question.Name = "lbl_Question";
            this.lbl_Question.Size = new System.Drawing.Size(120, 16);
            this.lbl_Question.TabIndex = 0;
            this.lbl_Question.Text = "Select Any one :";
            // 
            // tab_PersonalInfomation
            // 
            this.tab_PersonalInfomation.BackColor = System.Drawing.Color.White;
            this.tab_PersonalInfomation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_PersonalInfomation.Controls.Add(this.lbl_email);
            this.tab_PersonalInfomation.Controls.Add(this.lbl_lastnm);
            this.tab_PersonalInfomation.Controls.Add(this.lbl_firstnm);
            this.tab_PersonalInfomation.Controls.Add(this.txt_Email);
            this.tab_PersonalInfomation.Controls.Add(this.txt_CellPhone);
            this.tab_PersonalInfomation.Controls.Add(this.txt_LastName);
            this.tab_PersonalInfomation.Controls.Add(this.txt_FristName);
            this.tab_PersonalInfomation.Controls.Add(this.label5);
            this.tab_PersonalInfomation.Controls.Add(this.label6);
            this.tab_PersonalInfomation.Controls.Add(this.label7);
            this.tab_PersonalInfomation.Controls.Add(this.label8);
            this.tab_PersonalInfomation.ImageIndex = 1;
            this.tab_PersonalInfomation.Location = new System.Drawing.Point(4, 84);
            this.tab_PersonalInfomation.Margin = new System.Windows.Forms.Padding(0);
            this.tab_PersonalInfomation.Name = "tab_PersonalInfomation";
            this.tab_PersonalInfomation.Size = new System.Drawing.Size(956, 370);
            this.tab_PersonalInfomation.TabIndex = 1;
            this.tab_PersonalInfomation.Tag = "Personal Information";
            this.tab_PersonalInfomation.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_PersonalInfomation_Paint);
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.ForeColor = System.Drawing.Color.Red;
            this.lbl_email.Location = new System.Drawing.Point(393, 170);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(17, 16);
            this.lbl_email.TabIndex = 30;
            this.lbl_email.Text = "*";
            // 
            // lbl_lastnm
            // 
            this.lbl_lastnm.AutoSize = true;
            this.lbl_lastnm.ForeColor = System.Drawing.Color.Red;
            this.lbl_lastnm.Location = new System.Drawing.Point(394, 107);
            this.lbl_lastnm.Name = "lbl_lastnm";
            this.lbl_lastnm.Size = new System.Drawing.Size(17, 16);
            this.lbl_lastnm.TabIndex = 28;
            this.lbl_lastnm.Text = "*";
            // 
            // lbl_firstnm
            // 
            this.lbl_firstnm.AutoSize = true;
            this.lbl_firstnm.ForeColor = System.Drawing.Color.Red;
            this.lbl_firstnm.Location = new System.Drawing.Point(394, 69);
            this.lbl_firstnm.Name = "lbl_firstnm";
            this.lbl_firstnm.Size = new System.Drawing.Size(17, 16);
            this.lbl_firstnm.TabIndex = 27;
            this.lbl_firstnm.Text = "*";
            // 
            // txt_Email
            // 
            this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Email.Location = new System.Drawing.Point(185, 171);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(205, 23);
            this.txt_Email.TabIndex = 26;
            this.txt_Email.Leave += new System.EventHandler(this.txt_Email_Leave);
            // 
            // txt_CellPhone
            // 
            this.txt_CellPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CellPhone.Location = new System.Drawing.Point(185, 137);
            this.txt_CellPhone.MaxLength = 13;
            this.txt_CellPhone.Name = "txt_CellPhone";
            this.txt_CellPhone.Size = new System.Drawing.Size(205, 23);
            this.txt_CellPhone.TabIndex = 25;
            this.txt_CellPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CellPhone_KeyPress);
            this.txt_CellPhone.Leave += new System.EventHandler(this.txt_CellPhone_Leave);
            // 
            // txt_LastName
            // 
            this.txt_LastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LastName.Location = new System.Drawing.Point(185, 103);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(205, 23);
            this.txt_LastName.TabIndex = 24;
            this.txt_LastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_LastName_KeyPress);
            // 
            // txt_FristName
            // 
            this.txt_FristName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FristName.Location = new System.Drawing.Point(185, 69);
            this.txt_FristName.Name = "txt_FristName";
            this.txt_FristName.Size = new System.Drawing.Size(205, 23);
            this.txt_FristName.TabIndex = 23;
            this.txt_FristName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FristName_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Email :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Cell Phone :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Last Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "First Name :";
            // 
            // tab_BusinessInformation
            // 
            this.tab_BusinessInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_BusinessInformation.Controls.Add(this.txt_County);
            this.tab_BusinessInformation.Controls.Add(this.txt_State);
            this.tab_BusinessInformation.Controls.Add(this.txt_BusiType);
            this.tab_BusinessInformation.Controls.Add(this.cmb_Country);
            this.tab_BusinessInformation.Controls.Add(this.lbl_zip);
            this.tab_BusinessInformation.Controls.Add(this.lbl_city);
            this.tab_BusinessInformation.Controls.Add(this.lbl_cnty);
            this.tab_BusinessInformation.Controls.Add(this.lbl_stat);
            this.tab_BusinessInformation.Controls.Add(this.lbl_cntry);
            this.tab_BusinessInformation.Controls.Add(this.lbl_add);
            this.tab_BusinessInformation.Controls.Add(this.lbl_businm);
            this.tab_BusinessInformation.Controls.Add(this.lbl_busstype);
            this.tab_BusinessInformation.Controls.Add(this.lbl_Country);
            this.tab_BusinessInformation.Controls.Add(this.cmb_County);
            this.tab_BusinessInformation.Controls.Add(this.txt_Website);
            this.tab_BusinessInformation.Controls.Add(this.txt_BusiPhone);
            this.tab_BusinessInformation.Controls.Add(this.txt_Zip);
            this.tab_BusinessInformation.Controls.Add(this.txt_City);
            this.tab_BusinessInformation.Controls.Add(this.txt_Address);
            this.tab_BusinessInformation.Controls.Add(this.txt_BusiName);
            this.tab_BusinessInformation.Controls.Add(this.cmb_State);
            this.tab_BusinessInformation.Controls.Add(this.label1);
            this.tab_BusinessInformation.Controls.Add(this.label4);
            this.tab_BusinessInformation.Controls.Add(this.label3);
            this.tab_BusinessInformation.Controls.Add(this.label2);
            this.tab_BusinessInformation.Controls.Add(this.lbl_State);
            this.tab_BusinessInformation.Controls.Add(this.cmb_BusiType);
            this.tab_BusinessInformation.Controls.Add(this.lbl_County);
            this.tab_BusinessInformation.Controls.Add(this.lbl_Address);
            this.tab_BusinessInformation.Controls.Add(this.lbl_BusiName);
            this.tab_BusinessInformation.Controls.Add(this.lbl_BusiType);
            this.tab_BusinessInformation.ImageIndex = 2;
            this.tab_BusinessInformation.Location = new System.Drawing.Point(4, 84);
            this.tab_BusinessInformation.Name = "tab_BusinessInformation";
            this.tab_BusinessInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tab_BusinessInformation.Size = new System.Drawing.Size(956, 370);
            this.tab_BusinessInformation.TabIndex = 2;
            this.tab_BusinessInformation.Tag = "Business Information";
            this.tab_BusinessInformation.UseVisualStyleBackColor = true;
            this.tab_BusinessInformation.Paint += new System.Windows.Forms.PaintEventHandler(this.tab_BusinessInformation_Paint);
            // 
            // txt_County
            // 
            this.txt_County.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_County.Location = new System.Drawing.Point(561, 36);
            this.txt_County.Name = "txt_County";
            this.txt_County.Size = new System.Drawing.Size(205, 23);
            this.txt_County.TabIndex = 33;
            this.txt_County.Visible = false;
            // 
            // txt_State
            // 
            this.txt_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_State.Location = new System.Drawing.Point(179, 273);
            this.txt_State.Name = "txt_State";
            this.txt_State.Size = new System.Drawing.Size(205, 23);
            this.txt_State.TabIndex = 32;
            this.txt_State.Visible = false;
            // 
            // txt_BusiType
            // 
            this.txt_BusiType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BusiType.Location = new System.Drawing.Point(179, 36);
            this.txt_BusiType.Name = "txt_BusiType";
            this.txt_BusiType.Size = new System.Drawing.Size(205, 23);
            this.txt_BusiType.TabIndex = 31;
            this.txt_BusiType.Visible = false;
            // 
            // cmb_Country
            // 
            this.cmb_Country.Enabled = false;
            this.cmb_Country.FormattingEnabled = true;
            this.cmb_Country.Items.AddRange(new object[] {
            "USA"});
            this.cmb_Country.Location = new System.Drawing.Point(179, 208);
            this.cmb_Country.Name = "cmb_Country";
            this.cmb_Country.Size = new System.Drawing.Size(205, 24);
            this.cmb_Country.TabIndex = 30;
            // 
            // lbl_zip
            // 
            this.lbl_zip.AutoSize = true;
            this.lbl_zip.ForeColor = System.Drawing.Color.Red;
            this.lbl_zip.Location = new System.Drawing.Point(772, 170);
            this.lbl_zip.Name = "lbl_zip";
            this.lbl_zip.Size = new System.Drawing.Size(17, 16);
            this.lbl_zip.TabIndex = 29;
            this.lbl_zip.Text = "*";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.ForeColor = System.Drawing.Color.Red;
            this.lbl_city.Location = new System.Drawing.Point(772, 103);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(17, 16);
            this.lbl_city.TabIndex = 28;
            this.lbl_city.Text = "*";
            // 
            // lbl_cnty
            // 
            this.lbl_cnty.AutoSize = true;
            this.lbl_cnty.ForeColor = System.Drawing.Color.Red;
            this.lbl_cnty.Location = new System.Drawing.Point(772, 68);
            this.lbl_cnty.Name = "lbl_cnty";
            this.lbl_cnty.Size = new System.Drawing.Size(17, 16);
            this.lbl_cnty.TabIndex = 27;
            this.lbl_cnty.Text = "*";
            // 
            // lbl_stat
            // 
            this.lbl_stat.AutoSize = true;
            this.lbl_stat.ForeColor = System.Drawing.Color.Red;
            this.lbl_stat.Location = new System.Drawing.Point(390, 246);
            this.lbl_stat.Name = "lbl_stat";
            this.lbl_stat.Size = new System.Drawing.Size(17, 16);
            this.lbl_stat.TabIndex = 26;
            this.lbl_stat.Text = "*";
            // 
            // lbl_cntry
            // 
            this.lbl_cntry.AutoSize = true;
            this.lbl_cntry.ForeColor = System.Drawing.Color.Red;
            this.lbl_cntry.Location = new System.Drawing.Point(390, 211);
            this.lbl_cntry.Name = "lbl_cntry";
            this.lbl_cntry.Size = new System.Drawing.Size(17, 16);
            this.lbl_cntry.TabIndex = 25;
            this.lbl_cntry.Text = "*";
            // 
            // lbl_add
            // 
            this.lbl_add.AutoSize = true;
            this.lbl_add.ForeColor = System.Drawing.Color.Red;
            this.lbl_add.Location = new System.Drawing.Point(390, 141);
            this.lbl_add.Name = "lbl_add";
            this.lbl_add.Size = new System.Drawing.Size(17, 16);
            this.lbl_add.TabIndex = 24;
            this.lbl_add.Text = "*";
            // 
            // lbl_businm
            // 
            this.lbl_businm.AutoSize = true;
            this.lbl_businm.ForeColor = System.Drawing.Color.Red;
            this.lbl_businm.Location = new System.Drawing.Point(390, 107);
            this.lbl_businm.Name = "lbl_businm";
            this.lbl_businm.Size = new System.Drawing.Size(17, 16);
            this.lbl_businm.TabIndex = 23;
            this.lbl_businm.Text = "*";
            // 
            // lbl_busstype
            // 
            this.lbl_busstype.AutoSize = true;
            this.lbl_busstype.ForeColor = System.Drawing.Color.Red;
            this.lbl_busstype.Location = new System.Drawing.Point(390, 68);
            this.lbl_busstype.Name = "lbl_busstype";
            this.lbl_busstype.Size = new System.Drawing.Size(17, 16);
            this.lbl_busstype.TabIndex = 22;
            this.lbl_busstype.Text = "*";
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Location = new System.Drawing.Point(37, 211);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(71, 16);
            this.lbl_Country.TabIndex = 21;
            this.lbl_Country.Text = "Country :";
            // 
            // cmb_County
            // 
            this.cmb_County.Enabled = false;
            this.cmb_County.FormattingEnabled = true;
            this.cmb_County.Items.AddRange(new object[] {
            "Select Any"});
            this.cmb_County.Location = new System.Drawing.Point(561, 65);
            this.cmb_County.Name = "cmb_County";
            this.cmb_County.Size = new System.Drawing.Size(205, 24);
            this.cmb_County.TabIndex = 19;
            this.cmb_County.SelectedIndexChanged += new System.EventHandler(this.cmb_County_SelectedIndexChanged);
            // 
            // txt_Website
            // 
            this.txt_Website.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Website.Location = new System.Drawing.Point(561, 202);
            this.txt_Website.Name = "txt_Website";
            this.txt_Website.Size = new System.Drawing.Size(205, 23);
            this.txt_Website.TabIndex = 18;
            // 
            // txt_BusiPhone
            // 
            this.txt_BusiPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BusiPhone.Location = new System.Drawing.Point(561, 168);
            this.txt_BusiPhone.MaxLength = 13;
            this.txt_BusiPhone.Name = "txt_BusiPhone";
            this.txt_BusiPhone.Size = new System.Drawing.Size(205, 23);
            this.txt_BusiPhone.TabIndex = 17;
            this.txt_BusiPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_BusiPhone_KeyPress);
            this.txt_BusiPhone.Leave += new System.EventHandler(this.txt_BusiPhone_Leave);
            // 
            // txt_Zip
            // 
            this.txt_Zip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Zip.Location = new System.Drawing.Point(561, 134);
            this.txt_Zip.MaxLength = 5;
            this.txt_Zip.Name = "txt_Zip";
            this.txt_Zip.Size = new System.Drawing.Size(205, 23);
            this.txt_Zip.TabIndex = 16;
            this.txt_Zip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Zip_KeyPress);
            // 
            // txt_City
            // 
            this.txt_City.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_City.Location = new System.Drawing.Point(561, 100);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(205, 23);
            this.txt_City.TabIndex = 15;
            // 
            // txt_Address
            // 
            this.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address.Location = new System.Drawing.Point(179, 134);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(205, 64);
            this.txt_Address.TabIndex = 7;
            // 
            // txt_BusiName
            // 
            this.txt_BusiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BusiName.Location = new System.Drawing.Point(179, 100);
            this.txt_BusiName.Name = "txt_BusiName";
            this.txt_BusiName.Size = new System.Drawing.Size(205, 23);
            this.txt_BusiName.TabIndex = 6;
            this.txt_BusiName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_BusiName_KeyPress);
            // 
            // cmb_State
            // 
            this.cmb_State.FormattingEnabled = true;
            this.cmb_State.Location = new System.Drawing.Point(179, 243);
            this.cmb_State.Name = "cmb_State";
            this.cmb_State.Size = new System.Drawing.Size(205, 24);
            this.cmb_State.TabIndex = 14;
            this.cmb_State.SelectedIndexChanged += new System.EventHandler(this.cmb_State_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Website :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Business Phone :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Zip :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "City :";
            // 
            // lbl_State
            // 
            this.lbl_State.AutoSize = true;
            this.lbl_State.Location = new System.Drawing.Point(37, 246);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(56, 16);
            this.lbl_State.TabIndex = 9;
            this.lbl_State.Text = "State :";
            // 
            // cmb_BusiType
            // 
            this.cmb_BusiType.FormattingEnabled = true;
            this.cmb_BusiType.Location = new System.Drawing.Point(179, 65);
            this.cmb_BusiType.Name = "cmb_BusiType";
            this.cmb_BusiType.Size = new System.Drawing.Size(205, 24);
            this.cmb_BusiType.TabIndex = 1;
            this.cmb_BusiType.SelectedIndexChanged += new System.EventHandler(this.cmb_BusiType_SelectedIndexChanged);
            // 
            // lbl_County
            // 
            this.lbl_County.AutoSize = true;
            this.lbl_County.Location = new System.Drawing.Point(429, 68);
            this.lbl_County.Name = "lbl_County";
            this.lbl_County.Size = new System.Drawing.Size(66, 16);
            this.lbl_County.TabIndex = 5;
            this.lbl_County.Text = "County :";
            // 
            // lbl_Address
            // 
            this.lbl_Address.AutoSize = true;
            this.lbl_Address.Location = new System.Drawing.Point(37, 136);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(71, 16);
            this.lbl_Address.TabIndex = 4;
            this.lbl_Address.Text = "Address :";
            // 
            // lbl_BusiName
            // 
            this.lbl_BusiName.AutoSize = true;
            this.lbl_BusiName.Location = new System.Drawing.Point(37, 103);
            this.lbl_BusiName.Name = "lbl_BusiName";
            this.lbl_BusiName.Size = new System.Drawing.Size(116, 16);
            this.lbl_BusiName.TabIndex = 3;
            this.lbl_BusiName.Text = "Business Name :";
            // 
            // lbl_BusiType
            // 
            this.lbl_BusiType.AutoSize = true;
            this.lbl_BusiType.Location = new System.Drawing.Point(37, 68);
            this.lbl_BusiType.Name = "lbl_BusiType";
            this.lbl_BusiType.Size = new System.Drawing.Size(113, 16);
            this.lbl_BusiType.TabIndex = 0;
            this.lbl_BusiType.Text = "Business Type :";
            // 
            // iml_Header
            // 
            this.iml_Header.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml_Header.ImageStream")));
            this.iml_Header.TransparentColor = System.Drawing.Color.Transparent;
            this.iml_Header.Images.SetKeyName(0, "Arraow_member.jpg");
            this.iml_Header.Images.SetKeyName(1, "Arraow_PersonalInfo.jpg");
            this.iml_Header.Images.SetKeyName(2, "Arraow_BusinessInfo.jpg");
            // 
            // lbl_Operation
            // 
            this.lbl_Operation.AutoSize = true;
            this.lbl_Operation.BackColor = System.Drawing.Color.White;
            this.lbl_Operation.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Operation.ForeColor = System.Drawing.Color.Black;
            this.lbl_Operation.Location = new System.Drawing.Point(342, 65);
            this.lbl_Operation.Name = "lbl_Operation";
            this.lbl_Operation.Size = new System.Drawing.Size(243, 45);
            this.lbl_Operation.TabIndex = 1;
            this.lbl_Operation.Text = "Registration";
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Back.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.ForeColor = System.Drawing.Color.White;
            this.btn_Back.Location = new System.Drawing.Point(659, 5);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(134, 57);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "<< Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.Black;
            this.btn_Clear.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(30, 3);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(127, 59);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Next.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.ForeColor = System.Drawing.Color.White;
            this.btn_Next.Location = new System.Drawing.Point(815, 5);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(127, 57);
            this.btn_Next.TabIndex = 4;
            this.btn_Next.Text = "Next >>";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Next);
            this.panel1.Controls.Add(this.btn_Clear);
            this.panel1.Controls.Add(this.btn_Back);
            this.panel1.Location = new System.Drawing.Point(3, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 65);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picb_Logo);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 123);
            this.panel2.TabIndex = 3;
            // 
            // picb_Logo
            // 
            this.picb_Logo.Image = ((System.Drawing.Image)(resources.GetObject("picb_Logo.Image")));
            this.picb_Logo.Location = new System.Drawing.Point(4, 3);
            this.picb_Logo.Name = "picb_Logo";
            this.picb_Logo.Size = new System.Drawing.Size(193, 117);
            this.picb_Logo.TabIndex = 0;
            this.picb_Logo.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(286, 23);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(379, 45);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "AARA TRADESHOW";
            // 
            // frm_Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 683);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Operation);
            this.Controls.Add(this.tb_Registration);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Registration_FormClosed);
            this.Load += new System.EventHandler(this.frm_Registration_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frm_Registration_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Registration_KeyDown);
            this.tb_Registration.ResumeLayout(false);
            this.tab_Member.ResumeLayout(false);
            this.tab_Member.PerformLayout();
            this.tab_PersonalInfomation.ResumeLayout(false);
            this.tab_PersonalInfomation.PerformLayout();
            this.tab_BusinessInformation.ResumeLayout(false);
            this.tab_BusinessInformation.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tb_Registration;
        private System.Windows.Forms.TabPage tab_Member;
        private System.Windows.Forms.TabPage tab_PersonalInfomation;
        private System.Windows.Forms.TabPage tab_BusinessInformation;
        private System.Windows.Forms.Label lbl_Operation;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbExibitor;
        private System.Windows.Forms.RadioButton rdb_NonMem;
        private System.Windows.Forms.RadioButton rdb_ActiveMem;
        private System.Windows.Forms.Label lbl_Question;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox picb_Logo;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_lastnm;
        private System.Windows.Forms.Label lbl_firstnm;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_CellPhone;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.TextBox txt_FristName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_Country;
        private System.Windows.Forms.Label lbl_zip;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label lbl_cnty;
        private System.Windows.Forms.Label lbl_stat;
        private System.Windows.Forms.Label lbl_cntry;
        private System.Windows.Forms.Label lbl_add;
        private System.Windows.Forms.Label lbl_businm;
        private System.Windows.Forms.Label lbl_busstype;
        private System.Windows.Forms.Label lbl_Country;
        private System.Windows.Forms.ComboBox cmb_County;
        private System.Windows.Forms.TextBox txt_Website;
        private System.Windows.Forms.TextBox txt_BusiPhone;
        private System.Windows.Forms.TextBox txt_Zip;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_BusiName;
        private System.Windows.Forms.ComboBox cmb_State;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.ComboBox cmb_BusiType;
        private System.Windows.Forms.Label lbl_County;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_BusiName;
        private System.Windows.Forms.Label lbl_BusiType;
        private System.Windows.Forms.ImageList iml_Header;
        private System.Windows.Forms.TextBox txt_BusiType;
        private System.Windows.Forms.TextBox txt_State;
        private System.Windows.Forms.TextBox txt_County;
    }
}

