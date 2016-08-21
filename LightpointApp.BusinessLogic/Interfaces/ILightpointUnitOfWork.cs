using LightpointApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.BusinessLogic.Interfaces
{
    public interface ILightpointUnitOfWork
    {
        IRepository<Shop> Shops { get; }
        IRepository<Product> Products { get; }

        void Save();
    }
}
