using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Auto.Web.Infrastucture.Helpers
{
    public static class EmailHelper
    {
        public static string EmailValidationExpression
        {
            get
            {
                return @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                     @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                     @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            }
        }

        public static bool IsValidEmail(string email)
        {
            Regex re = new Regex(EmailValidationExpression);
            return re.Match(email).Success;
        }

        public static void SendMessage(string toAddress, string fromAddress, string fromName, string subject, string body)
        {
            string server = ConfigurationManager.AppSettings["SMTPServer"].ToString();
            string port = ConfigurationManager.AppSettings["SMTPServerPort"].ToString();
            string username = ConfigurationManager.AppSettings["SMTPUsername"].ToString();
            string password = ConfigurationManager.AppSettings["SMTPPassword"].ToString();
            //string bccAddress = ConfigurationManager.AppSettings["ToAddress"].ToString();

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(fromAddress, fromName);
            mm.To.Add(toAddress);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.Normal;
            SmtpClient sc = new SmtpClient(server);
            sc.Port = Convert.ToInt32(port);
            sc.Credentials = new NetworkCredential(username, password);
            sc.Send(mm);
            mm.Dispose();
            sc = null;
        }

        public static void SendMessage(string toAddress, string subject, string body)
        {
            string server = ConfigurationManager.AppSettings["SMTPServer"].ToString();
            string port = ConfigurationManager.AppSettings["SMTPServerPort"].ToString();
            string username = ConfigurationManager.AppSettings["SMTPUsername"].ToString();
            string password = ConfigurationManager.AppSettings["SMTPPassword"].ToString();
            string bccAddress = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            string fromAddress = ConfigurationManager.AppSettings["SMTPUsername"].ToString();
            string siteName = ConfigurationManager.AppSettings["Site.Name"].ToString();

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(fromAddress, siteName);
            //mm.Bcc.Add(toAddress);
            mm.To.Add(toAddress);
            mm.Subject = "autolisting: " + subject;
            mm.Body = body;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.Normal;
            SmtpClient sc = new SmtpClient(server);
            sc.Port = Convert.ToInt32(port);
            sc.Credentials = new NetworkCredential(username, password);
            //sC.EnableSsl = true;
            sc.Send(mm);
            mm.Dispose();
            sc = null;
        }

        public static void SendMessage(string subject, string body)
        {
            //try
            //{
            SendEmailInAThread(subject, body);
            //}
            //catch { }
        }

        private static void SendEmailInAThread(string subject, string body)
        {
            string toAddress = ConfigurationManager.AppSettings["ToAddress"].ToString();
            string fromAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();
            string siteName = ConfigurationManager.AppSettings["SiteName"].ToString();

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(fromAddress, siteName);
            //mm.Bcc.Add(toAddress);
            mm.To.Add(toAddress);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.Normal;

            Thread tA = new Thread(new ParameterizedThreadStart(EmailSenderThread));
            tA.Start(mm);
        }

        private static void EmailSenderThread(Object obj)
        {
            MailMessage mm = new MailMessage();
            mm = (MailMessage)obj;

            string server = ConfigurationManager.AppSettings["SMTPServer"].ToString();
            string port = ConfigurationManager.AppSettings["SMTPServerPort"].ToString();
            string username = ConfigurationManager.AppSettings["SMTPUsername"].ToString();
            string password = ConfigurationManager.AppSettings["SMTPPassword"].ToString();

            SmtpClient sc = new SmtpClient(server);
            sc.Port = Convert.ToInt32(port);
            sc.Credentials = new NetworkCredential(username, password);
            //sC.EnableSsl = true;
            sc.Send(mm);
            mm.Dispose();
            sc = null;
        }

        public static void SendMessage(string subject)
        {
            string body = "";
            try
            {
                string server = ConfigurationManager.AppSettings["SMTPServer"].ToString();
                string port = ConfigurationManager.AppSettings["SMTPServerPort"].ToString();
                string username = ConfigurationManager.AppSettings["SMTPUsername"].ToString();
                string password = ConfigurationManager.AppSettings["SMTPPassword"].ToString();
                string toAddress = ConfigurationManager.AppSettings["ToAddress"].ToString();
                string fromAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();
                string siteName = ConfigurationManager.AppSettings["SiteName"].ToString();

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(fromAddress, siteName);
                //mm.Bcc.Add(toAddress);
                mm.To.Add(toAddress);
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                mm.Priority = MailPriority.Normal;
                SmtpClient sc = new SmtpClient(server);
                sc.Port = Convert.ToInt32(port);
                sc.Credentials = new NetworkCredential(username, password);
                //sC.EnableSsl = true;
                sc.Send(mm);
            }
            catch { }
        }

        public static void SendMessageWithTemplate(string subject, string HEADER_TITLE, string PERSON_FIRST_NAME, string CONTENT, string FOOTER_MESSAGE, string RECIPIENT_EMAIL_ADDRESS, bool sendToActual, int AccountTypeID)
        {
            StringBuilder sb = new StringBuilder();
            if (sendToActual == true)
            {
                SendMessage(RECIPIENT_EMAIL_ADDRESS, subject, sb.ToString());

                // cc 
            }
            else
            {
                SendMessage(ConfigurationManager.AppSettings["ToAddress"].ToString(), subject, sb.ToString());
            }
        }
        #region Senders

        public static void SendMessage(string mailServer, string mailPort, string message, string sender, string recipient, string subject, IList<string> bccEmailAddresses)
        {
            SmtpClient mailClient = new SmtpClient(mailServer);
            mailClient.Port = Int32.Parse(mailPort);

            MailMessage emailMessage = new MailMessage(sender, recipient, subject, message);

            if (bccEmailAddresses != null && bccEmailAddresses.Count > 0)
                foreach (string bccEmailAddress in bccEmailAddresses)
                    emailMessage.Bcc.Add(new MailAddress(bccEmailAddress));

            mailClient.Send(emailMessage);
        }

        public static void SendMessage(string mailServer, string mailPort, string message, string sender, string recipient, string subject, IList<string> bccEmailAddresses, bool isHtml)
        {
            SendEmail(mailServer, mailPort, message, sender, recipient, subject, bccEmailAddresses, isHtml);
        }

        private static void SendEmail(string mailServer, string mailPort, string message, string sender, string recipient, string subject, IList<string> bccEmailAddresses, bool isHtml)
        {
            SmtpClient mailClient = new SmtpClient(mailServer);
            mailClient.Port = Int32.Parse(mailPort);

            MailMessage emailMessage = new MailMessage(sender, recipient, subject, message);
            emailMessage.IsBodyHtml = isHtml;

            if (bccEmailAddresses != null && bccEmailAddresses.Count > 0)
                foreach (string bccEmailAddress in bccEmailAddresses)
                    emailMessage.Bcc.Add(new MailAddress(bccEmailAddress));

            mailClient.Send(emailMessage);
        }

        #endregion

        #region Send mail with attachment
        public static void SendMessage(string mailServer, string mailPort, string message, string sender, string recipient, string subject, IList<string> bccEmailAddresses, bool isHtml, Attachment attachment)
        {
            SendEmail(mailServer, mailPort, message, sender, recipient, subject, bccEmailAddresses, isHtml, attachment);
        }

        private static void SendEmail(string mailServer, string mailPort, string message, string sender, string recipient, string subject, IList<string> bccEmailAddresses, bool isHtml, Attachment attachment)
        {
            SmtpClient mailClient = new SmtpClient(mailServer);
            mailClient.Port = Int32.Parse(mailPort);

            MailMessage emailMessage = new MailMessage(sender, recipient, subject, message);
            emailMessage.IsBodyHtml = isHtml;

            emailMessage.Attachments.Add(attachment);

            if (bccEmailAddresses != null && bccEmailAddresses.Count > 0)
                foreach (string bccEmailAddress in bccEmailAddresses)
                    emailMessage.Bcc.Add(new MailAddress(bccEmailAddress));

            mailClient.Send(emailMessage);
        }
        #endregion
    }

}
