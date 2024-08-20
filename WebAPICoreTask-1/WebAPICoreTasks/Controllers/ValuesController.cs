using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTasks.Models;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ValuesController(MyDbContext db) {
            _db = db;
        
        }
        [HttpGet]
        public IActionResult Get() { 
        var Categories= _db.Categories.select(s => new
        {
            s.CategoryId,
            s.CategoryName,
            s.CategoryImage
        });
            return Ok(Categories);
        }


        [HttpGet("{IDName}")]
        public IActionResult GetById(int id) {
        var Categories = _db.Categories.Find(id);
        return Ok(Categories);
        }

        
    }
}
