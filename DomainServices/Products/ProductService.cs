using DomainModels;
using DomainServices.Products.Interface;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;
        
        public ProductService(IUnitOfWork<FeatureContext> unitOfWork, 
            IRepositoryFactory<FeatureContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? (IRepositoryFactory)_unitOfWork;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var _productRepo = _repositoryFactory.Repository<Product>();

            var query = _productRepo.MultipleResultQuery();

            return _productRepo.Search(query);
        }

        public async Task<long> CreateAsync(Product product)
        {
            var _productRepo = _unitOfWork.Repository<Product>();

            if(_productRepo.Any( x => x.Id.Equals(product.Id)))
            {
                throw new ArgumentException($"Product with this Id already exists. ProductId: {product.Id}");
            }

            if(_productRepo.Any(x => x.Symbol.Equals(product.Symbol)))
            {
                throw new ArgumentException($"Product with this Symbol already exists. Symbol: {product.Symbol}");
            }

            await _productRepo.AddAsync(product).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return product.Id;
        }

        public void Delete(long productId)
        {
            var _productRepo = _unitOfWork.Repository<Product>();

            if (!_productRepo.Any(x => x.Id.Equals(productId)))
            {
                throw new ArgumentNullException($"Product Not Found with this Id: {productId}");
            }

            _productRepo.Remove(x => x.Id.Equals(productId));
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var _productRepo = _repositoryFactory.Repository<Product>();

            var query = _productRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(id));

            return await _productRepo.FirstOrDefaultAsync(query);
        }
    }
}
