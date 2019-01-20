using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Categories;
using Core.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Category>>> Get()
        {
            var categories = await _service.GetAllAsync();
            if (categories.Count == 0)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _service.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


    }
}
