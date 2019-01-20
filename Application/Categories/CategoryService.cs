using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Categories.Dtos;
using AutoMapper;
using Core.Categories;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;
        private readonly IMapper _mapper;
        protected readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repository, IMapper mapper, ILogger<CategoryService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            if (null != logger)
            {
                _logger = logger;
            }
        }
        public async Task<CategoryDto> GetAsync(int id)
        {
            Category result;
            try
            {
                result = await _repository.GetAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            var resultDto = _mapper.Map<CategoryDto>(result);
            return resultDto;

        }

        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            ICollection<Category> result;
            try
            {
                result = await _repository.GetAllAsync();
                _logger.LogInformation($"Returning {result.Count} categories.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            var resultDto = _mapper.Map<ICollection<CategoryDto>>(result);
            return resultDto;
            

        }

    }
}
