using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaitecSolutionLib.Properties;

namespace SaitecSolutionLib
{
    public enum InstanceType { Local, Remote };
    public static class Global
    {
        static string _msginfo;
        static string _UserId;
        static string _UserName;
        static string _AlphanumericCode;
        static string _Cphone;
        static string _Bphone;
        public static InstanceType InstanceType;
        public static Color ThemeColorDark = Color.FromArgb(148, 138, 84);
        public static Color ThemeColorLight = Color.FromArgb(221, 217, 195);
        public static Color ThemeGridHeaderCell = Color.FromArgb(221, 217, 195);
        public static String ThemeName = "Saitec Solutions";
        public static Color DarkColor = Color.FromArgb(165, 147, 135);
        public static Color LightColor = Color.Snow;

        public static string MsgInfo
        {
            get { return _msginfo; }
            set { _msginfo = value; }
        }
        public static string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public static string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public static string AlphaNumericCode
        {
            get { return _AlphanumericCode; }
            set { _AlphanumericCode = value; }
        }
        public static string BusinessPhone
        {
            get { return _Bphone; }
            set { _Bphone = value; }
        }
        public static string CellPhone
        {
            get { return _Cphone; }
            set { _Cphone = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Form"></param>
        /// <param name="e"></param>
        public static void Paint(Form Form, PaintEventArgs e)
        {
            //Color _colorDark = Color.FromArgb(165, 147, 135); //Color.FromArgb(210, 202, 196);// Color.FromArgb(165, 147, 135); //Color.LightGray;
            //Color _colorLight = Color.Snow; //Color.White; // Color.FromArgb(227, 234, 242);//Color.Snow; //

            //Set Form Text
            //if (Global.IsSuperAdmin)
            //    Form.Text = "[" + Global.UserName + " :: " + Global.CompanyName + " :: " + Global.BranchName + "]";
            //else
            //    Form.Text = "[" + Global.BranchName + " :: " + Global.Entity + "]"; //+ " :: " + Global.UserName + 
            //For Horizontal BAR



            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Form.Width, 30), DarkColor, LightColor, 270, true);
            //LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Form.Width, 30), Color.FromArgb(142, 142, 142), LightColor, 270, true);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Form.Width, 30));

            //For Form Area
            LinearGradientBrush brush1 = new LinearGradientBrush(new Rectangle(5, 30, Form.Width, Form.Height), DarkColor, LightColor, 0, true);
            e.Graphics.FillRectangle(brush1, new Rectangle(30, 30, Form.Width, Form.Height));

            //For Line and Vertical BAR
            LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(0, 30, 5, Form.Height), DarkColor, DarkColor, 0, true);
            e.Graphics.FillRectangle(brush3, new Rectangle(0, 30, 5, Form.Width));

            LinearGradientBrush FontColor = new LinearGradientBrush(new Rectangle(0, 30, 5, Form.Height), Color.Black, Color.Black, 0, true);
            //e.Graphics.FillRectangle(brush3, new Rectangle(0, 30, 5, Form.Width));

            LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(5, 30, 25, Form.Height), DarkColor, LightColor, 0, true);
            //LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(5, 30, 25, Form.Height), Color.FromArgb(142, 142, 142), LightColor, 0, true);
            e.Graphics.FillRectangle(brush4, new Rectangle(5, 30, 25, Form.Height));


            //For PictureBox
            //LinearGradientBrush brush5 = new LinearGradientBrush(new Rectangle(1,1,25,25),   Color.FromArgb(192, 192, 192),
            //                                                       Color.FromArgb(0, 19, 127),
            //                                                       50F);
            //e.Graphics.FillRectangle(brush5, new Rectangle(1, 1, 25, 25));

            Icon icon = new Icon((Icon)Resources.ResourceManager.GetObject("eXHIBIT_SMART_LOGO11"),new Size(15,15));
            e.Graphics.DrawIcon(icon,new Rectangle(2,2,25,25));
            

            //For Text Color
            LinearGradientBrush txtBrush = new LinearGradientBrush(new Rectangle(0, 30, 5, Form.Height), Color.Black, Color.Black, 0, true);
            //For Form Name
            if (Form.Tag.ToString().Trim() == "")
                Form.Tag = Form.Text;
            e.Graphics.DrawString(Form.Tag.ToString().Trim(), new Font("VERDANA", 11.25F, FontStyle.Bold), txtBrush, 30, 5, StringFormat.GenericTypographic);
            StringFormat _strFormat = new StringFormat();

            //for Company Name on vertical bar
            _strFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            string _strArr;
            _strArr = "SAITEC";// Global.CompanyName;
            int _cnt = 200;
            for (int _intCnt = 0; _intCnt <= _strArr.Length - 1; _intCnt++)
            {
                e.Graphics.DrawString(_strArr[_intCnt].ToString().ToUpper(), new Font("Impact", 11.25F, FontStyle.Regular), txtBrush, 8, Form.Height - _cnt, _strFormat);
                if (_strArr[_intCnt] != '.')
                    _cnt = _cnt - 15;
            }
        }

        /// <summary>
        /// Prompt Information Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Information(string p_Message, string headerText)
        {

            return Message(new Exception(p_Message), headerText, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        /// <summary>
        /// Prompt Confirmation Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Confirmation(string p_Message, string headerText)
        {
            return Message(new Exception(p_Message), headerText, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        /// <summary>
        /// Prompt Confirmation Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <param name="mboxbtn"></param>
        /// <param name="mboxdefbtn"></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Confirmation(string p_Message, string headerText, MessageBoxButtons mboxbtn, MessageBoxDefaultButton mboxdefbtn)
        {

            return Message(new Exception(p_Message), headerText, mboxbtn, MessageBoxIcon.Question, mboxdefbtn);
        }
        /// <summary>
        /// Prompt Warning Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Warning(string p_Message, string headerText)
        {
            return Message(new Exception(p_Message), headerText, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        /// <summary>
        /// Prompt any type of Message on the Form.
        /// </summary>
        /// <param name="e"><para>Exception whose Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <param name="mboxbtn"></param>
        /// <param name="mboxicon"></param>
        /// <param name="mboxdefbtn"></param>
        /// <param name="mboxopt"></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Message(Exception e, string headerText, MessageBoxButtons mboxbtn, MessageBoxIcon mboxicon, MessageBoxDefaultButton mboxdefbtn, MessageBoxOptions mboxopt)
        {
            return MessageBox.Show(e.Message, headerText, mboxbtn, mboxicon, mboxdefbtn, mboxopt);
        }
        /// <summary>
        /// Prompt any type of Message on the Form.
        /// </summary>
        /// <param name="e"><para>Exception whose Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <param name="mboxbtn"></param>
        /// <param name="mboxicon"></param>
        /// <param name="mboxdefbtn"></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Message(Exception e, string headerText, MessageBoxButtons mboxbtn, MessageBoxIcon mboxicon, MessageBoxDefaultButton mboxdefbtn)
        {
            return MessageBox.Show(e.Message, headerText, mboxbtn, mboxicon, mboxdefbtn);
        }
        /// <summary>
        /// This method creates instance of Remote object.
        /// </summary>
        /// <param name="serverType"></param>
        /// <returns>Remote object of Remote service.</returns>
        public static object CreateInstance(Type serverType)
        {
            if (InstanceType.Local == Global.InstanceType)
                return Activator.CreateInstance(serverType);
            else
            {
                string url = ConfigurationSettings.AppSettings["RemoteServer"];
                DiaSoftProxy proxy = new DiaSoftProxy(serverType, url + serverType.ToString() + ".rem");

                object mbrClient = proxy.GetTransparentProxy();
                //if (!_htMarshalObject.Contains(serverType))
                //    _htMarshalObject.Add(serverType, proxy.CreateObjRef(mbrClient.GetType()));
                //else
                //    _htMarshalObject[serverType] = proxy.CreateObjRef(serverType);

                return mbrClient;
            }
        }

        /// <summary>
        /// Prompt Error Message on the Form.
        /// </summary>
        /// <param name="e"><para>Exception whose Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Error(Exception e, string headerText)
        {

            try
            {
                if (!e.Message.StartsWith("SaitecLib-*#06# : "))
                {

                    if (e.GetType() == typeof(InformationException))
                        return Information(e.Message, headerText);
                    else if (e.GetType() == typeof(WarningException))
                        return Warning(e.Message, headerText);
                   
                }
                return Error(e.Message, headerText);
            }
            catch (Exception ex)
            {
                return Message(ex, "Error in Writing Log", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }
        /// <summary>
        /// Prompt Error Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Error(string p_Message, string headerText)
        {
            if (p_Message.Contains("Sunday"))
            {
                p_Message = "You Can Not Do Entry Or Lot Creation on Sunday...! Please Contact Administrator..";
            }
            else if (p_Message.Contains("Holiday"))
            {
                p_Message = "You Can Not Do Entry Or Lot Creation on Holiday...! Please Contact Administrator..";
            }

            return Message(new Exception(p_Message), headerText, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static string EncryptedPassword(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string DecryptedPassword(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        
    }
}
