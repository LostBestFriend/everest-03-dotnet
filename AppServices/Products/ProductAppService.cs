using AppModels.Products.Mapper;
using AppServices.Products.Interface;
using AutoMapper;
using DomainModels;
using DomainServices.Products.Interface;

namespace AppServices.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        
        public ProductAppService(IProductService productService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<ProductResult> GetAllProducts()
        {
            var productList = _productService.GetAllProducts();

            return _mapper.Map<List<ProductResult>>(productList);
        }

        public async Task<long> CreateAsync(CreateProductRequest createProduct)
        {
            var mapProduct = _mapper.Map<Product>(createProduct);

            return await _productService.CreateAsync(mapProduct).ConfigureAwait(false);
        }

        public void Delete(long productId)
        {
            _productService.Delete(productId);
        }

        public async Task<ProductResult> GetByIdAsync(long productId)
        {
            var product = await _productService.GetByIdAsync(productId).ConfigureAwait(false);
            
            return _mapper.Map<ProductResult>(product);
        }
    }
}
