using LightpointApp.BusinessLogic.Interfaces;
using LightpointApp.Web.Filters;
using LightpointApp.Web.Mappers;
using LightpointApp.Web.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LightpointApp.Web.Controllers
{
    public class ProductController : ApiController
    {
        private IProductProvider _productProvider;

        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        private static List<ShopModel> Shops = new List<ShopModel>
        {
            new ShopModel { Id = 1, Name = "Shop1", Address = "Address1", OperatingMode = "OperatingMode1" },
            new ShopModel { Id = 2, Name = "Shop2", Address = "Address2", OperatingMode = "OperatingMode2" },
            new ShopModel { Id = 3, Name = "Shop3", Address = "Address3", OperatingMode = "OperatingMode3" },
        };

        private static List<ProductModel> Products = new List<ProductModel>
        {
            new ProductModel { Id = 1, Name = "Product1", Description = "Description1", ShopId = 1 },
            new ProductModel { Id = 2, Name = "Product2", Description = "Description2", ShopId = 1 },
            new ProductModel { Id = 3, Name = "Product3", Description = "Description3", ShopId = 1 },
            new ProductModel { Id = 4, Name = "Product4", Description = "Description4", ShopId = 2 },
            new ProductModel { Id = 5, Name = "Product5", Description = "Description5", ShopId = 2 },
            new ProductModel { Id = 6, Name = "Product6", Description = "Description6", ShopId = 3 },
        };

        public IEnumerable<ProductModel> Get()
        {
            var products = _productProvider.GetAll();

            return ProductMapper.ToViewModel(products);
        }

        public ProductModel Get(int id)
        {
            var product = _productProvider.GetById(id);

            return ProductMapper.ToViewModel(product);
        }

        [Route("api/product/shop/{id}")]
        public IEnumerable<ProductModel> GetByShopId(int id)
        {
            var products = _productProvider.GetByShopId(id);

            return ProductMapper.ToViewModel(products);
        }

        [ValidateModel]
        public void Post(ProductModel product)
        {
            _productProvider.Create(ProductMapper.ToDataModel(product));
        }

        [ValidateModel]
        public void Put(ProductModel product)
        {
            _productProvider.Edit(ProductMapper.ToDataModel(product));
        }

        public void Delete(int id)
        {
            _productProvider.Remove(id);
        }
    }
}
