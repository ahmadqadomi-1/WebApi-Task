using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly MyDbContext _db;
        public TrackController (MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetAllTracks")]
        public IActionResult Trackk()
        {
            var tra = _db.Tracks.ToList(); 
            return Ok(tra);
        }

        [HttpGet]
        [Route("GetOneTrackByID /{id}")]
        public IActionResult TT(int id)
        {
            var Ta = _db.Tracks.Find(id);
            return Ok(Ta);
        }

    }
}
