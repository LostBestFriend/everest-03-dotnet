using DomainModels;

namespace DomainServices.Portfolios.Interface
{
    public interface IPortfolioService
    {
        void Invest(long portfolioId, decimal amount);
        void Withdraw(long portfolioId, decimal amount);
        IEnumerable<Portfolio> GetByCustomerId(long customerId);
        Task<long> CreateAsync(Portfolio model);
        void Delete(long portfolioId);
    }
}
