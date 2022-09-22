using AppServices.CustomerBankInfos.Interface;
using AutoMapper;
using DomainServices.CustomerBankInfos.Interface;

namespace AppServices.CustomerBankInfos
{
    public class CustomerBankInfoAppService : ICustomerBankInfoAppService
    {
        private readonly ICustomerBankInfoService _customerBankInfoService;

        public CustomerBankInfoAppService(ICustomerBankInfoService customerBankInfoService)
        {
            _customerBankInfoService = customerBankInfoService ?? 
                throw new ArgumentNullException(nameof(customerBankInfoService));
        }

        public void Deposit(long CustomerId, decimal amount)
        {
            _customerBankInfoService.Deposit(CustomerId, amount);
        }

        public async Task<decimal> GetBalanceByIdAsync(long CustomerId)
        {
            var customerBankInfo = await _customerBankInfoService
                .GetBalanceByIdAsync(CustomerId)
                .ConfigureAwait(false);

            return customerBankInfo;
        }

        public void Withdraw(long CustomerId, decimal amount)
        {
            _customerBankInfoService.Withdraw(CustomerId, amount);
        }

        public void Create(long CustomerId)
        {
            _customerBankInfoService.Create(CustomerId);
        }
    }
}
