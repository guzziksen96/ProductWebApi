using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Dtos;
using Application.Products.Queries;
using Core.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseContoller
    {

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDto>>> Get()
        {
            var products = await Mediator.Send(new ProductsQuery());
            if (products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await Mediator.Send(new ProductQuery(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var product = await Mediator.Send(new CreateProductCommand(productDto));
    
            return Ok(product);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await Mediator.Send(new UpdateProductCommand(productDto, id));
            return Ok(product);
        }
        
    }
}