using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixPack.Apllication;
using SixPack.Domain.Entity;
using SixPack.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace SixPack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdcutController : ControllerBase
    {
        private readonly IProdcutServices _prodcutServices;

        public ProdcutController(IProdcutServices prodcutServices)
        {
            _prodcutServices = prodcutServices;
        }

        [HttpGet("GetProducts", Name = "GetProdcut")]
        public async Task<IActionResult> Get()
        {
            var prdocuts = await _prodcutServices.GetProduct();
            return Ok(prdocuts);
        }

        [HttpGet("GetProdcutById/{id:int}", Name = "GetProdcutById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var prdocuts = await _prodcutServices.GetProductById(id);
            return Ok(prdocuts);
        }

        [HttpPost("InsertProdcut", Name = "InsertProdcut")]
        public async Task<IActionResult> Insert(ProductDto productInsert)
        {
            try
            {
                await _prodcutServices.AddProduct(productInsert);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

    //public class ProductInsert
    //{
    //    public string Title { get; set; }
    //    public string Color { get; set; }
    //    public int Price { get; set; }
    //    public string Desc { get; set; }
    //    public string Slag { get; set; }
    //    public int CategoryID { get; set; }
    //    public List<int>? Images { get; set; }

    //    public Product ToProdcut()
    //    {
    //        var prodcut = new Product()
    //        {
    //            Title = Title,
    //            Color = Color,
    //            Price = Price,
    //            Desc = Desc,
    //            Slag = Slag,
    //            CategoryID = CategoryID,
    //        };
    //        if (Images != null && Images.Count > 0)
    //        {
    //            prodcut.Images = new List<ProdcutImage>();
    //            Images.ForEach(image =>
    //            {
    //                prodcut.Images.Add(new ProdcutImage() { ID = image });
    //            });
    //        }

    //        return prodcut;
    //    }
    //}
}