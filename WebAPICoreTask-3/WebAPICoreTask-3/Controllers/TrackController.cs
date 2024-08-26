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
        [Route("GetAllTracksForOneRaper/{id}")]
        public IActionResult TT(int id)
        {
            var Ta = _db.Tracks.Where(a => a.RapperId == id).ToList();
            return Ok(Ta);
        }

        [HttpGet ("GetAllTracksDesc")]
        public IActionResult GetSortedTracks()
        {
            var Trackss = _db.Tracks.OrderByDescending(p => p.Duration );
            return Ok(Trackss.ToList());
        }
    }
}
