using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;
using System.ServiceModel;
using Server.Exceptions;

namespace Server.Shared
{
    public class Mail
    {
        private static SmtpClient smtp = null;
        public static void SendEmail(string emailTo, string nameTo, string subject, string body, bool isHTML = false)
        {
            if (Mail.smtp == null)
            {
                Mail.CreateSMTPClient();
            }

            MailMessage mail = new MailMessage();
            
            try
            {
                mail.From = new MailAddress("tdin@fe.up.pt", "TDIN Mail Account");
                mail.To.Add(new MailAddress(emailTo, nameTo));
                mail.Subject = subject;

                mail.IsBodyHtml = isHTML;
                mail.Body = body;

                smtp.SendAsync(mail, (object)mail);
            }
            catch
            {

            }

        }

        internal static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
            if (e.Error == null)
            {
                Console.WriteLine("[Mail] Email successfully sended!");
            }
            else
            {
                Console.WriteLine("[Mail] Error while sending email...");
                throw e.Error;
            }
        }

        internal static void CreateSMTPClient()
        {
            //Use if inside FEUPNet
            smtp = new SmtpClient("smtp.fe.up.pt", 25);
            
            //Use if outside FEUPNet
            //smtp = new SmtpClient("mail.jpsfs.com", 25);
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("feup@jpsfs.com", "poiuytrewq0987654321");
                
            smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
        }
    }

    
}
