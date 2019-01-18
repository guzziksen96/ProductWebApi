using Application.Common;
using Core.Enums;

namespace Application.Products.Dtos
{
    public class ProductDto: IEntityDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public Category Category { get; set; }
        
    }
}
