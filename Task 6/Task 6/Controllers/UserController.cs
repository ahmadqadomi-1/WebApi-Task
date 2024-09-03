using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Task_6.DTOs;
using Task_6.Models;

namespace Task_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly TokenGenerator _tokenGenerator;
        public UserController(MyDbContext db, TokenGenerator tokenGenerator)
        {
            _db = db;
            _tokenGenerator = tokenGenerator;
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
            if (data == null)
            {
                return NotFound(); // إضافة التعامل مع حالة عدم العثور على المستخدم
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            var data = _db.Users.FirstOrDefault(c => c.Username == name);
            if (data == null)
            {
                return NotFound(); // إضافة التعامل مع حالة عدم العثور على المستخدم
            }
            return Ok(data);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = _db.Users.Find(id);
            if (data == null)
            {
                return NotFound(); // إضافة التعامل مع حالة عدم العثور على المستخدم
            }
            _db.Users.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] DTOsUser user)
        {
            if (user == null)
            {
                return BadRequest("User data is null"); // التعامل مع حالة البيانات الفارغة
            }

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

        [HttpPost("Login")]
        public IActionResult Login([FromBody] DTOsUser user)
        {
            if (user == null)
            {
                return BadRequest("User data is null"); 
            }

            var use = _db.Users.FirstOrDefault(u => u.Username == user.Username);
            if (use == null || !passwordhash.VerifyPasswordHash(user.Password, use.PasswordHash, use.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            var roles = _db.UserRoles.Where(x => x.UserId == use.UserId).Select(ur => ur.Role).ToList();
            var token = _tokenGenerator.GenerateToken(user.Username, roles);

            return Ok(new { Token = token , use.UserId });
        }

        [HttpGet("Login")]
        public IActionResult Login([FromQuery] LoginDTO user)
        {
            if (user == null)
            {
                return BadRequest("User data is null"); 
            }

            var record = _db.Users.FirstOrDefault(u => u.Username == user.Username);
            if (record != null && passwordhash.VerifyPasswordHash(user.Password, record.PasswordHash, record.PasswordSalt))
            {
                return Ok("Login successful");
            }

            return Unauthorized("Username or password is wrong");
        }
    }
}
