using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_6.DTOs;
using Task_6.Models;

namespace Task_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _db;
        public CategoryController(MyDbContext db) 
        {
            _db = db;
        }
        [HttpGet("getAllCategories")]
        public IActionResult get()
        {
            var ge = _db.Categories.ToList();
            return Ok(ge);
        }
        [HttpGet("GetOneCategoryByID/{id}")]

        public IActionResult getAll(int id)
        {
            var Ra = _db.Categories.Find(id);
            return Ok(Ra);
        }
        [HttpPost("AddNewCategory")]
        public IActionResult addCategory([FromForm] CategoryRequest request)
        {
            var data = new Category
            {
                CategoryName = request.CategoryName,
                CategoryImage = request.CategoryImage.FileName,
            };
            var ImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uplode");
            if (!Directory.Exists(ImageFolder))
            {
                Directory.CreateDirectory(ImageFolder);
            }
            var ImageFile = Path.Combine(ImageFolder,request.CategoryImage.FileName);
            using (var stream = new FileStream(ImageFile, FileMode.Create))
            {
                request.CategoryImage.CopyToAsync(stream);
            }
            _db.Categories.Add(data);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateTheCategoryByID/{id}")]
        public IActionResult UpdateCategory(int id, [FromForm] CategoryRequest Category)
        {
            var UpCategory = _db.Categories.FirstOrDefault(r => r.CategoryId == id);
            UpCategory.CategoryName = Category.CategoryName;
            UpCategory.CategoryName = Category.CategoryImage.FileName;
            _db.Categories.Update(UpCategory);
            _db.SaveChanges();
            return Ok();
        }

    }
}
