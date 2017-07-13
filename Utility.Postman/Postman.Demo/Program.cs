using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman;

namespace Postman.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Postman.EmailFrom("vac@microsoft.com")
                .To("sample@email.com", "sample1@email.com")
                .CC("cc@sample.com")
                .WithSubject("Testing postman on facade")
                .WithBody("<h1>HELLO MUNDO!</h1>")
                .Attachments("C:\\somefile.txt")
                .Deliver();
        }
    }
}
