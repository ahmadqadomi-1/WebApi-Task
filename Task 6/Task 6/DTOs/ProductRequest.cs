﻿using Task_6.Models;

namespace Task_6.DTOs
{
    public class ProductRequest
    {
        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public IFormFile? ProductImage { get; set; }
    }
}
