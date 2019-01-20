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
        private ProductController _controller;
        private MockProductService _productService;

        public ProductControllerTest()
        {
            _productService = new MockProductService();
            _controller = new ProductController(_productService.Object);
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            _productService.SetupGetAllAsync();

            // Act
            var okResult = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public async void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var unknownProductId = 2000;
            _productService.SetupGetProductById(unknownProductId);

            // Act
            var notFoundResult = await _controller.Get(unknownProductId);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingProductId = 2;
            _productService.SetupGetProductById(existingProductId);
            
            // Act
            var okResult = await _controller.Get(existingProductId);
            
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

        }


        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingProduct = new ProductDto()
            {
                CategoryId = 2,
                Cost = 12.00M
            };
            _productService.SetupInsertProduct(nameMissingProduct);

            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = await _controller.Post(nameMissingProduct);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }


        [Fact]
        public async void Add_ValidObjectPassed_ReturnsOkResult()
        {
            // Arrange
            var product = new ProductDto()
            {
                Name = "Ball",
                CategoryId = 4,
                Cost = 12.00M
            };

            _productService.SetupInsertProduct(product);

            // Act
            var okResult = await _controller.Post(product);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public async void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var productIdToUpdate = 1;
            var productToUpdate = new ProductDto()
            {
                CategoryId = 2,
                Cost = 12.00M
            };
            _productService.SetupUpdateProduct(productIdToUpdate, productToUpdate);

            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = await _controller.Put(productIdToUpdate, productToUpdate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }

        [Fact]
        public async void Update_ValidObjectPassed_ReturnsOkResult()
        {
            // Arrange
            var productIdToUpdate = 1;
            var productToUpdate = new ProductDto()
            {
                Name = "Bicycle",
                CategoryId = 2,
                Cost = 12.00M
            };
            _productService.SetupUpdateProduct(productIdToUpdate, productToUpdate);
           
            // Act
            var okResult = await _controller.Put(productIdToUpdate, productToUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
