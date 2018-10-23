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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        
        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {            
            try
            {
                using(var email = new MailMessage(VariableString.fromEMail, VariableString.toEMail))
                {
                    email.Subject = VariableString.subject;
                    email.Body = VariableString.body;

                    using(var client=new SmtpClient(VariableString.smtpClient))
                    {
                        var user = tb_UserName.Text;
                        var password = pb_Password.SecurePassword;
                        client.Credentials = new NetworkCredential(user, password);
                        client.EnableSsl = true;

                        client.Send(email);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, VariableString.error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var dlg = new SendCompleteDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }
    }
}
