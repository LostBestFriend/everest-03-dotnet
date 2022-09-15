using Customer.AppServices.Services.Interface;
using Customer.DomainModels.Models;
using Customer.DomainServices.Services.Interfaces;

namespace Customer.AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public long Create(CustomersModel customer)
        {
            return _customerService.Create(customer);
        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public List<CustomersModel> Get()
        {
            return _customerService.Get();
        }

        public CustomersModel? GetSpecific(string cpf, string email)
        {
            return _customerService.GetSpecific(cpf, email);
        }

        public void Update(CustomersModel customer)
        {
            _customerService.Update(customer);
        }
    }
}
