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
            
            customer.Id = customersList.LastOrDefault()?.Id + 1 ?? 1;
            customersList.Add(customer);
            return customer.Id;
        }

        public void Delete(long id) 
        {
            var customerToDelete = customersList.Find(x => x.Id == id);
            if (customerToDelete == null)
            {
                throw new ArgumentNullException($"Customer Not Found with this Id: {id}");
            }
            customersList.Remove(customerToDelete);
        }

        public void Update(long id, CustomersModel customer)
        {
            customer.Cpf = customer.Cpf.Formatter();

            var index = customersList.FindIndex(x => x.Id == id);
            if (index == -1) throw new ArgumentException($"User Not Found with this Id: {id}");

            if (customersList.Any(x => (x.Cpf == customer.Cpf || x.Email == customer.Email) && x.Id != id)) 
                throw new ArgumentNullException($"Email or Cpf already exists. Email: {customer.Email}, Cpf: {customer.Cpf}");
            
            customer.Id = customersList[index].Id;

            customersList[index] = customer;
        }

        public CustomersModel? GetSpecific(string cpf, string email)
        {
            cpf = cpf.Formatter();

            var result = customersList.FirstOrDefault(x => x.Email == email && x.Cpf == cpf);

            return result;
        }
    }
}
