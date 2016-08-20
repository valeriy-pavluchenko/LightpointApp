using LightpointApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.BusinessLogic.Interfaces
{
    public interface IProductProvider
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        IEnumerable<Product> GetByShopId(int id);
        void Create(Product product);
        void Edit(Product product);
        void Remove(int id);
    }
}
