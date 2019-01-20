using System;
using System.Collections.Generic;
using System.Text;
using Application.Products;
using Application.Products.Dtos;
using Core.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductWebApi.Controllers;
using Xunit;

namespace ProductWebApi.Test
{
    public class ProductControllerTest
    {
        ProductController _controller;

        public ProductControllerTest()
        {
            var mockProductService = new Mock<IProductService>();
            
            _controller = new ProductController(mockProductService.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(2000);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(2);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }


        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new ProductDto()
            {
                CategoryId = 2,
                Cost = 12.00M
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testItem = new ProductDto()
            {
                Name = "Ball",
                CategoryId = 4,
                Cost = 23
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        

    }
}
