using System.ComponentModel.DataAnnotations;

namespace Task9.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please Enter UserName")] // ErrorMessage that show or we can see in front-end not for back-end  
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
