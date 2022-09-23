using DomainModels;
using DomainServices.CustomerBankInfos.Interface;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.CustomerBankInfos
{
    public class CustomerBankInfoService : ICustomerBankInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerBankInfoService(IUnitOfWork<FeatureContext> unitOfWork,
            IRepositoryFactory<FeatureContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? (IRepositoryFactory)_unitOfWork;
        }

        public void Deposit(long customerId, decimal amount)
        {
            var _customerBankInfoRepo = _unitOfWork.Repository<CustomerBankInfo>();

            var query = _customerBankInfoRepo.SingleResultQuery().AndFilter(x => x.CustomerId.Equals(customerId));

            var bankInfo = _customerBankInfoRepo.FirstOrDefault(query);

            if (bankInfo == null)
            {
                throw new ArgumentNullException($"User Not Found with this Id: {customerId}");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"Amount is invalid. Amount:{amount}");
            }

            bankInfo.AccountBalance += amount;

            _customerBankInfoRepo.Update(bankInfo);
            _unitOfWork.SaveChanges();
        }

        public async Task<decimal> GetBalanceByIdAsync(long customerId)
        {
            var _customerBankInfoRepo = _repositoryFactory.Repository<CustomerBankInfo>();

            var query = _customerBankInfoRepo.SingleResultQuery().AndFilter(x => x.CustomerId.Equals(customerId));

            var bankInfo = await _customerBankInfoRepo.FirstOrDefaultAsync(query);

            if (bankInfo == null)
            {
                throw new ArgumentNullException($"Customer not found with this id. Id: {customerId}");
            }

            return bankInfo.AccountBalance;
        }

        public void Withdraw(long customerId, decimal amount)
        {
            var _customerBankInfoRepo = _unitOfWork.Repository<CustomerBankInfo>();

            var query = _customerBankInfoRepo.SingleResultQuery().AndFilter(x => x.CustomerId.Equals(customerId));

            var bankInfo = _customerBankInfoRepo.FirstOrDefault(query);

            if (bankInfo == null)
            {
                throw new ArgumentNullException($"User Not Found with this Id: {customerId}");
            }

            if (amount > bankInfo.AccountBalance || amount <= 0)
            {
                throw new ArgumentException($"Amount is invalid. Amount:{amount}");
            }

            bankInfo.AccountBalance -= amount;

            _customerBankInfoRepo.Update(bankInfo);
            _unitOfWork.SaveChanges();
        }

        public void Create(long customerId)
        {
            var _customerBankInfoRepo = _unitOfWork.Repository<CustomerBankInfo>();

            if (_customerBankInfoRepo.Any(x => x.CustomerId.Equals(customerId)))
            {
                throw new ArgumentException($"CustomerId already used. CustomerId: {customerId}");
            }

            _customerBankInfoRepo.Add(new CustomerBankInfo(customerId));
            _unitOfWork.SaveChanges();     
        }
    }
}
