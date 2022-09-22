namespace AppServices.CustomerBankInfos.Interface
{
    public interface ICustomerBankInfoAppService
    {
        void Deposit(long CustomerId, decimal amount);
        void Withdraw(long CustomerId, decimal amount);
        void Create(long CustomerId);
        Task<decimal> GetBalanceByIdAsync(long id);

    }
}
