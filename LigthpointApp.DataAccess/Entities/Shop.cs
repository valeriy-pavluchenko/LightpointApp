using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.DataAccess.Entities
{
    public class Shop : BaseEntity
    {
        public Shop()
        {
            Products = new List<Product>();
        }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string OperatingMode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
