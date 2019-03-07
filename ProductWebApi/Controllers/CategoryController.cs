using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Categories;
using Application.Categories.Queries;
using Core.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseContoller
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<Category>>> Get()
        {
            var categories = await Mediator.Send(new CategoriesQuery());
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
            var category = await Mediator.Send(new CategoryQuery(id));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


    }
}
