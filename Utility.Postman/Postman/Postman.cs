using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman
{
    public class Postman : IPostman
    {
        private readonly MailMessage _Message = new MailMessage();

        private Postman(string fromEmail)
        {
            _Message.From = new MailAddress(fromEmail);
        }

        public static IPostman EmailFrom(string fromAddress)
        {
            return new Postman(fromAddress);
        }

        public IPostman From(string fromEmail)
        {
            return this;
        }

        public IPostman To(params string[] toEmails)
        {
            foreach (var email in toEmails)
                _Message.To.Add(new MailAddress(email));

            return this;
        }

        public IPostman CC(params string[] ccEmails)
        {
            foreach (var cc in ccEmails)
                _Message.CC.Add(new MailAddress(cc));

            return this;
        }

        public IPostman BCC(params string[] BCCEmails)
        {
            foreach (var bcc in BCCEmails)
                _Message.Bcc.Add(new MailAddress(bcc));

            return this;
        }
        
        public IPostman IsHtml(bool ishtml = true)
        {
            _Message.IsBodyHtml = ishtml;

            return this;
        }

        public IPostman WithSubject(string subject)
        {
            _Message.Subject = subject;

            return this;
        }
        
        public IPostman WithBody(string body)
        {
            _Message.Body = body;

            return this;
        }
        
        public IPostman Attachments(params string[] attachmentsFullPaths)
        {
            foreach (var attach in attachmentsFullPaths)
                _Message.Attachments.Add(new Attachment(attach));
            
            return this;
        }

        public void Deliver()
        {
            try
            {
                // CONFIGURE AS NEEDED.
                SmtpClient smtp = new SmtpClient("YOUR EMAIL DOMAIN");
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;

                smtp.Send(_Message);
            }
            catch
            {
                throw;
            }
        }
    }
}
