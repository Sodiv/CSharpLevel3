using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using MailSenderLib;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EMailSenderClass senderClass = new EMailSenderClass();
        public MainWindow() => InitializeComponent();
        
        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {            
            try
            {
                #region Из Урока
                //using(var email = new MailMessage(VariableString.fromEMail, VariableString.toEMail))
                //{
                //    email.Subject = VariableString.subject;
                //    email.Body = VariableString.body;

                //    using(var client=new SmtpClient(VariableString.smtpClient))
                //    {
                //        var user = tb_UserName.Text;
                //        var password = pb_Password.SecurePassword;
                //        client.Credentials = new NetworkCredential(user, password);
                //        client.EnableSsl = true;

                //        client.Send(email);
                //    }
                //}
                #endregion
                senderClass.SendMessage(VariableString.fromEMail, VariableString.toEMail,
                    VariableString.subject, VariableString.body, VariableString.smtpClient, tb_UserName.Text, pb_Password.Password);
            }
            catch (Exception error)
            {
                ErrorDialog errorDialog = new ErrorDialog(error);
                errorDialog.Owner = this;
                errorDialog.ShowDialog();
                return;
            }

            var dlg = new SendCompleteDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }
    }
}
