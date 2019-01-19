using Application.Categories.Dtos;
using Application.Common;

namespace Application.Products.Dtos
{
    public class ProductDto: IEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string CategoryName { get; set; }        
        public int CategoryId { get; set; }


    }
}
