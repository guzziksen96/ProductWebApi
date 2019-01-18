using Core.Products;
using Infrastructure.EntityFrameworkCore.Repositories.Interfaces;

namespace Infrastructure.EntityFrameworkCore.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

    }
}
