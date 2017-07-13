using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman
{
    public interface IPostman
    {
        IPostman From(string fromEmail);
        IPostman To(params string[] toEmails);
        IPostman CC(params string[] ccEmails);
        IPostman BCC(params string[] BCCEmails);
        IPostman WithSubject(string subject);
        IPostman WithBody(string body);
        IPostman IsHtml(bool ishtml = true);
        IPostman Attachments(params string[] attachmentsFullPaths);

        void Deliver();
    }
}
