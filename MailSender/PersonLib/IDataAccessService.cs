using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib.Data;

namespace PersonLib
{
    public interface IDataService
    {
        ObservableCollection<People> GetPersons();
        Task<ObservableCollection<People>> GetPersonsAsync();
    }

    public class DataAccessServiceFromDB : IDataService
    {
        public ObservableCollection<People> GetPersons()
        {
            using (var db = new PeopleContext())
                return new ObservableCollection<People>(db.Peoples.ToArray());
        }

        public async Task<ObservableCollection<People>> GetPersonsAsync()
        {
            using (var db = new PeopleContext())
                return new ObservableCollection<People>(await db.Peoples.ToArrayAsync());
        }
    }
}
