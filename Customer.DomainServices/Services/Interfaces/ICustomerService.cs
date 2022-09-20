using Customer.DomainModels.Models;

namespace Customer.DomainServices.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Get();
        CustomerModel? GetSpecific(string cpf, string email);
        long Create(CustomerModel model);
        void Update(CustomerModel model);
        void Delete(long id);
    }
}
