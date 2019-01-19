using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Application.Products.Dtos;
using Core.Products;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> Get()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _service.GetAsync(id);
            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] ProductDto productDto)
        {
            var product = await _service.InsertAsync(productDto);
            return Ok(product);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] ProductDto productDto)
        {
            var product = await _service.UpdateAsync(productDto, id);
            return Ok(product);
        }
        
    }
}