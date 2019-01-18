using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Dtos;
using Core.Products;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> InsertAsync(ProductDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(ProductDto input, int id)
        {
            throw new NotImplementedException();
        }
    }
}
