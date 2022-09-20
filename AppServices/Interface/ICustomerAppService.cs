using AppModels.Mapper;

namespace AppServices.Interface
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResult> Get();
        CustomerResult GetSpecific(string cpf, string email);
        long Create(CreateCustomerRequest model);
        void Update(long id, UpdateCustomerRequest model);
        void Delete(long id);
    }
}
