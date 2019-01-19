using Core.Categories;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;

namespace Infrastructure.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
