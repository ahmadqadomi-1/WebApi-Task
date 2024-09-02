using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task9.DTOs;
using Task9.Models;

namespace Task9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UserController(MyDbContext db) {
        _db = db;
        }

        [HttpGet]
        [Route("AllUsers/User")]
        public IActionResult Get()
        {
            var data = _db.Users.ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("User/{id}")]
        public IActionResult Get(int id)
        {
            var data = _db.Users.Find(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            var data = _db.Users.FirstOrDefault(c => c.Username == name);
            return Ok(data);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = _db.Users.Find(id);
            _db.Users.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }




        [HttpPost("Register")]
        public IActionResult Register([FromForm] DTOsUser user)
        {

            if (user == null)
            {
                return BadRequest("invalid input");
            }

            if (user.Password != null)
            {

                var user1 = new User
                {
                    Username = user.Username,
                    Password = Hashing(user.Password),
                    Email = user.Email,
                };

                _db.Users.Add(user1);
                _db.SaveChanges();
                return Ok(user1);

            }
            else
            {
                return BadRequest("password cant be null");
            }
        }


        [HttpGet("Login")]
        public IActionResult Login([FromQuery] LoginDTO user)
        {

            if (user == null)
            {

                return BadRequest("input can't be null");

            }

            var record = _db.Users.FirstOrDefault(u => u.Username == user.Username);

            if (record != null && user.Password != null)
            {

                var input_pass = Hashing(user.Password);
                var real_pass = record.Password;

                if (real_pass != input_pass)
                {
                    return BadRequest("uncorrect password");
                }
                else
                {
                    return Ok(record);
                }
            }
            return BadRequest("input is null");

        }
    }
}
