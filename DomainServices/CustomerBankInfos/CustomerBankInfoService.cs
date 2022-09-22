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

        public void Deposit(long CustomerId, decimal amount)
        {
            var _customerBankInfoRepo = _unitOfWork.Repository<CustomerBankInfo>();

            var query = _customerBankInfoRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(CustomerId));

            var bankInfo = _customerBankInfoRepo.FirstOrDefault(query);

            if (bankInfo == null)
            {
                throw new ArgumentNullException($"User Not Found with this Id: {CustomerId}");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"Amount is invalid. Amount:{amount}");
            }

            bankInfo.AccountBalance += amount;

            _customerBankInfoRepo.Update(bankInfo);
            _unitOfWork.SaveChanges();
        }

        public async Task<decimal> GetBalanceByIdAsync(long CustomerId)
        {
            var _customerBankInfoRepo = _repositoryFactory.Repository<CustomerBankInfo>();

            var query = _customerBankInfoRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(CustomerId));

            var bankInfo = await _customerBankInfoRepo.FirstOrDefaultAsync(query);

            if (bankInfo == null)
            {
                throw new ArgumentNullException($"Customer not found with this id. Id: {CustomerId}");
            }

            return bankInfo.AccountBalance;
        }

        public void Withdraw(long CustomerId, decimal amount)
        {
            var _customerBankInfoRepo = _unitOfWork.Repository<CustomerBankInfo>();

            var query = _customerBankInfoRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(CustomerId));

            var bankInfo = _customerBankInfoRepo.FirstOrDefault(query);

            if (bankInfo == null)
            {
                throw new ArgumentNullException($"User Not Found with this Id: {CustomerId}");
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

            if (_customerBankInfoRepo.Any(x => x.Id.Equals(customerId)))
            {
                throw new ArgumentException($"CustomerId already used. CustomerId: {customerId}");
            }

            _customerBankInfoRepo.Add(new CustomerBankInfo(customerId));
            _unitOfWork.SaveChanges();     
        }
    }
}
