using EnglishForKidAPI.Constants;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace EnglishForKidAPI.Helper
{
    public class EmailHelper
    {
        SmtpClient smtp = null;
        MailAddress fromAddress = new MailAddress(ApplicationConfig.BossEmail, ApplicationConfig.BossEmailName);
        string fromPassword = ApplicationConfig.BossEmailPassword;
        public EmailHelper()
        {            
            smtp = new SmtpClient
            {
                Host = ApplicationConfig.EmailHost,
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout=15000
            };
        }

        public bool SendEmail(IdentityMessage message, string ccEmail=null)
        {
            try
            {
                MailMessage mailMsg = new MailMessage()
                {
                    Subject = message.Subject,
                    Body = message.Body,
                };
                mailMsg.From = fromAddress;
                mailMsg.To.Add(message.Destination);

                if (ccEmail != null)
                {
                    mailMsg.CC.Add(ccEmail);
                }
                smtp.Send(mailMsg);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}