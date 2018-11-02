using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SpamLib
{
    /// <summary>
    /// Список smtp-серверов
    /// </summary>
    public class Servers
    {
        public static ObservableCollection<Server> Items = new ObservableCollection<Server>
        {
            new Server{Name="Mail.Ru", Address="smtp.mail.ru", Port=465},
            new Server{Name="Yandex.Ru", Address="smtp.yandex.ru", Port=25}
        };
    }
    
    public class Server
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
