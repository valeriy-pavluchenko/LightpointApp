using LightpointApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.BusinessLogic.Interfaces
{
    public interface IShopProvider
    {
        IEnumerable<Shop> GetAll();
        Shop GetById(int id);
        void Create(Shop shop);
        void Edit(Shop shop);
        void Remove(int id);
    }
}
