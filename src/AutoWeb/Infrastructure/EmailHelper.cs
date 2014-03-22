using System;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;

public static class EmailHelper
{
    public static void SendMessage(string message, string recipient, string subject)
    {
        string mailServer = WebConfigurationManager.AppSettings["SMTPServer"];
        string mailPort = WebConfigurationManager.AppSettings["SMTPServerPort"];
        string mailUsername = WebConfigurationManager.AppSettings["SMTPUsername"];
        string mailPassword = WebConfigurationManager.AppSettings["SMTPPassword"];
        string EmailFriendlyName = WebConfigurationManager.AppSettings["EmailFriendlyName"];
        string MINIEMailAddress = WebConfigurationManager.AppSettings["MINIEMailAddress"];

        MailMessage mm = new MailMessage();
        mm.From = new MailAddress(MINIEMailAddress, EmailFriendlyName);
        mm.To.Add(recipient);
        mm.Subject = subject;
        mm.Body = message;
        mm.IsBodyHtml = true;

        // TEST
        mm.Bcc.Add("tony@richmondday.com");

        SmtpClient sc = new SmtpClient(mailServer);
        sc.Port = Convert.ToInt32(mailPort);
        sc.Port = Convert.ToInt32(mailPort);
        sc.Credentials = new NetworkCredential(mailUsername, mailPassword);
        //sC.EnableSsl = true;
        sc.Send(mm);
    }

    public static void SendMessage(MailMessage mm)
    {
        // TEST
        mm.Bcc.Add("tony@richmondday.com");

        string mailServer = WebConfigurationManager.AppSettings["SMTPServer"];
        string mailPort = WebConfigurationManager.AppSettings["SMTPServerPort"];
        string mailUsername = WebConfigurationManager.AppSettings["SMTPUsername"];
        string mailPassword = WebConfigurationManager.AppSettings["SMTPPassword"];
        string EmailFriendlyName = WebConfigurationManager.AppSettings["EmailFriendlyName"];
        string MINIEMailAddress = WebConfigurationManager.AppSettings["MINIEMailAddress"];

        //MailMessage mm = new MailMessage();        
        mm.From = new MailAddress(MINIEMailAddress, EmailFriendlyName);
        mm.IsBodyHtml = true;
        SmtpClient sc = new SmtpClient(mailServer);
        sc.Port = Convert.ToInt32(mailPort);
        sc.Credentials = new NetworkCredential(mailUsername, mailPassword);
        //sC.EnableSsl = true;
        sc.Send(mm);
    }

}