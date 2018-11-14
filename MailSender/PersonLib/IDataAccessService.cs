using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        Task<int> SavePersonAsync(People people);
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

        public async Task<int> SavePersonAsync(People people)
        {
            using(var db=new PeopleContext())
            {
                db.Peoples.AddOrUpdate(people);
                if (await db.SaveChangesAsync().ConfigureAwait(false) > 0)
                    return people.Id;
            }
            return 0;
        }
    }
}
