using AppModels.Portfolios.Mapper;

namespace AppServices.Portfolios.Interface
{
    public interface IPortfolioAppService
    {
        void Invest(long portfolioId, decimal amount);
        void Withdraw(long portfolioId, decimal amount);
        IEnumerable<PortfolioResult> GetByCustomerId(long customerId);
        Task<long> CreateAsync(CreatePortfolioRequest model);
        void Delete(long portfolioId);
    }
}
