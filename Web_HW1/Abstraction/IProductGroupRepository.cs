using Web_HW1.Dto;
using Web_HW1.Models;

namespace Web_HW1.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        void DeleteProductGroup(int id);
    }
}
