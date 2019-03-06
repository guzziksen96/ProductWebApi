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
using Microsoft.Extensions.Logging;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public UpdateProductCommand(ProductDto product, int productId)
        {
            this.Product = product;
            this.ProductId = productId;
        }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
        {
            private IProductRepository _repository;
            private readonly IMapper _mapper;
            protected readonly ILogger<UpdateProductCommand> _logger;

            public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper, ILogger<UpdateProductCommand> logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;

            }
            public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {

                var product = _mapper.Map<Product>(request.Product);
                Product result;
                try
                {
                    result = await _repository.UpdateAsync(product, request.ProductId);
                    _logger.LogInformation($"Product with id: {request.ProductId} was updated. Actual cost: {product.Cost}, " +
                                           $"name: {product.Name}, categoryId: {product.Category}");
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }

                return Unit.Value;
                
            }
        }
    }
}
