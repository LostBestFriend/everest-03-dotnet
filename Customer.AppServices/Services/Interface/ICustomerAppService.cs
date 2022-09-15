using Customer.DomainModels.Models;

namespace Customer.AppServices.Services.Interface
{
    public interface ICustomerAppService
    {
        List<CustomersModel> Get();
        CustomersModel? GetSpecific(string cpf, string email);
        long Create(CustomersModel model);
        void Update(CustomersModel model);
        void Delete(long id);
    }
}
