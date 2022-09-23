using DomainModels;

namespace DomainServices.Customers.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Task<Customer> GetByIdAsync(long id);
        Task<long> CreateAsync(Customer model);
        void Update(Customer model);
        void Delete(long id);
    }
}
