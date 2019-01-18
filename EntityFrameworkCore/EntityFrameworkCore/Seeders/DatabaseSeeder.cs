using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Core.Enums;
using Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFrameworkCore.Seeders
{
    public class DatabaseSeeder
    {
        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
                
                    if (!await dataContext.Products.AnyAsync())
                    {
                        await InsertSampleData(dataContext);
                    }
                
            }
        }

        private async Task InsertSampleData(DataContext dataContext)
        {
            var values = GetProducts();
            await dataContext.Products.AddRangeAsync(values);
            try
            {
                await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product("Mi Band 3", 120, Category.AGD),
            };

            return products;
        }
    }
}
