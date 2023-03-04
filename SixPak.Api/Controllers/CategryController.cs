using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixPack.Domain;
using SixPack.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace SixPack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly SixPackDB sixPackDB;

        public CategoryController(SixPackDB sixPackDB)
        {
            this.sixPackDB = sixPackDB;
        }

        [HttpGet(Name = "GetCategory")]
        public async Task<IActionResult> Get()
        {
            var prdocuts = await sixPackDB.Categries.ToListAsync();
            return Ok(prdocuts);
        }

        [HttpPost(Name = "InsertCategory")]
        public async Task<IActionResult> Insert(CategoryInsert productInsert)
        {
            try
            {
                sixPackDB.Categries.Add(productInsert.ToCategory());
                await sixPackDB.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

    public class CategoryInsert
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Category ToCategory()
        {
            var Category = new Category()
            {
                Title = Title,
                Description = Description
            };

            return Category;
        }
    }
}