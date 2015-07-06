namespace AARAOFMD
{
    partial class frmMaster
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
            this._objLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _objLabel
            // 
            this._objLabel.AutoSize = true;
            this._objLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this._objLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._objLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._objLabel.Location = new System.Drawing.Point(12, 9);
            this._objLabel.Name = "_objLabel";
            this._objLabel.Size = new System.Drawing.Size(0, 18);
            this._objLabel.TabIndex = 0;
            this._objLabel.Visible = false;
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(706, 478);
            this.Controls.Add(this._objLabel);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "Master Form";
            this.Text = "Master Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmMaster_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMaster_Paint);
            this.Resize += new System.EventHandler(this.frmMaster_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _objLabel;
    }
}