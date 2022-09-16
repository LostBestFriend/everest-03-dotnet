using Customer.DomainModels.Formatters;
using Customer.DomainModels.Models;
using Customer.DomainServices.Services.Interfaces;
using Customer.Infrastructure.Data.Context;

namespace Customer.DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly FeatureContext _featureContext;

        public CustomerService(FeatureContext featureContext)
        {
            _featureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
        }

        public List<CustomersModel> Get()
        {
            return _featureContext.Customers.ToList();
        }

        public long Create(CustomersModel customer)
        {
            if (_featureContext.Customers.Any(x => x.Email == customer.Email || x.Cpf == customer.Cpf))
            {
                throw new ArgumentException($"Email or Cpf already used. Email: {customer.Email}, Cpf: {customer.Cpf}");
            }

            _featureContext.Customers.Add(customer);
            _featureContext.SaveChanges();
            return customer.Id;
        }

        public void Delete(long id)
        {
            CustomersModel customerToDelete = _featureContext.Customers.FirstOrDefault(x => x.Id == id);
            if (customerToDelete == null)
            {
                throw new ArgumentNullException($"Customer Not Found with this Id: {id}");
            }

            _featureContext.Customers.Remove(customerToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _featureContext.SaveChanges();
        }

        public void Update(CustomersModel customer)
        {
            if (!_featureContext.Customers.Any(x => x.Id == customer.Id))
            {
                throw new ArgumentException($"User Not Found with this Id: {customer.Id}");
            }

            if (_featureContext.Customers.Any(x => (x.Cpf == customer.Cpf || x.Email == customer.Email) && x.Id != customer.Id))
            {
                throw new ArgumentNullException($"Email or Cpf already exists.");
            }

            _featureContext.Customers.Update(customer);
            _featureContext.SaveChanges();
        }

        public CustomersModel? GetSpecific(string cpf, string email)
        {
            cpf = cpf.Formatter();

            var result = _featureContext.Customers.FirstOrDefault(x => x.Email == email && x.Cpf == cpf);

            return result;
        }
        private CustomersModel GetById(long id)
        {
            CustomersModel customer = _featureContext.Customers.Find(id);
            return customer;
        }
    }
}
