using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RapperController : ControllerBase
    {
        private readonly MyDbContext _db;
        public RapperController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetAllRappers")]
        public IActionResult Rap()
        {
            var Rapp = _db.Rappers.ToList();
            return Ok(Rapp);
        }

        [HttpGet("GetOneRapperByID /{id}")]
        
        public IActionResult RR(int id)
        {
            var Ra = _db.Rappers.Find(id);
            return Ok(Ra);
        }
    }
}
