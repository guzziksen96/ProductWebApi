using System;
using System.Collections.Generic;
using System.Text;
using Application.Products;
using Core.Products;
using Moq;

namespace ProductWebApi.Test
{
    public class MockProductService : Mock<IProductService>
    {
            public void MockGetProductById(int id, Product output)
            {
                //Setup(x => x.GetAsync(
                //    It.Is<int>(i => i == id),
            
                //)).Returns(output);
            }
        
    }
}
