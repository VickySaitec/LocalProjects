using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Data;
using System.IO;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Mail
/// </summary>
namespace SaitecSolutionLib
{
    public class Mail
    {
        #region Constructor

        public Mail()
        { }

        #endregion

        #region Functions

        public static bool SendMailVal(string[] content)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("event-no-reply@saitecweb.com");
            // Gmail Address from where you send the mail
            var fromAddress = "event-no-reply@saitecweb.com";
            // any address where the email will be sending
            //var toAddress = "vick.b0615@saitecpos.com";
            mail.To.Add(content[2]);

            const string fromPassword = "E$#p=o-123";
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential(fromAddress, fromPassword);
            //Password of your gmail address

            // Passing the values and make a email formate to display
            mail.Subject = "REGISTRATION : AARA Tradeshow 2015";
            string location = "7310 Park Heights Avenue,Baltimore MD 21208";
            //StringBuilder str = GetString(mail, new DateTime(2015, 6, 28, 9, 0, 0), new DateTime(2015, 6, 28, 11, 0, 0), location);
            string filepath = MakeHoursEvent(mail, new DateTime(2015, 6, 28, 2, 0, 0), new DateTime(2015, 6, 28, 6, 0, 0), location);
            //String[] _strarray = new String[str.Length];

            //System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath();
            mail.IsBodyHtml = true;
            string body = string.Empty;
            //body = content[2];

            body = "<!DOCTYPE html>" +
                    "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                    "<head>" +
                        "<title></title>" +
                    "</head>" +
                    "<body>" +
                        "<div style = 'border-top:3px solid #22BCE5'>&nbsp;</div>" +
                        "<span style = 'font-family:Verdana;font-size:10pt'>" +
                            "Dear <b>{Name}</b>,<br /><br /> " +
                            "You’re successfully registered for the event: AARA Tradeshow 2015.<br /><br /> " +
                            "<u>What should you do NEXT on the EVENT DAY? :</u>" +
                            "<ul type='disc'>" +
                                "<li>Go to main entrance and visit “Badge Pickup” counter.</li>" +
                                "<li>Provide your registered phone number : {Phonenumber}, in order to receive your badge.</li>" +
                                "<li>Keep your badge visible, during your event visit</li>" +
                            "</ul>" +
                            "<br />" +
                            "Location : <b>{Location}</b><br />" +
                            "Time     : <b>{DateTime}</b><br />" +
                            "<br /><br /> " +
                            "Thank you <br />" +
                            "Registration Manager <br />" +
                            "Saitec Solutions Inc. <br />" +
                            "<br /><br />" +
                            "The information contained in this email is intended solely for the addressee to confirm their registration at the event and may be confidential and legally privileged. In the event you are not the intended recipient of this email or have obtained unauthorized access, please notify at " +
                            "<a href='mailto:info@saitec-solutions.com'>info@saitec-solutions.com</a>" +
                            "and destroy the email.  You are strictly prohibited from reading it and from disclosing or using its contents in any manner, and doing so may result in criminal and/or civil liability.   Email transmission and attachments cannot be guaranteed to be secure or error-free. Saitec Solutions (USA), Inc. does not accept legal responsibility for any errors, omissions, security issues or viruses associated with your receipt of this email.<br />" +
                            "Event Registration Powered By Saitec Solutions (USA) Inc." +

                        "</span>" +


                    "</body>" +
                    "</html>";


            body = body.Replace("{Name}", content[0]);
            body = body.Replace("{Phonenumber}", content[1]);
            body = body.Replace("{Location}", location);
            body = body.Replace("{DateTime}", new DateTime(2015, 6, 28, 14, 30, 0) + " To " + new DateTime(2015, 6, 28, 18, 0, 0));
            mail.Body = body;

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }

            // This is the another way to display the calendar.
            //string location = "7310 Park Heights Avenue,Baltimore MD 21208";
            //StringBuilder str = GetString(mail, new DateTime(2015, 6, 28, 9, 0, 0), new DateTime(2015, 6, 28, 11, 0, 0), location);
            //System.Net.Mime.ContentType type = new System.Net.Mime.ContentType("text/Calendar");
            //type.Parameters.Add("method", "REQUEST");
            //type.Parameters.Add("name", "Cita.ics");
            //mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(str.ToString(), type));

            Attachment atach = new Attachment(filepath);
            mail.Attachments.Add(atach);

            // Passing values to smtp object
            try
            {
                smtp.Send(mail);
                mail.Dispose();
                smtp.Dispose();
                atach.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool SendMailVal_xHibitor(string[] content)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("event-no-reply@saitecweb.com");

            var fromAddress = "event-no-reply@saitecweb.com";
            mail.To.Add("rutvij@saitecweb.com");
            //mail.To.Add("Vikrant.Bhatt87@gmail.com");
            const string fromPassword = "E$#p=o-123";
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential(fromAddress, fromPassword);
            mail.Subject = "NEW GUEST REGISTERED ONLINE : AARA TRADESHOW 2015";
            string location = "7310 Park Heights Avenue,Baltimore MD 21208";
            string filepath = MakeHoursEvent(mail, new DateTime(2015, 6, 28, 2, 0, 0), new DateTime(2015, 6, 28, 6, 0, 0), location);
            mail.IsBodyHtml = true;
            string body = string.Empty;
            //body = content[3];
            body = "<!DOCTYPE html>" +
                    "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                    "<head>" +
                        "<title></title>" +
                    "</head>" +
                    "<body>" +
                        "<div style = 'border-top:3px solid #22BCE5'>&nbsp;</div>" +
                        "<span style = 'font-family:Verdana;font-size:10pt'>" +
                            "<b>A Guest Registered Online !!</b>,<br /><br />" +
                            "Name : <b>{Name}</b><br />" +
                            "Phone : <b>{Phone}</b><br />"  +
                            "Email : <b>{Email}</b><br />" +
                            "<br /><br />" +
                            "Thank you <br />" +
                            "Registration Manager <br />" +
                            "Saitec Solutions Inc.<br /><br />" +
                            "The information contained in this email is intended solely for the addressee to inform a new registration at the event and may be confidential and legally privileged. In the event you are not the intended recipient of this email or have obtained unauthorized access, please notify at " +
                            "<a href='mailto:info@saitec-solutions.com'>info@saitec-solutions.com</a>" +
                            " and destroy the email.  You are strictly prohibited from reading it and from disclosing or using its contents in any manner, and doing so may result in criminal and/or civil liability.   Email transmission and attachments cannot be guaranteed to be secure or error-free. Saitec Solutions (USA), Inc. does not accept legal responsibility for any errors, omissions, security issues or viruses associated with your receipt of this email.<br />" +
                            "Event Registration Powered By Saitec Solutions (USA) Inc." +

                        "</span>" +
                    "</body>" +
                    "</html>" ;


            body = body.Replace("{Name}", content[0]);
            body = body.Replace("{Phone}", content[1]);
            body = body.Replace("{Email}", content[2]);
            mail.Body = body;

            // Passing values to smtp object
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            //attach the file
            Attachment attach = new Attachment(filepath);
            mail.Attachments.Add(attach);


            try
            {
                smtp.Send(mail);
                smtp.Dispose();
                attach.Dispose();
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static StringBuilder GetString(MailMessage msg, DateTime START_DATE, DateTime END_DATE, string Direccion)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//GeO");
            str.AppendLine("VERSION:2.0");
            str.AppendLine("METHOD:REQUEST");
            str.AppendLine("BEGIN:VEVENT");
            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", START_DATE));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", END_DATE));
            str.AppendLine("LOCATION: " + Direccion);
            str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
            //str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
            //str.AppendLine(string.Format("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:{0}", msg.Body));

            //str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
            str.AppendLine(string.Format("SUMMARY;ENCODING=QUOTED-PRINTABLE:{0}", msg.Subject));
            str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));

            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");
            return str;
        }

        public static string MakeHoursEvent(MailMessage msg, DateTime START_DATE, DateTime END_DATE, string Direccion)
        {
            string filepath = string.Empty;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime Start_Time = TimeZoneInfo.ConvertTimeFromUtc(START_DATE, easternZone);
            DateTime End_Time = TimeZoneInfo.ConvertTimeFromUtc(END_DATE, easternZone);

            string path = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\" + msg.Subject + ".ics";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            // read the file 
            //string desc = string.Empty;
            //StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/Description.html"));
            //desc = sr.ReadToEnd();
            //sr.Dispose();

            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine("BEGIN:VCALENDAR");
            writer.WriteLine("PRODID:-//GeO");
            writer.WriteLine("VERSION:2.0");
            writer.WriteLine("METHOD:REQUEST");
            writer.WriteLine("BEGIN:VEVENT");
            writer.WriteLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", Start_Time));
            writer.WriteLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.Now));
            writer.WriteLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", End_Time));
            writer.WriteLine("LOCATION: " + Direccion);
            writer.WriteLine(string.Format("UID:{0}", Guid.NewGuid()));
            //str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
            //writer.WriteLine(string.Format("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:{0}", desc));

            //writer.WriteLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", desc));
            writer.WriteLine(string.Format("SUMMARY;ENCODING=QUOTED-PRINTABLE:{0}", msg.Subject));
            writer.WriteLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));

            writer.WriteLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));

            writer.WriteLine("BEGIN:VALARM");
            writer.WriteLine("TRIGGER:-PT15M");
            writer.WriteLine("ACTION:DISPLAY");
            writer.WriteLine("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:Reminder");
            writer.WriteLine("END:VALARM");
            writer.WriteLine("END:VEVENT");
            writer.WriteLine("END:VCALENDAR");
            writer.Close();
            return path;
        }

        #endregion
    }
    
}
