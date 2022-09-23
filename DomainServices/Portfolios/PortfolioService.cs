using DomainModels;
using DomainServices.Portfolios.Interface;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Portfolios
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public PortfolioService(IUnitOfWork<FeatureContext> unitOfWork,
            IRepositoryFactory<FeatureContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? (IRepositoryFactory)_unitOfWork;
        }

        public IEnumerable<Portfolio> GetByCustomerId(long customerId)
        {
            var _portfolioRepo = _repositoryFactory.Repository<Portfolio>();

            var query = _portfolioRepo.SingleResultQuery().AndFilter(x => x.CustomerId.Equals(customerId));

            return _portfolioRepo.Search(query);
        }

        public async Task<long> CreateAsync(Portfolio portfolio)
        {
            var _portfolioRepo = _unitOfWork.Repository<Portfolio>();

            if (_portfolioRepo.Any(x => x.Id.Equals(portfolio.Id)))
            {
                throw new ArgumentException($"Portfolio with this Id already exists. PortfolioId: {portfolio.Id}");
            }

            await _portfolioRepo.AddAsync(portfolio).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return portfolio.Id;
        }

        public void Invest(long portfolioId, decimal amount)
        {
            var _portfolioRepo = _unitOfWork.Repository<Portfolio>();

            var query = _portfolioRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(portfolioId));

            var portfolioInfo = _portfolioRepo.FirstOrDefault(query);

            if (portfolioInfo == null)
            {
                throw new ArgumentNullException($"Portfolio Not Found with this Id: {portfolioId}");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"Amount is invalid. Amount:{amount}");
            }

            portfolioInfo.TotalBalance += amount;

            _portfolioRepo.Update(portfolioInfo);
            _unitOfWork.SaveChanges();
        }

        public void Withdraw(long portfolioId, decimal amount)
        {
            var _portfolioRepo = _unitOfWork.Repository<Portfolio>();

            var query = _portfolioRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(portfolioId));

            var portfolioInfo = _portfolioRepo.FirstOrDefault(query);

            if (portfolioInfo == null)
            {
                throw new ArgumentNullException($"Portfolio Not Found with this Id: {portfolioId}");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"Amount cannot be negative. Amount: {amount}");
            }

            if (amount > portfolioInfo.TotalBalance)
            {
                throw new ArgumentException($"Amount is higher than your total balance. Amount: {amount}");
            }

            portfolioInfo.TotalBalance -= amount;

            _portfolioRepo.Update(portfolioInfo);
            _unitOfWork.SaveChanges();
        }

        public void Delete(long portfolioId)
        {
            var _portfolioRepo = _unitOfWork.Repository<Portfolio>();

            if (!_portfolioRepo.Any(x => x.Id.Equals(portfolioId)))
            {
                throw new ArgumentNullException($"Portfolio Not Found with this Id: {portfolioId}");
            }

            _portfolioRepo.Remove(x => x.Id.Equals(portfolioId));
        }
    }
}
