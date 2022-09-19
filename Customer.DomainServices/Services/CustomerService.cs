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
            return _featureContext.Set<CustomersModel>().ToList();
        }

        public long Create(CustomersModel customer)
        {
            var context = _featureContext.Set<CustomersModel>();

            if (context.Any(x => x.Email == customer.Email || x.Cpf == customer.Cpf))
            {
                throw new ArgumentException($"Email or Cpf already used. Email: {customer.Email}, Cpf: {customer.Cpf}");
            }

            context.Add(customer);
            _featureContext.SaveChanges();
            return customer.Id;
        }

        public void Delete(long id)
        {
            var context = _featureContext.Set<CustomersModel>();

            CustomersModel customerToDelete = context.FirstOrDefault(x => x.Id == id);
            if (customerToDelete == null)
            {
                throw new ArgumentNullException($"Customer Not Found with this Id: {id}");
            }

            context.Remove(customerToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _featureContext.SaveChanges();
        }

        public void Update(CustomersModel customer)
        {
            var context = _featureContext.Set<CustomersModel>();

            if (!context.Any(x => x.Id == customer.Id))
            {
                throw new ArgumentException($"User Not Found with this Id: {customer.Id}");
            }

            if (context.Any(x => (x.Cpf == customer.Cpf || x.Email == customer.Email) && x.Id != customer.Id))
            {
                throw new ArgumentNullException($"Email or Cpf already exists.");
            }

            context.Update(customer);
            _featureContext.SaveChanges();
        }

        public CustomersModel? GetSpecific(string cpf, string email)
        {
            cpf = cpf.Formatter();

            var result = _featureContext.Set<CustomersModel>().FirstOrDefault(x => x.Email == email && x.Cpf == cpf);

            return result;
        }
    }
}
