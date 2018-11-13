using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib.Data
{
    class PeopleContext : DbContext
    {
        public PeopleContext() : base("name=DbConnection") { }

        public virtual DbSet<People> Peoples { get; set; }
    }
}
