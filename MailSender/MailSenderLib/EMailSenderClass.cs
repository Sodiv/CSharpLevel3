using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSenderLib
{
    public class EMailSenderClass
    {
        /// <summary>
        /// Отправка письма
        /// </summary>
        /// <param name="fromEmail">От кого</param>
        /// <param name="toEmail">Кому</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="body">Тело письма</param>
        /// <param name="smtpClient">Адрес почтового сервера</param>
        /// <param name="user">Пользователь</param>
        /// <param name="password">Пароль</param>
        public void SendMessage(string fromEmail, string toEmail, string subject, string body, string smtpClient, string  user, string password)
        {
            using(var email =new MailMessage(fromEmail, toEmail))
            {
                email.Subject = subject;
                email.Body = body;

                using(var client=new SmtpClient(smtpClient))
                {
                    client.Credentials = new NetworkCredential(user, password);
                    client.EnableSsl = true;

                    client.Send(email);
                }
            }
        }
    }
}
