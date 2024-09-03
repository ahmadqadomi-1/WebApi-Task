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


            byte[] hash, salt;
            passwordhash.CreatePasswordHash(user.Password, out hash, out salt);

            var user1 = new User
            {
                Username = user.Username,
                Email = user.Email,
                    PasswordHash = hash,

                PasswordSalt = salt
            };

                _db.Users.Add(user1);
                _db.SaveChanges();
                return Ok(user1);

            
        }


        [HttpGet("Login")]
        public IActionResult Login([FromQuery] LoginDTO user)
        {

            var record = _db.Users.FirstOrDefault(u => u.Username == user.Username);

            if (record != null || !passwordhash.VerifyPasswordHash(user.Password, record.PasswordHash, record.PasswordSalt))
            {
                return Ok("login success");
            }
            return Ok("username or password is wrong");

        }
    }
}
