using Customer.DomainModels.Models;

namespace Customer.DomainServices.Services.Interfaces
{
    public interface ICustomerService
    {
        IList<CustomersModel> Get();
        CustomersModel? GetSpecific(string cpf, string email);
        long Create(CustomersModel model);
        void Update(CustomersModel model);
        void Delete(long id);
    }
}
