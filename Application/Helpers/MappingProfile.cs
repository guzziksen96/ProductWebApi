using Application.Products.Dtos;
using AutoMapper;
using Core.Products;

namespace Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
      
        }
    }
}
