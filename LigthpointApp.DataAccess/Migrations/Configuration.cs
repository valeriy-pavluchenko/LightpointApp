using LightpointApp.DataAccess.Contexts;
using LightpointApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.DataAccess.Migrations
{
    public class Configuration : DbMigrationsConfiguration<LightpointContext>
    {
        public Configuration()
        {
        }

        protected override void Seed(LightpointContext context)
        {
            CreateTestShops(context);
            CreateTestProducts(context);

            base.Seed(context);
        }

        private void CreateTestShops(LightpointContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                context.Shops.Add(new Shop
                {
                    Name = "Shop" + i.ToString(),
                    Address = "Address" + i.ToString(),
                    OperatingMode = "OperatingMode" + i.ToString()
                });
            }

            context.SaveChanges();
        }

        private void CreateTestProducts(LightpointContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                var count = 0;

                for (int j = 1; j <= 10; j++)
                {
                    count++;

                    context.Products.Add(new Product
                    {
                        Name = $"Product{count}",
                        Description = $"Address{count}",
                        ShopId = i
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
