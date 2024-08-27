using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask_3.DTOs;
using WebAPICoreTask_3.Models;

namespace WebAPICoreTask_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RapperController : ControllerBase
    {
        private readonly MyDbContext _db;
        public RapperController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetAllRappers")]
        public IActionResult Rap()
        {
            var Rapp = _db.Rappers.ToList();
            return Ok(Rapp);
        }

        [HttpGet("GetOneRapperByID/{id}")]
        
        public IActionResult RR(int id)
        {
            var Ra = _db.Rappers.Find(id);
            return Ok(Ra);
        }

        [HttpPost]
        public IActionResult addRapper([FromForm] RapperRequest rapper)
        {
            var data = new Rapper
            {
                RapperName = rapper.RapperName,
                RapperImage = rapper.RapperImage.FileName,
            };
            var ImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uplode");
            if (!Directory.Exists(ImageFolder))
            {
                Directory.CreateDirectory(ImageFolder);
            }
            var ImageFile = Path.Combine("Uplode", rapper.RapperImage.FileName);
            using (var stream = new FileStream(ImageFile, FileMode.Create))
            {
                rapper.RapperImage.CopyToAsync(stream);
            }
            _db.Rappers.Add(data);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateTheRapperByID/{id}")]
        public IActionResult UpdateRepper(int id, [FromForm] RapperRequest rapper)
        {
            var uprapper = _db.Rappers.FirstOrDefault(r=>r.RapperId == id);
            uprapper.RapperName = rapper.RapperName;
            uprapper.RapperImage = rapper.RapperImage.FileName; 
            _db.Rappers.Update(uprapper);
            _db.SaveChanges();
            return Ok();
        }
    }
}
