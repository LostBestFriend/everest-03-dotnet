using FluentValidation;

namespace CustomerCrudApi
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly List<CustomersModel> customersList = new();

        public List<CustomersModel> Get()
        {
            return customersList;
        }

        public long Create(CustomersModel customer)
        {
            if (customersList.Any(x => x.Email == customer.Email || x.Cpf == customer.Cpf))
            {
                throw new ArgumentException($"Email or Cpf already used. Email: {customer.Email}, Cpf: {customer.Cpf}");
            }
            if (customersList.Count() == 0)
            {
                customer.Id = 1;
                customersList.Add(customer);
                return customer.Id;
            }
            customer.Id = customersList.Last().Id + 1;
            customersList.Add(customer);
            return customer.Id;
        }

        public void Delete(string cpf, string email)
        {
            cpf = cpf.Formatter();
            var customerToDelete = customersList.FirstOrDefault(x => x.Cpf == cpf && x.Email == email);
            if (customerToDelete == null)
            {
                throw new ArgumentNullException($"Customer Not Found with this Email: {email} and Cpf: {cpf}");
            }
            customersList.Remove(customerToDelete);
        }

        public void Update(long id, CustomersModel customer)
        {
            customer.Cpf = customer.Cpf.Formatter();

            int index = customersList.FindIndex(x => x.Id == id);
            if (index == -1) throw new ArgumentException($"User Not Found with this Id: {id}");
            if (customersList.Any(x => (x.Cpf == customer.Cpf || x.Email == customer.Email) && x.Id != id)) 
                throw new ArgumentNullException($"Email or Cpf already exists. Email: {customer.Email}, Cpf: {customer.Cpf}");
            customer.Id = customersList[index].Id;
            customersList[index] = customer;
        }

        public CustomersModel GetSpecific(string cpf, string email)
        {
            cpf = cpf.Formatter();

            foreach (CustomersModel c in customersList)
            {
                if (c.Cpf == cpf && c.Email == email)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
