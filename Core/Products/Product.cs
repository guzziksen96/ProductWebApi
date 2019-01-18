using Core.Common;
using Core.Enums;

namespace Core.Products
{
    public class Product : IEntity
    {
        public Product()
        {
                
        }
        public Product(string name, decimal cost, Category category)
        {
            Name = name;
            Cost = cost;
            Category = category;
        }    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public Category Category { get; set; }
    }
}
