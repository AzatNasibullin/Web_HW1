﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using Web_HW1.Data;
using Web_HW1.Models;
using CsvHelper;
using Web_HW1.Abstraction;
using Web_HW1.Dto;

namespace Web_HW1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("add_product")]
        public ActionResult<int> AddProduct(ProductDto productDto)
        {
            try
            {
                var id = _productRepository.AddProduct(productDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }
        }
        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts());
        }
        [HttpGet("get_products_csv")]
        public FileContentResult GetProductsCSV()
        {
            var content = _productRepository.GetProductsCSV();
            return File(new System.Text.UTF8Encoding().GetBytes(content), "text/csv", "report.csv");
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var product = storageContext.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    storageContext.Products.Remove(product);
                    storageContext.SaveChanges();
                    return Ok();
                }
                return StatusCode(404, "Нет продукта с таким ID");
            }
        }
    }
}
