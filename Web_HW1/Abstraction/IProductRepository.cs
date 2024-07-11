using Microsoft.AspNetCore.Mvc;
using Web_HW1.Dto;
using Web_HW1.Models;

namespace Web_HW1.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);
        string GetProductsCSV();
    }
}