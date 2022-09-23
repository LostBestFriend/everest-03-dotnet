using AppModels.Customers.Mapper;

namespace AppServices.Customers.Interface
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResult> GetAllCustomers();
        Task<CustomerResult> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateCustomerRequest model);
        void Update(long id, UpdateCustomerRequest model);
        void Delete(long id);
    }
}
