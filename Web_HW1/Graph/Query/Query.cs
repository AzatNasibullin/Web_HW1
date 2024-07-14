using Web_HW1.Dto;
using Web_HW1.Abstraction;
using ASPLess3.Abstraction;

namespace Web_HW1.Graph.Query
{
    public class Query
    {
        //public IEnumerable<ProductDto> GetProducts() => productRepository.GetAllProducts();
        public IEnumerable<ProductDto> GetProducts([Service] IProductRepository repository) =>
            repository.GetAllProducts();

        public IEnumerable<ProductGroupDto> GetProductGroups([Service] IProductGroupRepository groupRepository) =>
            groupRepository.GetAllProductGroups();

        public IEnumerable<StorageDto> GetStorageCount([Service] IStorageRepository storageRepository) =>
            storageRepository.GetProductsCountOnStorage();
    }
}