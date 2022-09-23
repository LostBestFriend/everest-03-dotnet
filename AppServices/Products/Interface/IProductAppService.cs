using AppModels.Products.Mapper;

namespace AppServices.Products.Interface
{
    public interface IProductAppService
    {
        IEnumerable<ProductResult> GetAllProducts();
        Task<ProductResult> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateProductRequest model);
        void Delete(long productId);
    }
}
