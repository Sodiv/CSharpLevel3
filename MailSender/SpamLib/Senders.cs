using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PasswordLib;

namespace SpamLib
{
    /// <summary>
    /// Список отправителей
    /// </summary>
    public class Senders
    {
        public static ObservableCollection<Sender> Items = new ObservableCollection<Sender>
        {
            new Sender{Name="Ivanov", Email="ivanov@server.org", Password=PasswordEncoder.Encode("Password1")},
            new Sender{Name="Petrov", Email="petrov@server.org", Password=PasswordEncoder.Encode("Password2")},
            new Sender{Name="Sidorov", Email="sidorov@server.org", Password=PasswordEncoder.Encode("Password3")}
        };
        
    }

    

    public class Sender
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
