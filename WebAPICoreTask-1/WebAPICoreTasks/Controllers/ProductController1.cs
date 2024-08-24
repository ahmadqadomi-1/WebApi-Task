using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTasks.Models;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController1 : ControllerBase
    {
        private readonly MyDbContext _db;

        public ProductController1(MyDbContext db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult Product()
        {
            var Products = _db.Products.ToList();

            return Ok(Products);
        }

        [HttpGet("{idProd}")]

        public IActionResult ProductById(int id)
        {
            var Products = _db.Products.Select(p => new
            {
                p.ProductId,
                p.ProductImage,
                p.ProductName,
                p.Description,
                p.Category,
                p.CategoryId
            }); ;
            return Ok(Products);
        }
    }
}
