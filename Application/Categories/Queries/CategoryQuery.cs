using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Dtos;
using AutoMapper;
using Core.Categories;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Categories.Queries
{
    public class CategoryQuery : IRequest<CategoryDto>
    {
        public CategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }

        public class CategoryQueryHandler : IRequestHandler<CategoryQuery, CategoryDto>
        {
            private ICategoryRepository _repository;
            private readonly IMapper _mapper;
            protected readonly ILogger<CategoryQuery> _logger;

            public CategoryQueryHandler(ICategoryRepository repository, IMapper mapper, ILogger<CategoryQuery> logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;

            }
            public async Task<CategoryDto> Handle(CategoryQuery request, CancellationToken cancellationToken)
            {
                Category result;
                try
                {
                    result = await _repository.GetAsync(request.CategoryId);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
                var resultDto = _mapper.Map<CategoryDto>(result);
                return resultDto;
            }
        }
    }
}
