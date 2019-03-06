using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Products.Dtos;
using AutoMapper;
using Core.Products;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Products.Queries
{
    public class ProductsQuery : IRequest<List<ProductDto>>
    {
        public class ProductsQueryHandler : IRequestHandler<ProductsQuery, List<ProductDto>>
        {
            private IProductRepository _repository;
            private readonly IMapper _mapper;
            protected readonly ILogger<ProductsQueryHandler> _logger;

            public ProductsQueryHandler(IProductRepository repository, IMapper mapper, ILogger<ProductsQueryHandler> logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;

            }

            public async Task<List<ProductDto>> Handle(ProductsQuery request, CancellationToken cancellationToken)
            {
                ICollection<Product> result;
                try
                {

                    result = await _repository.GetAll()
                        .Include(e => e.Category)
                        .ToListAsync();
                    _logger.LogInformation($"Returning {result.Count} products.");
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }

                var resultDto = _mapper.Map<ICollection<ProductDto>>(result);
                return resultDto.ToList();
            }
        }
    }
}
