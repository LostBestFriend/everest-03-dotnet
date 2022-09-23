using AppModels.Orders.Mapper;

namespace AppServices.Orders.Interface
{
    public interface IOrderAppService
    {
        IEnumerable<OrderResult> GetByPortfolioId(long portfolioId);
        Task<OrderResult> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateOrderRequest model);
        void Delete(long id);
    }
}
