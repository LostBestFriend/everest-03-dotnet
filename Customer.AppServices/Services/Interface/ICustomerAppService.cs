using Customer.AppModels.Dtos;

namespace Customer.AppServices.Services.Interface
{
    public interface ICustomerAppService
    {
        IList<CustomerResult> Get();
        CustomerResult GetSpecific(string cpf, string email);
        long Create(CreateCustomerDto model);
        void Update(long id, UpdateCustomerDto model);
        void Delete(long id);
    }
}
