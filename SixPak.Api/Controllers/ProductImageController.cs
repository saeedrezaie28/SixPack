using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixPack.Domain.Entity;
using SixPack.Infrastructure;

namespace SixPack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly SixPackDB sixPackDB;

        public ProductImageController(SixPackDB sixPackDB)
        {
            this.sixPackDB = sixPackDB;
        }

        [HttpGet("GetProdcutImage", Name = "GetProdcutImage")]
        public async Task<IActionResult> Get(long prodcutId)
        {
            var prdocuts = await sixPackDB.ProdcutImages.Where(a => a.ProductID == prodcutId).ToListAsync();
            return Ok(prdocuts);
        }

        [HttpPost("InsertProdcutImage", Name = "InsertProdcutImage")]
        public async Task<IActionResult> Insert(ProdcutImageInsert prodcutImageInsert)
        {
            try
            {
                sixPackDB.ProdcutImages.Add(prodcutImageInsert.ToProdcutImage());
                await sixPackDB.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

    public class ProdcutImageInsert
    {
        public string DownloadPath { get; set; }
        public bool IsDefault { get; set; }
        public int ProductID { get; set; }

        public ProdcutImage ToProdcutImage()
        {
            var prodcutImage = new ProdcutImage()
            {
                DownloadPath = DownloadPath,
                ProductID = ProductID
            };

            return prodcutImage;
        }
    }
}
