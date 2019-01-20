using System.ComponentModel.DataAnnotations;
using Application.Common;

namespace Application.Categories.Dtos
{
    public class CategoryDto : IEntityDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
