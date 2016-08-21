using LightpointApp.BusinessLogic.Interfaces;
using LightpointApp.BusinessLogic.Repositories;
using LightpointApp.DataAccess.Contexts;
using LightpointApp.DataAccess.Entities;
using System;

namespace LightpointApp.BusinessLogic.UnitOfWork
{
    public class LightpointUnitOfWork : ILightpointUnitOfWork, IDisposable
    {
        private LightpointContext _context;
        private IRepository<Shop> _shops;
        private IRepository<Product> _products;

        public LightpointUnitOfWork(LightpointContext context)
        {
            _context = context;
        }

        public IRepository<Shop> Shops
        { 
            get
            {
                if (_shops == null)
                {
                    _shops = new Repository<Shop>(_context);
                }

                return _shops;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new Repository<Product>(_context);
                }

                return _products;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
