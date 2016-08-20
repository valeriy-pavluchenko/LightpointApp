using LightpointApp.DataAccess.Entities;
using LightpointApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightpointApp.Web.Mappers
{
    public static class ProductMapper
    {
        public static ProductModel ToViewModel(Product item)
        {
            return new ProductModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ShopId = item.ShopId
            };
        }

        public static IEnumerable<ProductModel> ToViewModel(IEnumerable<Product> items)
        {
            foreach (var item in items)
            {
                yield return ProductMapper.ToViewModel(item);
            }
        }

        public static Product ToDataModel(ProductModel item)
        {
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ShopId = item.ShopId
            };
        }

        public static IEnumerable<Product> ToDataModel(IEnumerable<ProductModel> items)
        {
            foreach (var item in items)
            {
                yield return ProductMapper.ToDataModel(item);
            }
        }
    }
}
