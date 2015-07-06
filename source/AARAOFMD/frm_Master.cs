using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using LTPLControl;
using System.IO;
using SaitecSolutionLib;
using AARAOFMD;
using SaitecSolutionLib;
using System.Drawing.Drawing2D;
using AARAOFMD.Properties;


namespace AARAOFMD
{
    public partial class frmMaster : Form
    {
        #region Variable Declaration
        //=----------------------------------------------------------------------------------------------=
        private bool _canInsert;
        private bool _canUpdate;
        private bool _canDelete;
        private bool _canSelect;
        //=----------------------------------------------------------------------------------------------=
        string _strProcessMessage;
        //=----------------------------------------------------------------------------------------------=
        Error _objErr;
        //=----------------------------------------------------------------------------------------------=
        #endregion
        
        public frmMaster()
        {
            InitializeComponent();
            SetProcessLabel();
        }

        #region Property
        ///==============================================================================================
        /// <summary>
        ///  Set/Get Text For Process Message.
        /// </summary>
        [System.ComponentModel.Category("SaitecSolution")]
        [System.ComponentModel.Description("Set/Get Text For Process Message.")]

        public string ProcessMessageText
        {
            get
            {
                return _strProcessMessage;
            }
            set
            {
                if (value.ToString().Trim() != "")
                    _strProcessMessage = value;
                else
                    _strProcessMessage = " Data Loading... Please Wait ";


            }
        }
        protected bool CanInsert
        {
            get { return _canInsert; }
            set { _canInsert = value; }
        }

        /// <summary>
        /// Gets or sets value indicating whether user can Update data through this Form.
        /// </summary>
        protected bool CanUpdate
        {
            get { return _canUpdate; }
            set { _canUpdate = value; }
        }

        /// <summary>
        /// Gets or sets value indicating whether user can Delete data through this Form.
        /// </summary>
        protected bool CanDelete
        {
            get { return _canDelete; }
            set { _canDelete = value; }
        }

        /// <summary>
        /// Gets or sets value indicating whether user can Select data through this Form.
        /// </summary>
        protected new bool CanSelect
        {
            get { return _canSelect; }
            set { _canSelect = value; }
        }
        #endregion

        #region Method
        //=----------------------------------------------------------------------------------------------=
        /// <summary>
        ///     set default process message
        /// </summary>
        private void SetProcessLabel()
        {
            try
            {
                ProcessMessageText = " Data Loading... Please Wait ";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "[SetProcessLabel Method]", "LTPLForm");
            }

        }
        //=----------------------------------------------------------------------------------------------=
        /// <summary>
        ///     Show Process Message on Form
        /// </summary>
        public void ShowProcessMessage()
        {
            try
            {
                _objLabel.Text = _strProcessMessage;
                int _intX = ((this.Width / 2) - (_objLabel.Width / 2));
                int _intY = ((this.Height / 2) - (_objLabel.Height / 2));
                _objLabel.Location = new Point(_intX, _intY);
                _objLabel.BorderStyle = BorderStyle.FixedSingle;
                _objLabel.BringToFront();
                _objLabel.Visible = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=----------------------------------------------------------------------------------------------=
        /// <summary>
        ///     Hide Process Message on Form
        /// </summary>
        public void HideProcessMessage()
        {
            try
            {
                _objLabel.SendToBack();
                _objLabel.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=----------------------------------------------------------------------------------------------=
        protected void SetBackGroundColor(Control _cltr)
        {
            try
            {
                foreach (Control _cltrs in _cltr.Controls)
                {


                    if (_cltrs is System.Windows.Forms.TabPage)
                    {
                        _cltr.BackColor = Global.ThemeColorLight;
                        _cltrs.ForeColor = Color.Black;
                        SetBackGroundColor(_cltrs);
                    }

                   if (_cltrs is System.Windows.Forms.TabControl)
                    {
                        _cltr.BackColor = Global.ThemeColorLight;
                        _cltrs.ForeColor = Color.Black;
                        SetBackGroundColor(_cltrs);
                    }
                    if (_cltrs is System.Windows.Forms.GroupBox)
                    {
                        _cltrs.ForeColor = Color.Black;

                        SetBackGroundColor(_cltrs);
                    }
                    if (_cltrs is SplitterPanel)
                        SetBackGroundColor(_cltrs);
                    if (_cltrs is System.Windows.Forms.SplitContainer)
                        SetBackGroundColor(_cltrs);
                    if (_cltrs is CheckedListBox)
                        _cltrs.BackColor = Global.ThemeColorLight;
                    if (_cltrs is DateTimePicker)
                    {
                        ((DateTimePicker)_cltrs).CalendarTitleBackColor = Global.ThemeColorDark;
                        ((DateTimePicker)_cltrs).CalendarMonthBackground = Global.ThemeColorLight;


                    }
                    if (_cltrs is LTPLGridView)
                    {
                        //((LTPLGridView)_cltrs).AlternatingRowsDefaultCellStyle.BackColor =  Global.ThemeColorLight; //Color.FromArgb(230, 240, 250); //Color.FromArgb(214, 230, 246);
                        if (Global.ThemeName == "SaitecSolutions")
                            ((LTPLGridView)_cltrs).SetBgColor = Color.FromArgb(189, 171, 168);
                        else
                            ((LTPLGridView)_cltrs).SetBgColor = Global.ThemeColorLight;

                        ((LTPLGridView)_cltrs).RowsDefaultCellStyle.SelectionForeColor = Color.White;
                        ((LTPLGridView)_cltrs).RowsDefaultCellStyle.SelectionBackColor = Global.ThemeColorDark;

                        ((LTPLGridView)_cltrs).AllowUserToResizeRows = false;
                        ((LTPLGridView)_cltrs).SetReadOnlyColBgColor = Global.ThemeColorLight;
                        ((LTPLGridView)_cltrs).EnableHeadersVisualStyles = false;
                        ((LTPLGridView)_cltrs).ColumnHeadersDefaultCellStyle.BackColor = Global.ThemeColorLight;
                        ((LTPLGridView)_cltrs).ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                        ((LTPLGridView)_cltrs).CellBorderStyle = DataGridViewCellBorderStyle.None;
                        ((LTPLGridView)_cltrs).ColumnHeadersDefaultCellStyle.BackColor = Global.ThemeGridHeaderCell;


                        //if (((LTPLGridView)_cltrs).TotalCol != null || ((LTPLGridView)_cltrs).SummaryCol != null)
                        //{
                        //    int _intHeight = (((LTPLGridView)_cltrs).Height - ((LTPLGridView)_cltrs).ColumnHeadersHeight) % (((LTPLGridView)_cltrs).RowTemplate.Height);
                        //    if (((LTPLGridView)_cltrs).Dock == DockStyle.Fill)
                        //        ((LTPLGridView)_cltrs).Parent.Height = ((LTPLGridView)_cltrs).Parent.Height - _intHeight - 2;
                        //    else
                        //        ((LTPLGridView)_cltrs).Height = ((LTPLGridView)_cltrs).Height - _intHeight - 2;
                        //}

                        ((LTPLGridView)_cltrs).AllowUserToResizeRows = false;
                        ((LTPLGridView)_cltrs).EnableHeadersVisualStyles = false;
                        ((LTPLGridView)_cltrs).ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                        ((LTPLGridView)_cltrs).CellBorderStyle = DataGridViewCellBorderStyle.None;
                    }

                    if (_cltrs is LTPLLOV)
                    {
                        ((LTPLLOV)_cltrs).BackColor = Global.ThemeColorDark;// Color.FromArgb(210, 202, 196); //Global.ThemeColorDark;
                        ((LTPLLOV)_cltrs).BarColor = Global.ThemeColorLight;
                        ((LTPLLOV)_cltrs).LOVGrid.ColumnHeadersDefaultCellStyle.BackColor = Global.ThemeGridHeaderCell;


                    }
                    if (_cltrs is LTPLButtonControl)
                    {
                        ((LTPLButtonControl)_cltrs).SetColor = Global.ThemeColorDark;
                        ((LTPLButtonControl)_cltrs).SetLightColor = Global.ThemeColorLight;
                        //((LTPLButtonControl)_cltrs).Height = 42;
                    }
                    if (_cltrs is LTPLReprotButtonControl)
                    {
                        ((LTPLReprotButtonControl)_cltrs).SetColor = Global.ThemeColorDark;
                        ((LTPLReprotButtonControl)_cltrs).Height = 42;
                        ((LTPLReprotButtonControl)_cltrs).SetLightColor = Global.ThemeColorLight;

                    }
                    if (_cltrs is LTPLGroupBox)
                    {
                        if (((LTPLGroupBox)_cltrs).BackgroundGradientMode != LTPLGroupBox.GroupBoxGradientMode.None)
                        {
                            ((LTPLGroupBox)_cltrs).BackgroundColor = Global.ThemeColorLight;
                            ((LTPLGroupBox)_cltrs).BackgroundGradientColor = Global.ThemeColorDark;
                            ((LTPLGroupBox)_cltrs).ShadowColor = Global.ThemeColorDark;
                            ((LTPLGroupBox)_cltrs).BackgroundGradientMode = LTPLGroupBox.GroupBoxGradientMode.BackwardDiagonal;
                            ((LTPLGroupBox)_cltrs).ShadowThickness = 3;
                        }


                        //((LTPLGroupBox)_cltrs).BorderColor = Global.ThemeColorLight;
                    }
                    if (_cltrs is Panel)
                    {
                        ((Panel)_cltrs).BackColor = Global.ThemeColorDark;
                    }
                }

            }
            catch (Exception ex)
            { }
        }

        

        #endregion

        private void frmMaster_Paint(object sender, PaintEventArgs e)
        {
            Global.Paint(this, e);
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            SetBackGroundColor(this);
        }

        private void frmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                foreach (Control _cltrs in this.Controls)
                {


                    if (_cltrs is LTPLButtonControl)

                        if (((LTPLButtonControl)_cltrs).ButtonAddText == "&Save" && ((LTPLButtonControl)_cltrs).ButtonAddEnable == true)
                        {
                            if (Global.Confirmation("Are You Sure You want to Close Form Without Save Data..?", Resources.DialogText, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                e.Cancel = true;
                        }

                }
            }
            catch (Exception)
            { }
        }

        private void frmMaster_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        
        
    }
}
