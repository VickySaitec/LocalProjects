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
    public partial class frm_Search : Form
    {
        #region Declared Varible

        Wrapper wrap;
        public static string registrationid;
        public static string bphone;
        public static string cphone;

        #endregion


        #region Constructor
        public frm_Search()
        {
            InitializeComponent();
            wrap = new Wrapper();
        }
        #endregion

        #region Button Events

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Global.BusinessPhone = txt_BusiPhone.Text == string.Empty ? null : txt_BusiPhone.Text.Trim();
            Global.CellPhone = txt_CellPhone.Text == string.Empty ? null : txt_CellPhone.Text.Trim();
            DataTable dt = wrap.SearchData("Proc_SearchData",Global.BusinessPhone,Global.CellPhone);

            if (dt.Rows.Count > 0)
            {
                Grd_Search.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idx = Grd_Search.Rows.Add();

                    Grd_Search.Rows[idx].Cells[0].Value = dt.Rows[i]["member_aara"];
                    Grd_Search.Rows[idx].Cells[1].Value = dt.Rows[i]["registration_id"];
                    Grd_Search.Rows[idx].Cells[2].Value = dt.Rows[i]["Name"];
                    Grd_Search.Rows[idx].Cells[3].Value = dt.Rows[i]["Contact"];
                    Grd_Search.Rows[idx].Cells[4].Value = dt.Rows[i]["Email"];
                    Grd_Search.Rows[idx].Cells[5].Value = "View";
                    
                }
            }
            
        }

        #endregion

        #region Control Events

        private void Grd_Search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int rindex = e.RowIndex;
                int cindex = e.ColumnIndex;

                registrationid = Grd_Search.Rows[rindex].Cells[1].Value.ToString();
                string[] phones = Grd_Search.Rows[rindex].Cells[3].Value.ToString().Split('/');
                bphone = phones[0];
                cphone = phones[1];
                Views.frm_ViewMember frm = new Views.frm_ViewMember();
                frm.Show(this);
            }
        }

        #endregion

        private void frm_Search_Load(object sender, EventArgs e)
        {
            frm_Registration.setImage(picb_Logo, 193, 117);
        }

       
    }
}
