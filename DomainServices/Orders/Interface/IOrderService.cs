using DomainModels;

namespace DomainServices.Orders.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetByPortfolioId(long portfolioId);
        Task<Order> GetByIdAsync(long id);
        Task<long> CreateAsync(Order model);
        void Delete(long id);
    }
}
