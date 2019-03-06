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

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest
    {
        public ProductDto Product { get; set; }

        public CreateProductCommand(ProductDto product)
        {
            this.Product = product;
        }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
        {
            private IProductRepository _repository;
            private readonly IMapper _mapper;
            protected readonly ILogger<CreateProductCommand> _logger;

            public CreateProductCommandHandler(IProductRepository repository, IMapper mapper, ILogger<CreateProductCommand> logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;

            }
            public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product result;
                var product = _mapper.Map<Product>(request.Product);
                try
                {
                    result = await _repository.AddAsync(product);
                    _logger.LogInformation($"New product with name: {product.Name}, cost: {product.Cost}," +
                                           $" and categoryId: {product.Category} was added.");
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
