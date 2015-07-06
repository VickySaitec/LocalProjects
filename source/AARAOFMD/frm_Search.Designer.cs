namespace AARAOFMD
{
    partial class frm_Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Search));
            this.lbl_BusiPhone = new System.Windows.Forms.Label();
            this.txt_BusiPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CellPhone = new System.Windows.Forms.TextBox();
            this.lbl_Cellphone = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Grd_Search = new System.Windows.Forms.DataGridView();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registrationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Operation = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picb_Logo = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Search)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_BusiPhone
            // 
            this.lbl_BusiPhone.AutoSize = true;
            this.lbl_BusiPhone.Location = new System.Drawing.Point(17, 37);
            this.lbl_BusiPhone.Name = "lbl_BusiPhone";
            this.lbl_BusiPhone.Size = new System.Drawing.Size(109, 16);
            this.lbl_BusiPhone.TabIndex = 0;
            this.lbl_BusiPhone.Text = "Business Phone";
            // 
            // txt_BusiPhone
            // 
            this.txt_BusiPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BusiPhone.Location = new System.Drawing.Point(132, 34);
            this.txt_BusiPhone.Name = "txt_BusiPhone";
            this.txt_BusiPhone.Size = new System.Drawing.Size(172, 23);
            this.txt_BusiPhone.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "OR";
            // 
            // txt_CellPhone
            // 
            this.txt_CellPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CellPhone.Location = new System.Drawing.Point(132, 86);
            this.txt_CellPhone.Name = "txt_CellPhone";
            this.txt_CellPhone.Size = new System.Drawing.Size(172, 23);
            this.txt_CellPhone.TabIndex = 3;
            // 
            // lbl_Cellphone
            // 
            this.lbl_Cellphone.AutoSize = true;
            this.lbl_Cellphone.Location = new System.Drawing.Point(17, 89);
            this.lbl_Cellphone.Name = "lbl_Cellphone";
            this.lbl_Cellphone.Size = new System.Drawing.Size(76, 16);
            this.lbl_Cellphone.TabIndex = 4;
            this.lbl_Cellphone.Text = "Cell Phone";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(384, 37);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(108, 68);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_BusiPhone);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.lbl_BusiPhone);
            this.groupBox1.Controls.Add(this.lbl_Cellphone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_CellPhone);
            this.groupBox1.Location = new System.Drawing.Point(7, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria : ";
            // 
            // Grd_Search
            // 
            this.Grd_Search.AllowUserToAddRows = false;
            this.Grd_Search.AllowUserToDeleteRows = false;
            this.Grd_Search.AllowUserToOrderColumns = true;
            this.Grd_Search.BackgroundColor = System.Drawing.Color.White;
            this.Grd_Search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grd_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Search.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Member,
            this.Registrationid,
            this.Name,
            this.Contact,
            this.Email,
            this.Action});
            this.Grd_Search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Grd_Search.GridColor = System.Drawing.Color.Silver;
            this.Grd_Search.Location = new System.Drawing.Point(0, 282);
            this.Grd_Search.Name = "Grd_Search";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Search.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grd_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd_Search.Size = new System.Drawing.Size(607, 135);
            this.Grd_Search.TabIndex = 7;
            this.Grd_Search.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_Search_CellClick);
            // 
            // Member
            // 
            this.Member.HeaderText = "Member";
            this.Member.Name = "Member";
            this.Member.Width = 120;
            // 
            // Registrationid
            // 
            this.Registrationid.HeaderText = "Registration Id";
            this.Registrationid.Name = "Registrationid";
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 120;
            // 
            // Contact
            // 
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            this.Contact.Width = 110;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 120;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Operation);
            this.panel1.Controls.Add(this.lbl_Title);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 132);
            this.panel1.TabIndex = 8;
            // 
            // lbl_Operation
            // 
            this.lbl_Operation.AutoSize = true;
            this.lbl_Operation.BackColor = System.Drawing.Color.White;
            this.lbl_Operation.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Operation.ForeColor = System.Drawing.Color.Black;
            this.lbl_Operation.Location = new System.Drawing.Point(326, 63);
            this.lbl_Operation.Name = "lbl_Operation";
            this.lbl_Operation.Size = new System.Drawing.Size(147, 45);
            this.lbl_Operation.TabIndex = 6;
            this.lbl_Operation.Text = "Search";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(209, 18);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(379, 45);
            this.lbl_Title.TabIndex = 5;
            this.lbl_Title.Text = "AARA TRADESHOW";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picb_Logo);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 123);
            this.panel2.TabIndex = 4;
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
            // frm_Search
            // 
            this.AcceptButton = this.btn_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 417);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Grd_Search);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.Name = "frm_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frm_Search_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Search)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picb_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_BusiPhone;
        private System.Windows.Forms.TextBox txt_BusiPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CellPhone;
        private System.Windows.Forms.Label lbl_Cellphone;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Grd_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registrationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picb_Logo;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Operation;
    }
}