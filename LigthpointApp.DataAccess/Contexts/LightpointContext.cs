using LightpointApp.DataAccess.Entities;
using LightpointApp.DataAccess.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.DataAccess.Contexts
{
    public class LightpointContext : DbContext
    {
        public LightpointContext()
        {
        }

        public LightpointContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
