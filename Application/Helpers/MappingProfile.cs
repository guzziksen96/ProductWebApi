using Application.Categories.Dtos;
using Application.Products.Dtos;
using AutoMapper;
using Core.Categories;
using Core.Products;

namespace Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.CategoryName, m => m.MapFrom(p => p.Category.Name))
                .ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
