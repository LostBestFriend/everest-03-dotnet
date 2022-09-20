﻿using Customer.DomainModels.Formatters;
using Customer.DomainModels.Models;
using Customer.DomainServices.Services.Interfaces;
using Customer.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Customer.DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly FeatureContext _featureContext;
        private readonly DbSet<CustomerModel> _customers;

        public CustomerService(FeatureContext featureContext)
        {
            _featureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext)); 
            _customers = _featureContext.Set<CustomerModel>();
        }

        public IEnumerable<CustomerModel> Get()
        {
            return _customers;
        }

        public long Create(CustomerModel customer)
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

            CustomerModel? customerToDelete = _customers.FirstOrDefault(x => x.Id == id);
            if (customerToDelete is null)
            {
                throw new ArgumentNullException($"Customer Not Found with this Id: {id}");
            }

            _customers.Remove(customerToDelete).State = EntityState.Deleted;
            _featureContext.SaveChanges();
        }

        public void Update(CustomerModel customer)
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

        public CustomerModel? GetSpecific(string cpf, string email)
        {
            cpf = cpf.Formatter();

            var result = _customers.FirstOrDefault(x => x.Email == email && x.Cpf == cpf);

            return result;
        }
    }
}
