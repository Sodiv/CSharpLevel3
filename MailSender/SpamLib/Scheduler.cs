using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using MailSenderLib;
using System.Collections.ObjectModel;
using System.Windows;

namespace SpamLib
{
    public class Scheduler
    {
        DispatcherTimer timer = new DispatcherTimer();
        EmailSendService emailSender;
        DateTime dtSend;
        ObservableCollection<Recipient> recipients;

        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }
            return tsSendTime;
        }

        public void SendEmails(DateTime dtSend, EmailSendService emailSender, ObservableCollection<Recipient> recipients)
        {
            this.emailSender = emailSender;
            this.dtSend = dtSend;
            this.recipients = recipients;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                foreach(var recipient in recipients)
                {
                    emailSender.SendMail(recipient.Email, recipient.Name);
                }
                timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
        }
    }
}
