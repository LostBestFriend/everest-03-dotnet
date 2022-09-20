using AppModels.Mapper;
using AppServices.Interface;
using AutoMapper;
using DomainModels;
using DomainServices.Interface;

namespace AppServices
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

        public async Task<long> CreateAsync(CreateCustomerRequest createCustomer)
        {
            var mapCustomer = _mapper.Map<Customer>(createCustomer);
            return await _customerService.CreateAsync(mapCustomer).ConfigureAwait(false);
        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public IEnumerable<CustomerResult> Get()
        {
            var customerList = _customerService.Get();
            return _mapper.Map<List<CustomerResult>>(customerList);
        }

        public async Task<CustomerResult> GetByIdAsync(long id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<CustomerResult>(customer);
        }

        public void Update(long id, UpdateCustomerRequest updateCustomer)
        {
            var customer = _mapper.Map<Customer>(updateCustomer);
            customer.Id = id;
            _customerService.Update(customer);
        }
    }
}
