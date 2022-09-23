using AppModels.Portfolios.Mapper;
using AppServices.Customers.Interface;
using AppServices.Portfolios.Interface;
using AutoMapper;
using DomainModels;
using DomainServices.Portfolios.Interface;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Portfolios
{
    public class PortfolioAppService : IPortfolioAppService
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;
        private readonly ICustomerAppService _customerAppService;

        public PortfolioAppService(IPortfolioService portfolioService, IMapper mapper, ICustomerAppService customerAppService)
        {
            _portfolioService = portfolioService ?? throw new ArgumentNullException(nameof(portfolioService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        public IEnumerable<PortfolioResult> GetByCustomerId(long customerId)
        {
            var portfolioList = _portfolioService.GetByCustomerId(customerId);

            return _mapper.Map<List<PortfolioResult>>(portfolioList);
        }

        public async Task<long> CreateAsync(CreatePortfolioRequest portfolioRequest)
        {
            var checkCustomer = await _customerAppService.GetByIdAsync(portfolioRequest.CustomerId);
            var mapPortfolio = _mapper.Map<Portfolio>(portfolioRequest);

            if (checkCustomer == null)
            {
                throw new ArgumentException($"Customer with this Id not exists. Id: {portfolioRequest.CustomerId}");
            }
            return await _portfolioService.CreateAsync(mapPortfolio).ConfigureAwait(false);
        }

        public void Invest(long portfolioId, decimal amount)
        {
            _portfolioService.Invest(portfolioId, amount);
        }

        public void Withdraw(long portfolioId, decimal amount)
        {
            _portfolioService.Withdraw(portfolioId, amount);
        }

        public void Delete(long portfolioId)
        {
            _portfolioService.Delete(portfolioId);
        }
    }
}
