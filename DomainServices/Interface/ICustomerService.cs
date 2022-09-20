using DomainModels;

namespace DomainServices.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
        Customer? GetSpecific(string cpf, string email);
        long Create(Customer model);
        void Update(Customer model);
        void Delete(long id);
    }
}
