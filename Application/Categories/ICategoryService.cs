using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Categories.Dtos;
using Core.Categories;

namespace Application.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetAsync(int id);
        Task<ICollection<CategoryDto>> GetAllAsync();
    }
}
