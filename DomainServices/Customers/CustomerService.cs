using DomainModels;
using DomainServices.Customers.Interface;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerService(IUnitOfWork<FeatureContext> unitOfWork, IRepositoryFactory<FeatureContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? (IRepositoryFactory)_unitOfWork;
        }

        public IEnumerable<Customer> Get()
        {
            var _customerRepo = _repositoryFactory.Repository<Customer>();

            var query = _customerRepo.MultipleResultQuery();

            return _customerRepo.Search(query);
        }

        public async Task<long> CreateAsync(Customer customer)
        {
            var _customerRepo = _unitOfWork.Repository<Customer>();

            if (_customerRepo.Any(x => x.Email == customer.Email))
            {
                throw new ArgumentException($"Email already used. Email: {customer.Email}");
            }

            if (_customerRepo.Any(x => x.Cpf == customer.Cpf))
            {
                throw new ArgumentException($"Cpf already used. Cpf: {customer.Cpf}");
            }

            await _customerRepo.AddAsync(customer).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return customer.Id;
        }

        public void Delete(long id)
        {
            var _customerRepo = _unitOfWork.Repository<Customer>();

            if (!_customerRepo.Any(x => x.Id == id))
            {
                throw new ArgumentNullException($"Customer Not Found with this Id: {id}");
            }

            _customerRepo.Remove(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            var _customerRepo = _unitOfWork.Repository<Customer>();

            if (!_customerRepo.Any(x => x.Id == customer.Id))
            {
                throw new ArgumentNullException($"User Not Found with this Id: {customer.Id}");
            }

            if (_customerRepo.Any(x => x.Email == customer.Email))
            {
                throw new ArgumentException($"Email already used. Email: {customer.Email}");
            }

            if (_customerRepo.Any(x => x.Cpf == customer.Cpf))
            {
                throw new ArgumentException($"Cpf already used. Cpf: {customer.Cpf}");
            }

            _customerRepo.Update(customer);

            _unitOfWork.SaveChanges();
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            var _customerRepo = _repositoryFactory.Repository<Customer>();

            var query = _customerRepo.SingleResultQuery().AndFilter(x => x.Id.Equals(id));

            return await _customerRepo.FirstOrDefaultAsync(query);
        }
    }
}

