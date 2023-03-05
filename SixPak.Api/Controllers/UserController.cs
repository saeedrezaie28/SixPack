using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixPack.Domain.Entity;
using SixPack.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace SixPack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly SixPackDB sixPackDB;

        public UserController(SixPackDB sixPackDB)
        {
            this.sixPackDB = sixPackDB;
        }

        [HttpGet("GetUser", Name = "GetUser")]
        public async Task<IActionResult> Get()
        {
            var prdocuts = await sixPackDB.Users.ToListAsync();
            return Ok(prdocuts);
        }

        [HttpPost("InsertUser", Name = "InsertUser")]
        public async Task<IActionResult> Insert(UserInsert userInsert)
        {
            try
            {
                sixPackDB.Users.Add(userInsert.ToUser());
                await sixPackDB.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

    public class UserInsert
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }

        public User ToUser()
        {
            var user = new User()
            {
                Name = Name,
                LastName = LastName,
                Mobile = Mobile
            };

            return user;
        }
    }
}