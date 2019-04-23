using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Data
{
    public class Context : DbContext
    { 
        public Context() : base("DefaultConnection")
        {

        }
        public DbSet<VMDataName.DataUser> DataUsers { get; set; }
        public DbSet<VMDataName.MainSqare> MainSqares { get; set; }
        public DbSet<VMDataName.ItemHeader> ItemsHeader { get; set; }
    }
}
