namespace DomainServices.CustomerBankInfos.Interface
{
    public interface ICustomerBankInfoService
    {
        void Deposit(long CustomerId, decimal amount);
        void Withdraw(long CustomerId, decimal amount);
        void Create(long CustomerId);
        Task<decimal> GetBalanceByIdAsync(long CustomerId);
    }
}
