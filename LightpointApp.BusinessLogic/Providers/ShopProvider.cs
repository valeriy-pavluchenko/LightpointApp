using LightpointApp.BusinessLogic.Interfaces;
using LightpointApp.DataAccess.Contexts;
using LightpointApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.BusinessLogic.Providers
{
    public class ShopProvider : IShopProvider
    {
        private LightpointContext _context;

        public ShopProvider(LightpointContext context)
        {
            _context = context;
        }

        public IEnumerable<Shop> GetAll()
        {
            return _context.Shops;
        }

        public Shop GetById(int id)
        {
            return _context.Shops.Find(id);
        }

        public void Create(Shop shop)
        {
            _context.Shops.Attach(shop);

            var entry = _context.Entry(shop);
            entry.State = EntityState.Added;

            _context.SaveChanges();
        }

        public void Edit(Shop shop)
        {
            var entry = _context.Entry(shop);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var shop = new Shop { Id = id };

            var entry = _context.Entry(shop);
            entry.State = EntityState.Deleted;

            _context.SaveChanges();
        }
    }
}
