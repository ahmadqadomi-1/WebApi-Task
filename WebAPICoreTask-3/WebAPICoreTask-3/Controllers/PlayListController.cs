using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_3.DTOs;
using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly MyDbContext _db;
        public PlayListController (MyDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            var data = _db.PlayLists.Select(x => new PlayListRequest
            {
                UserId = x.UserId,

            });    
            return Ok(data);
        }
        [HttpPost]
        public IActionResult add([FromBody] PlayListRequest play)
        {
            var data = new PlayList
            {
                UserId = play.UserId,
                
            };
            _db.PlayLists.Add(data);
            _db.SaveChanges();
            return Ok(data);
        }

    }
}
