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


namespace AARAOFMD
{
    public partial class MainEvent : frmMaster
    {
        public MainEvent()
        {
            InitializeComponent();
        }

        #region Events

        
        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Registration register = new frm_Registration();
            register.MdiParent = this;
            register.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Search search = new frm_Search();
            search.MdiParent = this;
            search.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.frm_ViewMember frm = new Views.frm_ViewMember();
            frm.Show();
        }

        #endregion


        #region button events

        private void btn_Registration_Click(object sender, EventArgs e)
        {
            frm_Registration register = new frm_Registration();
            register.MdiParent = this;
            btn_Registration.Visible = false;
            register.Show();
        }

        #endregion

        private void MainEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F10)
            {
                frm_Login login = new frm_Login();
                login.MdiParent = this;
                this.btn_Registration.Visible = false;
                login.Show();
            }
            if (e.KeyData == Keys.F6)
            {
                frm_Login login = new frm_Login();
                login.MdiParent = this;
                login.Controls["lblEventId"].Visible = false;
                login.Controls["cmb_EventId"].Visible = false;
                this.btn_Registration.Visible = false;
                login.Show();
                
            }
        }

        private void MainEvent_Load(object sender, EventArgs e)
        {
            btn_Registration.Visible = true;
            Global.MsgInfo = "AARA TradeShow 2015";
        }

        

    }
}
