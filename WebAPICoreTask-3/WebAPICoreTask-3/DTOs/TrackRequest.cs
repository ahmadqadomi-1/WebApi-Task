using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.DTOs
{
    public class TrackRequest
    {
        public string? TrackName { get; set; }

        public string? Description { get; set; }

        public string? Duration { get; set; }

        public int? RapperId { get; set; }

        public IFormFile? TrackImage { get; set; }

    }
}
