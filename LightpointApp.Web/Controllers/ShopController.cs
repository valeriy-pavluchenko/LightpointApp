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
using System.Threading.Tasks;
using System.Web.Http;

namespace LightpointApp.Web.Controllers
{
    public class ShopController : ApiController
    {
        private IShopProvider _shopProvider;

        public ShopController(IShopProvider shopProvider)
        {
            _shopProvider = shopProvider;
        }

        private static List<ShopModel> Shops = new List<ShopModel>
        {
            new ShopModel { Id = 1, Name = "Shop1", Address = "Address1", OperatingMode = "OperatingMode1" },
            new ShopModel { Id = 2, Name = "Shop2", Address = "Address2", OperatingMode = "OperatingMode2" },
            new ShopModel { Id = 3, Name = "Shop3", Address = "Address3", OperatingMode = "OperatingMode3" },
        };

        public IEnumerable<ShopModel> Get()
        {
            var shops = _shopProvider.GetAll();

            return ShopMapper.ToViewModel(shops);
        }

        public ShopModel Get(int id)
        {
            var shop = _shopProvider.GetById(id);

            return ShopMapper.ToViewModel(shop);
        }

        [ValidateModel]
        public void Post(ShopModel shop)
        {
            _shopProvider.Create(ShopMapper.ToDataModel(shop));
        }

        [ValidateModel]
        public void Put(ShopModel shop)
        {
            _shopProvider.Edit(ShopMapper.ToDataModel(shop));
        }

        public void Delete(int id)
        {
            _shopProvider.Remove(id);
        }
    }
}
