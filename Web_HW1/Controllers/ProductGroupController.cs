using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_HW1.Data;
using Web_HW1.Models;

namespace Web_HW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProductGroup(string name, string description)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.Products.Any(p => p.Name == name))
                    return StatusCode(409);

                var productGroup = new ProductGroup() { Name = name, Description = description};
                storageContext.ProductGroups.Add(productGroup);
                storageContext.SaveChanges();
                return Ok(productGroup.Id);
            }
        }
        [HttpDelete]
        public ActionResult DeleteProductGroup(int id)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var productGroup = storageContext.ProductGroups.FirstOrDefault(p => p.Id == id);
                if (productGroup == null)
                    return NotFound();

                storageContext.ProductGroups.Remove(productGroup);
                storageContext.SaveChanges();
                return Ok();
            }
        }
    }
}
