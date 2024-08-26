using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.DTOs
{
    public class RapperRequest
    {
        public string? RapperName { get; set; }

        public IFormFile? RapperImage { get; set; }
    }
}
