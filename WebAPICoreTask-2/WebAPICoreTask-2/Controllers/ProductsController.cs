using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_2.Models;

namespace WebAPICoreTask_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductsController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet("get all Product")]
        public IActionResult Prod()
        {
            var Pro = _db.Products.ToList();
            return Ok(Pro);
        }
        [HttpGet("Get one Product By ID /{id}")]
        public IActionResult Prod([FromQuery] int id, string name )
        {
            var SS = _db.Products.Where(p=> p.ProductId == id && p.ProductName == name);
            return Ok(SS);
        }
        //Maybe fail
        [HttpGet("Get one Products By Name /{id:int:max(5)}")]
        public IActionResult Categ(string name)
        {
            var AA = _db.Products.Where(c => c.ProductName == name).ToList();
            return Ok(AA);
        }

        [HttpDelete("Delete one Product By ID")] 
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var PP = _db.Products.FirstOrDefault(c => c.ProductId == id);
                _db.Products.Remove(PP);
                _db.SaveChanges();
                return Ok(PP);
            }
                return Ok();  
        }
    }
}
