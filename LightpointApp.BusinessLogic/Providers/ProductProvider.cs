using LightpointApp.BusinessLogic.Interfaces;
using LightpointApp.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightpointApp.DataAccess.Entities;
using System.Data.Entity;

namespace LightpointApp.BusinessLogic.Providers
{
    public class ProductProvider : IProductProvider
    {
        private LightpointContext _context;

        public ProductProvider(LightpointContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetByShopId(int id)
        {
            return _context.Products.Where(p => p.ShopId == id);
        }

        public void Create(Product product)
        {
            _context.Products.Attach(product);

            var entry = _context.Entry(product);
            entry.State = EntityState.Added;

            _context.SaveChanges();
        }

        public void Edit(Product product)
        {
            var entry = _context.Entry(product);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var product = new Product { Id = id };

            var entry = _context.Entry(product);
            entry.State = EntityState.Deleted;

            _context.SaveChanges();
        }
    }
}
