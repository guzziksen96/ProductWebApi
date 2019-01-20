using System.ComponentModel.DataAnnotations;
using Application.Categories.Dtos;
using Application.Common;

namespace Application.Products.Dtos
{
    public class ProductDto: IEntityDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public int CategoryId { get; set; }


    }
}
