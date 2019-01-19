using Core.Categories;
using Core.Common;

namespace Core.Products
{
    public class Product : IEntity
    {
        public Product()
        {
                
        }
        public Product(string name, decimal cost, int categoryId)
        {
            Name = name;
            Cost = cost;
            CategoryId = categoryId;
        }    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
