using AutoMapper;
using Customer.AppModels.Dtos;
using Customer.AppServices.Services.Interface;
using Customer.DomainModels.Models;
using Customer.DomainServices.Services.Interfaces;

namespace Customer.AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public long Create(CreateCustomerDto createCustomer)
        {
            var mapCustomer = _mapper.Map<CustomerModel>(createCustomer);
            return _customerService.Create(mapCustomer);
        }
        public void Delete(long id)
        {
            _customerService.Delete(id);
        }
        public IList<CustomerResult> Get()
        {
            var customerList = _customerService.Get();
            return _mapper.Map<List<CustomerResult>>(customerList);
        }
        public CustomerResult GetSpecific(string cpf, string email)
        {
            var customer = _customerService.GetSpecific(cpf, email);
            return _mapper.Map<CustomerResult>(customer);
        }

        public void Update(long id, UpdateCustomerDto updateCustomer)
        {
            CustomerModel customer = _mapper.Map<CustomerModel>(updateCustomer);
            customer.Id = id;
            _customerService.Update(customer);
        }
    }
}
