using LightpointApp.BusinessLogic.Interfaces;
using LightpointApp.Web.Filters;
using LightpointApp.Web.Mappers;
using LightpointApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace LightpointApp.Web.Controllers
{
    public class ShopController : ApiController
    {
        private ILightpointUnitOfWork _unitOfWork;

        public ShopController(ILightpointUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ShopModel> Get()
        {
            var shops = _unitOfWork.Shops.Get();

            return ShopMapper.ToViewModel(shops);
        }

        public ShopModel Get(int id)
        {
            var shop = _unitOfWork.Shops.GetById(id);

            return ShopMapper.ToViewModel(shop);
        }

        [ValidateModel]
        public void Post(ShopModel shop)
        {
            var shopDataModel = ShopMapper.ToDataModel(shop);

            _unitOfWork.Shops.Insert(shopDataModel);
            _unitOfWork.Save();
        }

        [ValidateModel]
        public void Put(ShopModel shop)
        {
            var shopDataModel = ShopMapper.ToDataModel(shop);

            _unitOfWork.Shops.Update(shopDataModel);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Shops.Delete(id);
            _unitOfWork.Save();
        }
    }
}
