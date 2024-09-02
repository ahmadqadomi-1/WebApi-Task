using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.DTOs
{
    public class PlayListTracksRequest
    {
        public int? PlayListId { get; set; }

        public int? TrackId { get; set; }

        public int Quantity { get; set; }
        public TrackRequest TrackRequest { get; set; }
    }
}
