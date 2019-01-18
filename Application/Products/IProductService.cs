using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Dtos;
using Core.Products;

namespace Application.Products
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> InsertAsync(ProductDto input);
        Task<Product> UpdateAsync(ProductDto input, int id);
    }
}
