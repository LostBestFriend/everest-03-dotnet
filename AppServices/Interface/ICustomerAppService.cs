using AppModels.Mapper;

namespace AppServices.Interface
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResult> Get();
        Task<CustomerResult> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateCustomerRequest model);
        void Update(long id, UpdateCustomerRequest model);
        void Delete(long id);
    }
}
