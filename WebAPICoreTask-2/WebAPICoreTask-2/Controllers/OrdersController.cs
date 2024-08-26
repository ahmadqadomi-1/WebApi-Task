using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICoreTask_2.Models;

namespace WebAPICoreTask_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyDbContext _db;
        public OrdersController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet("get all Orders")]
        public IActionResult Prod()
        {
            var Pro = _db.Orders.ToList();
            return Ok(Pro);
        }
        [HttpGet("Get one Order By ID /{id}")]
        public IActionResult Ord([FromQuery] int id)
        {
            var OO = _db.Orders.Where(p => p.OrderId == id);
            return Ok(OO);
        }
        //Maybe not true
        [HttpGet("Get one Orders By Name")]
        public IActionResult Order3(string name)
        {
            var OOO = _db.Orders.Where(o => o.OrderName == name).ToList();
            return Ok(OOO);
        }

        //Error Maybe  Of The Relation

        [HttpDelete("Delete one Order By ID")]
        public IActionResult Delete(int id)
        {


           
              
            if (id != 0)
            {
                var OoO = _db.Orders.Include(a => a.User).FirstOrDefault(o => o.OrderId == id);
                _db.Orders.Remove(OoO);
                _db.SaveChanges();
                return Ok(OoO);
            }
            return Ok();
        }
    }
}
