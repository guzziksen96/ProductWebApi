using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Dtos;
using Core.Products;

namespace Application.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetAsync(int id);
        Task<ICollection<ProductDto>> GetAllAsync();
        Task<ProductDto> InsertAsync(ProductDto input);
        Task<ProductDto> UpdateAsync(ProductDto input, int id);
    }
}
