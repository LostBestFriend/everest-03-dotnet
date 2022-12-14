using DomainModels;

namespace DomainServices.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
        Task<Customer> GetByIdAsync(long id);
        Task<long> CreateAsync(Customer model);
        void Update(Customer model);
        void Delete(long id);
    }
}
