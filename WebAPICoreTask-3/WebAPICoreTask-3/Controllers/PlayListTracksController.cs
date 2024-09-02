using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_3.DTOs;
using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListTracksController : ControllerBase
    {
        private readonly MyDbContext _db;
        public PlayListTracksController (MyDbContext db)
        {
            _db = db;
        }
        [HttpGet ("PlayList")]
        public IActionResult GetListTrack()
        {
            var ListTrack = _db.PlayListTracks.Select(x => new PlayListTracksRequest
            {
                PlayListId = x.PlayListId,
                TrackId = x.TrackId,
                Quantity = x.Quantity,
                TrackRequest = new TrackRequest
                {
                    TrackName = x.Track.TrackName,
                    Description = x.Track.Description,
                    Duration = x.Track.Duration,
                    RapperId = x.Track.RapperId
                }
            }
            ).ToList();
            return Ok(ListTrack);
        }

        [HttpGet("GetTrack/{id}")]
        public IActionResult GetTrack(int id)
        {
            var track = _db.PlayListTracks.Find(id);
            return Ok(track);
        }


        [HttpPost("Post/Your/Data")]
        public IActionResult AddTrack([FromBody] AddTrackToList play)
        {
            var deta = new PlayListTrack
            {
                PlayListId = play.PlayListId,
                TrackId = play.TrackId,
                Quantity= play.Quantity,
            };
            _db.PlayListTracks.Add(deta);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("EditQuantity/{id}")]
        public IActionResult EditQua(int id, [FromBody] AddTrackToList Added) {
            var data =  _db.PlayListTracks.Find(id);
            data.Quantity = Added.Quantity;
            _db.PlayListTracks.Update(data);
            _db.SaveChanges();
            return Ok();

        }
    }
}
