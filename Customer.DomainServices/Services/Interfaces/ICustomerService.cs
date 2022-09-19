using Customer.DomainModels.Models;

namespace Customer.DomainServices.Services.Interfaces
{
    public interface ICustomerService
    {
        IList<CustomerModel> Get();
        CustomerModel? GetSpecific(string cpf, string email);
        long Create(CustomerModel model);
        void Update(CustomerModel model);
        void Delete(long id);
    }
}
