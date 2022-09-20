using DomainModels;
using DomainModels.Extensions;
using DomainServices.Interface;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainServices
{
    public class CustomerService : ICustomerService
    {
        private readonly FeatureContext _featureContext;
        private readonly DbSet<Customer> _customers;

        public CustomerService(FeatureContext featureContext)
        {
            _featureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
            _customers = _featureContext.Set<Customer>();
        }

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public long Create(Customer customer)
        {
            if (_customers.Any(x => x.Email == customer.Email || x.Cpf == customer.Cpf))
            {
                throw new ArgumentException($"Email or Cpf already used. Email: {customer.Email}, Cpf: {customer.Cpf}");
            }

            _customers.Add(customer);
            _featureContext.SaveChanges();
            return customer.Id;
        }

        public void Delete(long id)
        {
            var customerToDelete = _customers.FirstOrDefault(x => x.Id == id);
            if (customerToDelete is null)
            {
                throw new ArgumentNullException($"Customer Not Found with this Id: {id}");
            }

            _customers.Remove(customerToDelete).State = EntityState.Deleted;
            _featureContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            if (!_customers.Any(x => x.Id == customer.Id))
            {
                throw new ArgumentNullException($"User Not Found with this Id: {customer.Id}");
            }

            if (_customers.Any(x => (x.Cpf == customer.Cpf || x.Email == customer.Email) && x.Id != customer.Id))
            {
                throw new ArgumentException($"Email or Cpf already exists.");
            }

            _customers.Update(customer);
            _featureContext.SaveChanges();
        }

        public Customer? GetSpecific(string cpf, string email)
        {
            cpf = cpf.Formatter();

            var result = _customers.FirstOrDefault(x => x.Email == email && x.Cpf == cpf);

            return result;
        }
    }
}

