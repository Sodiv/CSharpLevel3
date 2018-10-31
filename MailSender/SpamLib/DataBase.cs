using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class DataBase
    {
        private readonly RecipientsDataContext _Recipients = new RecipientsDataContext();

        public IQueryable<Recipient> Recipients => _Recipients.Recipient;
    }
}
