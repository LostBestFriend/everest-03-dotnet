using DomainModels;

namespace DomainServices.Products.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Task<Product> GetByIdAsync(long id);
        Task<long> CreateAsync(Product model);
        void Delete(long productId);
    }
}
