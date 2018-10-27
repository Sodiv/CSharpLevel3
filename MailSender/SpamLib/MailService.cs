using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace SpamLib
{
    public class MailService
    {
        private string _Login;
        private string _Password;

        public static Server server;

        private string _ServerAddress = server.Address;
        private int _Port = server.Port;

        private string _Body;
        private string _Subject;

        public MailService(string Login, string Password)
        {
            _Login = Login;
            _Password = Password;
        }

        public void SendMail(string Mail, string Name)
        {
            try
            {
                using (var message = new MailMessage(_Login, Mail)
                {
                    Subject=_Subject,
                    Body=_Body,
                    IsBodyHtml=false
                })
                {
                    using(var client=new SmtpClient(_ServerAddress, _Port)
                    {
                        EnableSsl=true,
                        Credentials=new NetworkCredential(_Login, _Password)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                throw new InvalidOperationException("Ошибка отправки почты", e);

            }
        }
    }
}
