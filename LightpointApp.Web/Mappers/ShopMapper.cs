using LightpointApp.DataAccess.Entities;
using LightpointApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightpointApp.Web.Mappers
{
    public static class ShopMapper
    {
        public static ShopModel ToViewModel(Shop item)
        {
            return new ShopModel
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                OperatingMode = item.OperatingMode
            };
        }

        public static IEnumerable<ShopModel> ToViewModel(IEnumerable<Shop> items)
        {
            foreach (var item in items)
            {
                yield return ShopMapper.ToViewModel(item);
            }
        }

        public static Shop ToDataModel(ShopModel item)
        {
            return new Shop
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                OperatingMode = item.OperatingMode
            };
        }

        public static IEnumerable<Shop> ToDataModel(IEnumerable<ShopModel> items)
        {
            foreach (var item in items)
            {
                yield return ShopMapper.ToDataModel(item);
            }
        }
    }
}
