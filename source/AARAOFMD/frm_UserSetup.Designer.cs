namespace AARAOFMD
{
    partial class frm_UserSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserSetup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ltplGroupBox1 = new LTPLControl.LTPLGroupBox(this.components);
            this.lblUserId = new System.Windows.Forms.Label();
            this.cmb_UserType = new LTPLControl.LTPLComboBox(this.components);
            this.cmb_EventId = new LTPLControl.LTPLComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Password = new LTPLControl.LTPLTextBox(this.components);
            this.txt_UserName = new LTPLControl.LTPLTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPanel = new LTPLControl.LTPLButtonControl();
            this.dgv_Users = new LTPLControl.LTPLGridView(this.components);
            this.ltplGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // ltplGroupBox1
            // 
            this.ltplGroupBox1.BackgroundColor = System.Drawing.Color.Transparent;
            this.ltplGroupBox1.BackgroundGradientColor = System.Drawing.Color.Transparent;
            this.ltplGroupBox1.BackgroundGradientMode = LTPLControl.LTPLGroupBox.GroupBoxGradientMode.None;
            this.ltplGroupBox1.BorderColor = System.Drawing.Color.Transparent;
            this.ltplGroupBox1.BorderThickness = 1F;
            this.ltplGroupBox1.Controls.Add(this.lblUserId);
            this.ltplGroupBox1.Controls.Add(this.cmb_UserType);
            this.ltplGroupBox1.Controls.Add(this.cmb_EventId);
            this.ltplGroupBox1.Controls.Add(this.label6);
            this.ltplGroupBox1.Controls.Add(this.label5);
            this.ltplGroupBox1.Controls.Add(this.txt_Password);
            this.ltplGroupBox1.Controls.Add(this.txt_UserName);
            this.ltplGroupBox1.Controls.Add(this.label4);
            this.ltplGroupBox1.Controls.Add(this.label3);
            this.ltplGroupBox1.Controls.Add(this.label2);
            this.ltplGroupBox1.Controls.Add(this.label1);
            this.ltplGroupBox1.FillGroupTitle = false;
            this.ltplGroupBox1.GroupTilteBackColor = System.Drawing.Color.Transparent;
            this.ltplGroupBox1.GroupTitle = "";
            this.ltplGroupBox1.GroupTitleImage = null;
            this.ltplGroupBox1.Location = new System.Drawing.Point(33, 32);
            this.ltplGroupBox1.Name = "ltplGroupBox1";
            this.ltplGroupBox1.RoundCorners = 1;
            this.ltplGroupBox1.Shadow = false;
            this.ltplGroupBox1.ShadowColor = System.Drawing.Color.DarkGray;
            this.ltplGroupBox1.ShadowThickness = 3;
            this.ltplGroupBox1.Size = new System.Drawing.Size(637, 103);
            this.ltplGroupBox1.TabIndex = 1;
            this.ltplGroupBox1.TabStop = false;
            this.ltplGroupBox1.Text = "User Details";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(103, 17);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(0, 13);
            this.lblUserId.TabIndex = 10;
            this.lblUserId.Visible = false;
            // 
            // cmb_UserType
            // 
            this.cmb_UserType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_UserType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_UserType.ChangeCase = LTPLControl.LTPLComboBox.CaseFormat.Normal;
            this.cmb_UserType.FormattingEnabled = true;
            this.cmb_UserType.Items.AddRange(new object[] {
            "Administrator",
            "Xhibitor"});
            this.cmb_UserType.Location = new System.Drawing.Point(424, 67);
            this.cmb_UserType.Name = "cmb_UserType";
            this.cmb_UserType.OpenOnComboEnter = false;
            this.cmb_UserType.Required = true;
            this.cmb_UserType.Size = new System.Drawing.Size(184, 21);
            this.cmb_UserType.TabIndex = 3;
            // 
            // cmb_EventId
            // 
            this.cmb_EventId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_EventId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_EventId.ChangeCase = LTPLControl.LTPLComboBox.CaseFormat.Normal;
            this.cmb_EventId.FormattingEnabled = true;
            this.cmb_EventId.Location = new System.Drawing.Point(424, 35);
            this.cmb_EventId.Name = "cmb_EventId";
            this.cmb_EventId.OpenOnComboEnter = false;
            this.cmb_EventId.Required = true;
            this.cmb_EventId.Size = new System.Drawing.Size(184, 21);
            this.cmb_EventId.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(614, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(312, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "*";
            // 
            // txt_Password
            // 
            this.txt_Password.BindDataColumn = null;
            this.txt_Password.BindDataSource = null;
            this.txt_Password.BindListControl = null;
            this.txt_Password.ChangeCase = LTPLControl.LTPLTextBox.CaseFormat.Normal;
            this.txt_Password.FixedLength = false;
            this.txt_Password.Format = LTPLControl.LTPLTextBox.DataFormat.Normal;
            this.txt_Password.Location = new System.Drawing.Point(122, 67);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.RegularExpression = ".*";
            this.txt_Password.Required = true;
            this.txt_Password.Size = new System.Drawing.Size(184, 21);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.ValidInputString = "Any Character";
            // 
            // txt_UserName
            // 
            this.txt_UserName.BindDataColumn = null;
            this.txt_UserName.BindDataSource = null;
            this.txt_UserName.BindListControl = null;
            this.txt_UserName.ChangeCase = LTPLControl.LTPLTextBox.CaseFormat.Normal;
            this.txt_UserName.FixedLength = false;
            this.txt_UserName.Format = LTPLControl.LTPLTextBox.DataFormat.Normal;
            this.txt_UserName.Location = new System.Drawing.Point(122, 35);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.RegularExpression = ".*";
            this.txt_UserName.Required = true;
            this.txt_UserName.Size = new System.Drawing.Size(184, 21);
            this.txt_UserName.TabIndex = 0;
            this.txt_UserName.ValidInputString = "Any Character";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "User Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Event Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // BtnPanel
            // 
            this.BtnPanel.BackColor = System.Drawing.Color.Transparent;
            this.BtnPanel.ButtonAddEnable = true;
            this.BtnPanel.ButtonAddImage = ((System.Drawing.Image)(resources.GetObject("BtnPanel.ButtonAddImage")));
            this.BtnPanel.ButtonAddText = "&Add";
            this.BtnPanel.ButtonAddVisible = true;
            this.BtnPanel.ButtonCloseEnable = true;
            this.BtnPanel.ButtonCloseImage = ((System.Drawing.Image)(resources.GetObject("BtnPanel.ButtonCloseImage")));
            this.BtnPanel.ButtonCloseVisible = true;
            this.BtnPanel.ButtonDeleteEnable = true;
            this.BtnPanel.ButtonDeleteImage = ((System.Drawing.Image)(resources.GetObject("BtnPanel.ButtonDeleteImage")));
            this.BtnPanel.ButtonDeleteVisible = true;
            this.BtnPanel.ButtonEditEnable = true;
            this.BtnPanel.ButtonEditImage = ((System.Drawing.Image)(resources.GetObject("BtnPanel.ButtonEditImage")));
            this.BtnPanel.ButtonEditText = "&Edit";
            this.BtnPanel.ButtonEditVisible = true;
            this.BtnPanel.ButtonRefreshEnable = true;
            this.BtnPanel.ButtonRefreshImage = ((System.Drawing.Image)(resources.GetObject("BtnPanel.ButtonRefreshImage")));
            this.BtnPanel.ButtonRefreshVisible = true;
            this.BtnPanel.ButtonSearchEnable = true;
            this.BtnPanel.ButtonSearchImage = ((System.Drawing.Image)(resources.GetObject("BtnPanel.ButtonSearchImage")));
            this.BtnPanel.ButtonSearchText = "Sea&rch";
            this.BtnPanel.ButtonSearchVisible = true;
            this.BtnPanel.Location = new System.Drawing.Point(33, 372);
            this.BtnPanel.MessageText = "";
            this.BtnPanel.Name = "BtnPanel";
            this.BtnPanel.SetColor = System.Drawing.Color.Empty;
            this.BtnPanel.SetDuration = 0;
            this.BtnPanel.SetLightColor = System.Drawing.Color.Empty;
            this.BtnPanel.Size = new System.Drawing.Size(637, 56);
            this.BtnPanel.StartTime = new System.DateTime(((long)(0)));
            this.BtnPanel.TabIndex = 2;
            this.BtnPanel.btnAddClick += new LTPLControl.LTPLButtonControl.Button_Click(this.BtnPanel_btnAddClick);
            this.BtnPanel.btnEditClick += new LTPLControl.LTPLButtonControl.Button_Click(this.BtnPanel_btnEditClick);
            this.BtnPanel.btnDeleteClick += new LTPLControl.LTPLButtonControl.Button_Click(this.BtnPanel_btnDeleteClick);
            this.BtnPanel.btnSearchClick += new LTPLControl.LTPLButtonControl.Button_Click(this.BtnPanel_btnSearchClick);
            this.BtnPanel.btnRefreshClick += new LTPLControl.LTPLButtonControl.Button_Click(this.BtnPanel_btnRefreshClick);
            this.BtnPanel.btnCloseClick += new LTPLControl.LTPLButtonControl.Button_Click(this.BtnPanel_btnCloseClick);
            // 
            // dgv_Users
            // 
            this.dgv_Users.AlphabaticCol = null;
            this.dgv_Users.AutoSkipReadonlyCell = false;
            this.dgv_Users.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Users.ButtonColumn = null;
            this.dgv_Users.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgv_Users.ChangeCase = LTPLControl.LTPLGridView.CaseFormat.Normal;
            this.dgv_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Users.ColumnSize = null;
            this.dgv_Users.ColumnWidth = null;
            this.dgv_Users.CopyCellOnNewRow = true;
            this.dgv_Users.DateFormat = "dd/MM/yyyy";
            this.dgv_Users.DateTimeCol = null;
            this.dgv_Users.DateTimeColumnStyle = LTPLControl.LTPLGridView.DateColumnStyle.Mask;
            this.dgv_Users.DecimalCol = null;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Users.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Users.DisplayMasterHeaderForMerge = null;
            this.dgv_Users.DisplayOrderRequiredCol = null;
            this.dgv_Users.DisplayRows = 0;
            this.dgv_Users.DropDownListComboBox = null;
            this.dgv_Users.EnableHeadersVisualStyles = false;
            this.dgv_Users.ExcelExportRowFilter = null;
            this.dgv_Users.ExcludeColsCopyValue = null;
            this.dgv_Users.HideCol = null;
            this.dgv_Users.KeyActionTab = false;
            this.dgv_Users.LinkButtonColumn = null;
            this.dgv_Users.Location = new System.Drawing.Point(33, 141);
            this.dgv_Users.LOV = false;
            this.dgv_Users.Name = "dgv_Users";
            this.dgv_Users.NegativeCol = null;
            this.dgv_Users.NumericCol = null;
            this.dgv_Users.PageFilter = null;
            this.dgv_Users.ProcessMessageText = " Data Loading... Please Wait ";
            this.dgv_Users.ProcessMessageVisible = false;
            this.dgv_Users.ReadOnlyCol = null;
            this.dgv_Users.RequiredCol = null;
            this.dgv_Users.RowHeadersVisible = false;
            this.dgv_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Users.SetBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(202)))), ((int)(((byte)(196)))));
            this.dgv_Users.SetCurrCellColor = System.Drawing.Color.DarkKhaki;
            this.dgv_Users.SetReadOnlyColBgColor = System.Drawing.SystemColors.Info;
            this.dgv_Users.ShowRowNumber = false;
            this.dgv_Users.Size = new System.Drawing.Size(637, 232);
            this.dgv_Users.SkipReadOnlyOnArrowKey = true;
            this.dgv_Users.SummaryCol = null;
            this.dgv_Users.TabIndex = 4;
            this.dgv_Users.TimeCol = null;
            this.dgv_Users.TimeFormat = "HH:mm:ss";
            this.dgv_Users.TotalCol = null;
            this.dgv_Users.VisibleCol = null;
            this.dgv_Users.VisibleDisplayColumnOrder = true;
            this.dgv_Users.VisibleReadExcelFile = false;
            // 
            // frm_UserSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(673, 428);
            this.Controls.Add(this.dgv_Users);
            this.Controls.Add(this.BtnPanel);
            this.Controls.Add(this.ltplGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frm_UserSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "User Setup";
            this.Text = "User Setup";
            this.Load += new System.EventHandler(this.frm_UserSetup_Load);
            this.Controls.SetChildIndex(this.ltplGroupBox1, 0);
            this.Controls.SetChildIndex(this.BtnPanel, 0);
            this.Controls.SetChildIndex(this.dgv_Users, 0);
            this.ltplGroupBox1.ResumeLayout(false);
            this.ltplGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LTPLControl.LTPLGroupBox ltplGroupBox1;
        private LTPLControl.LTPLTextBox txt_Password;
        private LTPLControl.LTPLTextBox txt_UserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private LTPLControl.LTPLGridView dgv_Users;
        public LTPLControl.LTPLButtonControl BtnPanel;
        private LTPLControl.LTPLComboBox cmb_EventId;
        private LTPLControl.LTPLComboBox cmb_UserType;
        private System.Windows.Forms.Label lblUserId;

    }
}