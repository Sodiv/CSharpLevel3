using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib.Data
{
    public class People : INotifyPropertyChanged
    {
        private int id;
        private string fullName;
        private string email;
        private string telNumber;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FullName)));
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.email)));
            }
        }

        public string TelNumber
        {
            get => telNumber;
            set
            {
                telNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TelNumber)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
