using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    public class EmailSendService
    {
        private string _Login;
        private string _Password;

        private string _ServerAddress { get; set; }
        private int _Port { get; set; }

        private string _Body;
        private string _Subject;

        public EmailSendService(string Login, string Password)
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
                    Subject = _Subject,
                    Body = _Body,
                    IsBodyHtml = false
                })
                {
                    using (var client = new SmtpClient(_ServerAddress, _Port)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(_Login, _Password)
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
