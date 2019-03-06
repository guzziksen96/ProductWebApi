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
    public class ProductQuery : IRequest<ProductDto> 
    {
        public ProductQuery(int productId)
        {
            this.ProductId = productId;
        }

        public int ProductId { get; set; }

        public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductDto>
        {
            private IProductRepository _repository;
            private readonly IMapper _mapper;
            protected readonly ILogger<ProductQueryHandler> _logger;

            public ProductQueryHandler(IProductRepository repository, IMapper mapper, ILogger<ProductQueryHandler> logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;
                
            }
            public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
            {
                Product result;
                try
                {
                    result = await _repository.GetAll()
                        .Include(e => e.Category)
                        .FirstOrDefaultAsync(p => p.Id == request.ProductId);
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
    
}
