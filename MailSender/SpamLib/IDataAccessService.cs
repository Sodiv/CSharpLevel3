using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();
        ObservableCollection<Shedule> GetShedules();

        int CreateRecipient(Recipient recipient);
    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
        private RecipientsDataContext _DatabaseContext;
        private ShedulesDataContext _ShedulesDataContext;

        public DataAccessServiceFromDB()
        {
            _DatabaseContext = new RecipientsDataContext();
            _ShedulesDataContext = new ShedulesDataContext();
        }

        public ObservableCollection<Recipient> GetRecipients()
        {
            return new ObservableCollection<Recipient>(_DatabaseContext.Recipient.ToArray());
        }

        public ObservableCollection<Shedule> GetShedules()
        {
            return new ObservableCollection<Shedule>(_ShedulesDataContext.Shedule.ToArray());
        }

        public int CreateRecipient(Recipient recipient)
        {
            _DatabaseContext.Recipient.InsertOnSubmit(recipient);
            _DatabaseContext.SubmitChanges();
            return recipient.Id;
        }
    }
}
