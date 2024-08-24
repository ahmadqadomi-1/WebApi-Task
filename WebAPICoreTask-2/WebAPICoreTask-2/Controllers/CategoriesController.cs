using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_2.Models;

namespace WebAPICoreTask_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;
        public CategoriesController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route ("get all Categories")]
        public IActionResult Catt ()
        {
            var Cate = _db.Categories.ToList();
            return Ok(Cate);
        }
        [HttpGet]
        [Route ("Get one Category By ID /{id:int:min(5)}")]
        public IActionResult Cat(int id) 
        {
            var SS = _db.Categories.Find();
            return Ok(SS);
        }

        [HttpGet]
        [Route("Get one Category By Name /{name}")]
        public IActionResult Categ(string name)
        {
            var AA = _db.Categories.Where(c => c.CategoryName == name).FirstOrDefault();
            return Ok(AA);
        }
        [HttpDelete]
        [Route("Delete one Category By ID /{id}")]
        public IActionResult Delete(int id) 
        {
            if (id != 0)
            {
                var DD = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
                _db.Categories.Remove(DD);
                _db.SaveChanges();
                return Ok(DD);
            } else
            {
                return BadRequest();
            }
        }
    }
}
