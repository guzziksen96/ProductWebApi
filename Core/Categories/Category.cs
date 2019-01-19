using System.Collections.Generic;
using Core.Common;
using Core.Products;

namespace Core.Categories
{
    public class Category : IEntity
    {
        public Category()
        {

        }
        public Category(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

    }
}
