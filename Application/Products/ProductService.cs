using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Dtos;
using AutoMapper;
using Core.Products;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private readonly IMapper _mapper;
        protected readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, IMapper mapper, ILogger<ProductService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            if (null != logger)
            {
                _logger = logger;
            }
        } 
        public async Task<ProductDto> GetAsync(int id)
        {
            Product result;
            try
            {
                result = await _repository.GetAll()
                    .Include(e => e.Category)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
            var resultDto = _mapper.Map<ProductDto>(result);
            return resultDto;

        }

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            ICollection<Product> result;
            try
            {

                result = await _repository.GetAll()
                    .Include(e => e.Category)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

            var resultDto = _mapper.Map<ICollection<ProductDto>>(result);
            return resultDto;

        }

        public async Task<ProductDto> InsertAsync(ProductDto input)
        {
            Product result;
            var product = _mapper.Map<Product>(input);
            try
            {
                result = await _repository.AddAsync(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
            var resultDto = _mapper.Map<ProductDto>(result);
            return resultDto;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto input, int id)
        {
            var product = _mapper.Map<Product>(input);
            Product result;
            try
            {
                result = await _repository.UpdateAsync(product, id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
            var resultDto = _mapper.Map<ProductDto>(result);
            return resultDto;
        }

    }
}
