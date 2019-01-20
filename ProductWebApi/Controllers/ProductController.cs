using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products;
using Application.Products.Dtos;
using Core.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _service;
        protected readonly ILogger<ProductController> _logger;
        public ProductController(IProductService service, ILogger<ProductController> logger = null)
        {
            _service = service;
            if (null != logger)
            {
                _logger = logger;
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDto>>> Get()
        {
            var products = await _service.GetAllAsync();
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
            var product = await _service.GetAsync(id);
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

            var product = await _service.InsertAsync(productDto);
    
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
            var product = await _service.UpdateAsync(productDto, id);
            return Ok(product);
        }
        
    }
}