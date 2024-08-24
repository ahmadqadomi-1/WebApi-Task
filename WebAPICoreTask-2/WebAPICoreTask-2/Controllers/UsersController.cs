using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_2.Models;

namespace WebAPICoreTask_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UsersController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("get all Users")]
        public IActionResult Us()
        {
            var Uss = _db.Users.ToList();
            return Ok(Uss);
        }

        // error

        [HttpGet]
        [Route("Get one User By ID /{id}")]
        public IActionResult Use(int id)
        {
            var Usee = _db.Users.Find();
            return Ok(Usee);
        }

        [HttpGet]
        [Route("Get one User By Name /{name}")]
        public IActionResult User(string name)
        {
            var Userr = _db.Users.Where(c => c.Username == name).FirstOrDefault();
            return Ok(Userr);
        }

        //Error Maybe  Of The Relation
        //[HttpDelete]
        //[Route("Delete one User By ID /{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (id != 0)
        //    {
        //        var bb = _db.Users.FirstOrDefault(c => c.UserId == id);
        //        _db.Categories.Remove(bb);
        //        _db.SaveChanges();
        //        return Ok(bb);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
