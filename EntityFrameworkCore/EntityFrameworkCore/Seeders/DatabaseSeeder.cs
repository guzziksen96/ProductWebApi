using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Core.Categories;
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
            var categories = GetCategories();
            await dataContext.Categories.AddRangeAsync(categories);

            var products = GetProducts();
            await dataContext.Products.AddRangeAsync(products);
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
                new Product("Mi Band 3", 120, 2),
                new Product("Jumping Rope", 20, 4),
                new Product("Black Jacket", 80, 5),
                new Product("TV", 4000, 1),
            };

            return products;
        }

        private List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category("RTV"),
                new Category("AGD"),
                new Category("Entertainment"),
                new Category("Sport"),
                new Category("Fashion")
            };

            return categories;
        }
    }
}
