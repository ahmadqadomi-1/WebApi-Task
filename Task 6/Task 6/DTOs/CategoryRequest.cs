using Task_6.Models;

namespace Task_6.DTOs
{
    public class CategoryRequest
    {
        public string? CategoryName { get; set; }

        public IFormFile? CategoryImage { get; set; }
    }
}
