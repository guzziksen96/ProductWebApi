using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Categories.Dtos;
using AutoMapper;
using Core.Categories;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;

namespace Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            var resultDto = _mapper.Map<CategoryDto>(result);
            return resultDto;

        }

        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var resultDto = _mapper.Map<ICollection<CategoryDto>>(result);
            return resultDto;
            

        }

    }
}
