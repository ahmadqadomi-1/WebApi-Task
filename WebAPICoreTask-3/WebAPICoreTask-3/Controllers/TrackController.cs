using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_3.DTOs;
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
        [HttpPost]
        public IActionResult AddTrack([FromForm] TrackRequest track)
        {
            var data = new Track
            {
                TrackName = track.TrackName,
                Description = track.Description,
                Duration = track.Duration,
                RapperId = track.RapperId,
                TrackImage = track.TrackImage.FileName
            };
            var ImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uplode");
            if (!Directory.Exists(ImageFolder))
            {
                Directory.CreateDirectory(ImageFolder);
            }
            var ImageFile = Path.Combine("Uplode", track.TrackImage.FileName);
            using (var stream = new FileStream (ImageFile, FileMode.Create))
            {
                track.TrackImage.CopyToAsync(stream);
            }
            _db.Tracks.Add(data);
            _db.SaveChanges();
            return Ok();

        }
        [HttpPut("UpdateTheTrackByID/{id}")]
        public IActionResult UpdateTracks(int id,[FromForm] TrackRequest track) 
        {
            var uptrack = _db.Tracks.FirstOrDefault(t=> t.TrackId == id);
            uptrack.TrackName = track.TrackName;
            uptrack.Description = track.Description;
            uptrack.Duration = track.Duration;
            uptrack.RapperId = track.RapperId;
            uptrack.TrackImage = track.TrackImage.FileName;

            _db.Tracks.Update(uptrack);
            _db.SaveChanges();
            return Ok();
        }
    }
}
