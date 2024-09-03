using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_6.DTOs;
using Task_6.Models;

namespace Task_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductsController(MyDbContext db) {
            _db = db;
        }
        [HttpGet("GetAllProducts")]
        
        public IActionResult First()
        {
            var tra = _db.Products.ToList();
            return Ok(tra);
        }
        [HttpGet]
        [Route("GetAllProductsForOneCategory/{id}")]
        public IActionResult PP(int id)
        {
            var Ta = _db.Products.Where(a => a.ProductId == id).ToList();
            return Ok(Ta);
        }
        [HttpGet("GetAllProductsDesc")]
        public IActionResult GetProducts()
        {
            var Productss = _db.Products.OrderByDescending(p => p.Price);
            return Ok(Productss.ToList());
        }


        [HttpGet("get")]
        public IActionResult sort()
        {
            var sortt = _db.Products.OrderBy(S => S.ProductName).ToList().TakeLast(5);
            return Ok(sortt);
        }

        [HttpPost("AddNewProduct")]
        public IActionResult AddTrack([FromForm] ProductRequest Product)
        {
            var data = new Product
            {
                ProductName = Product.ProductName,
                Description = Product.Description,
                Price = Product.Price,
                CategoryId = Product.CategoryId,
                ProductImage = Product.ProductImage.FileName
            };
            var ImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uplode");
            if (!Directory.Exists(ImageFolder))
            {
                Directory.CreateDirectory(ImageFolder);
            }
            var ImageFile = Path.Combine("Uplode", Product.ProductImage.FileName);
            using (var stream = new FileStream(ImageFile, FileMode.Create))
            {
                Product.ProductImage.CopyToAsync(stream);
            }
            _db.Products.Add(data);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateTheProductByID/{id}")]
        public IActionResult UpdateTracks(int id, [FromForm] ProductRequest request)
        {
            var UpProduct = _db.Products.FirstOrDefault(t => t.ProductId == id);
            UpProduct.ProductName = request.ProductName;
            UpProduct.Description = request.Description;
            UpProduct.Price = request.Price;
            UpProduct.CategoryId = request.CategoryId;
            UpProduct.ProductImage = request.ProductImage.FileName;

            _db.Products.Update(UpProduct);
            _db.SaveChanges();
            return Ok();
        }
    }
}
