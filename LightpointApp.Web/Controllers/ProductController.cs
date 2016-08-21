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
        private ILightpointUnitOfWork _unitOfWork;

        public ProductController(ILightpointUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductModel> Get()
        {
            var products = _unitOfWork.Products.Get();

            return ProductMapper.ToViewModel(products);
        }

        public ProductModel Get(int id)
        {
            var product = _unitOfWork.Products.GetById(id);

            return ProductMapper.ToViewModel(product);
        }

        [Route("api/product/shop/{id}")]
        public IEnumerable<ProductModel> GetByShopId(int id)
        {
            var products = _unitOfWork.Products.Get(p => p.ShopId == id);

            return ProductMapper.ToViewModel(products);
        }

        [ValidateModel]
        public void Post(ProductModel product)
        {
            var productDataModel = ProductMapper.ToDataModel(product);

            _unitOfWork.Products.Insert(productDataModel);
            _unitOfWork.Save();
        }

        [ValidateModel]
        public void Put(ProductModel product)
        {
            var productDataModel = ProductMapper.ToDataModel(product);

            _unitOfWork.Products.Update(productDataModel);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Save();
        }
    }
}
