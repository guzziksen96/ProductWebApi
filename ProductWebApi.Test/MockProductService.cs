using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Products;
using Application.Products.Dtos;
using Core.Products;
using Moq;

namespace ProductWebApi.Test
{
    public class MockProductService : Mock<IProductService>
    {
        private List<ProductDto> _mockedProducts;

        public MockProductService()
        {
            _mockedProducts = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Mock 1",
                    Cost = 10,
                    CategoryId = 1
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Mock 2",
                    Cost = 20,
                    CategoryId = 1
                },
            };
        }

        public MockProductService SetupGetProductById(int id)
        {
            Setup(m => m.GetAsync(It.Is<int>(i => i == id)))
                .Returns(Task.FromResult(_mockedProducts.FirstOrDefault(p => p.Id == id)));

            return this;
        }

        public MockProductService SetupGetAllAsync()
        {
            Setup(m => m.GetAllAsync()).Returns(Task.FromResult<ICollection<ProductDto>>(_mockedProducts));
            return this;
        }

        public MockProductService SetupInsertProduct(ProductDto product)
        {
            Setup(m => m.InsertAsync(It.IsAny<ProductDto>()))
                .Callback<ProductDto>(p => _mockedProducts.Add(p))
                .Returns(Task.FromResult(product));

            return this;
        }

        public MockProductService SetupUpdateProduct(int id, ProductDto product)
        {
            Setup(m => m.UpdateAsync(It.IsAny<ProductDto>(), It.Is<int>(i => i == id)))
                .Callback<ProductDto,int>(UpdateProduct)
                .Returns(Task.FromResult(product));

            return this;
        }

        private void UpdateProduct(ProductDto product, int id)
        {
            var existingProduct = _mockedProducts.First(p => p.Id == id);
            existingProduct.CategoryName = product.CategoryName;
            existingProduct.Cost = product.Cost;
            existingProduct.Name = product.Name;
            existingProduct.CategoryId = product.CategoryId;
        }
    }
}
