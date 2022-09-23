using DomainModels;
using DomainServices.Orders.Interface;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public OrderService(IUnitOfWork<FeatureContext> unitOfWork, IRepositoryFactory<FeatureContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? (IRepositoryFactory)_unitOfWork;
        }

        public IEnumerable<Order> GetByPortfolioId(long portfolioId)
        {
            var _orderRepo = _repositoryFactory.Repository<Order>();

            var query = _orderRepo.SingleResultQuery().AndFilter(x => x.PortfolioId.Equals(portfolioId));

            return _orderRepo.Search(query);
        }

        public async Task<long> CreateAsync(Order order)
        {
            var _orderRepo = _unitOfWork.Repository<Order>();

            if (_orderRepo.Any(x => x.Id.Equals(order.Id)))
            {
                throw new ArgumentException($"Order with this Id already exists. Id: {order.Id}");
            }

            await _orderRepo.AddAsync(order).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return order.Id;
        }
        public async Task<Order> GetByIdAsync(long id)
        {
            var _orderRepo = _repositoryFactory.Repository<Order>();

            var query = _orderRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(id));

            return await _orderRepo.FirstOrDefaultAsync(query).ConfigureAwait(false);
        }

        public void Delete(long id)
        {
            var _orderRepo = _unitOfWork.Repository<Order>();

            if (!_orderRepo.Any(x => x.Id.Equals(id)))
            {
                throw new ArgumentNullException($"Order Not Found with this Id: {id}");
            }

            _orderRepo.Remove(x => x.Id.Equals(id));
        }
    }
}
