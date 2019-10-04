using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("UserConnection")
        {

        }

        public DbSet<Person> People { get; set; }

    }
}
