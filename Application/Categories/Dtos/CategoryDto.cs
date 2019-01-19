using Application.Common;

namespace Application.Categories.Dtos
{
    public class CategoryDto : IEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
