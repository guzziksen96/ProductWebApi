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
    public class CategoriesQuery : IRequest<List<CategoryDto>>
    {
        public class CategoriesQueryHandler : IRequestHandler<CategoriesQuery, List<CategoryDto>>
        {
            private ICategoryRepository _repository;
            private readonly IMapper _mapper;
            protected readonly ILogger<CategoriesQuery> _logger;

            public CategoriesQueryHandler(ICategoryRepository repository, IMapper mapper, ILogger<CategoriesQuery> logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;

            }

            public async Task<List<CategoryDto>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
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
                return resultDto.ToList();
            }
        }
    }
}
