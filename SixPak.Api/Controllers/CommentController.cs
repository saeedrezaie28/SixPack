using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixPack.Domain;
using SixPack.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace SixPack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly SixPackDB sixPackDB;

        public CommentController(SixPackDB sixPackDB)
        {
            this.sixPackDB = sixPackDB;
        }

        [HttpGet(Name = "GetComment")]
        public async Task<IActionResult> Get()
        {
            var prdocuts = await sixPackDB.Comments.ToListAsync();
            return Ok(prdocuts);
        }

        [HttpPost(Name = "InsertComment")]
        public async Task<IActionResult> Insert(CommentInsert commentInsert)
        {
            try
            {
                sixPackDB.Comments.Add(commentInsert.ToComment());
                await sixPackDB.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

    public class CommentInsert
    {
        public string CommentText { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime CreateTime { get; set; }

        public Comment ToComment()
        {
            var comment = new Comment()
            {
                CommentText = CommentText,
                UserID = UserID,
                ProductID = ProductID,
                CreateTime = CreateTime
            };

            return comment;
        }
    }
}