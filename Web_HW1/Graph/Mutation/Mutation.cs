using ASPLess3.Abstraction;
using Web_HW1.Abstraction;
using Web_HW1.Dto;
using Web_HW1.Repository;

namespace Web_HW1.Graph.Mutation
{
    public class Mutation//(IProductRepository productRepository)
    {
        public int AddProduct([Service] IProductRepository productRepository, ProductDto productDto) => productRepository.AddProduct(productDto);
        public int AddProductGroup([Service] IProductGroupRepository productGroupRepository, ProductGroupDto productGroupDto) =>
            productGroupRepository.AddProductGroup(productGroupDto);
        public int AddProductOnStorage([Service] IStorageRepository storageRepository, StorageDto storageDto) => storageRepository.AddProductOnStorage(storageDto);
    }
}