using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Dtos;
using AutoMapper;
using Core.Products;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        } 
        public async Task<ProductDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            var resultDto = _mapper.Map<ProductDto>(result);
            return resultDto;

        }

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var resultDto = _mapper.Map<ICollection<ProductDto>>(result);
            return resultDto;

        }

        public async Task<ProductDto> InsertAsync(ProductDto input)
        {
            var product = _mapper.Map<Product>(input);
            var result = await _repository.AddAsync(product);
            var resultDto = _mapper.Map<ProductDto>(result);
            return resultDto;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto input, int id)
        {
            var product = _mapper.Map<Product>(input);
            var result = await _repository.UpdateAsync(product, id);
            var resultDto = _mapper.Map<ProductDto>(result);
            return resultDto;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
