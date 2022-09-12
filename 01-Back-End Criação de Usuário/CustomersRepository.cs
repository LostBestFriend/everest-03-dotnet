using FluentValidation.Results;

namespace _01_Back_End_Criação_de_Usuário
{
    public class CustomersRepository : ICustomersRepository
    {
        public List<CustomersModel> customersList = new List<CustomersModel>();
        private CustomersModel customerModel = new CustomersModel();

        public List<CustomersModel> Get()
        {
            return customersList;
        }
        public int Create(CustomersModel customer)
        {
            customer.Cpf = customer.Cpf.Trim().Replace(".", "").Replace("-", "");
            customer.Id = customersList.Count + 1;
            CustomersValidator valid = new();
            ValidationResult result = valid.Validate(customer);

            if (result.IsValid)
            {
                if (!customersList.Any())
                {
                    customersList.Add(customer);
                    return 201;
                }

                foreach (CustomersModel c in customersList)
                {
                    if (customer.Cpf != c.Cpf && customer.Email != c.Email)
                    {
                        customersList.Add(customer);
                        return 201;
                    }
                    else
                    {
                        return 409;
                    }
                }
            }
            return 400;
        }
        public int Delete(string cpf, string email)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (!customersList.Any())
            {
                return 400;
            }

            foreach (CustomersModel c in customersList)
            {
                if (cpf == c.Cpf && email == c.Email)
                {
                    customersList.Remove(c);
                    return 200;
                }
            }
            return 404;
        }

        public CustomersModel GetById(long id)
        {
            customerModel = customersList.Find(x => x.Id == id)!;

            return customerModel!;
        }
        public int Update(CustomersModel customer)
        {
            customer.Cpf = customer.Cpf.Trim().Replace(".", "").Replace("-", "");
            if (!customersList.Any())
            {
                return 400;
            }

            foreach (CustomersModel c in customersList)
            {
                if (customer.Cpf == c.Cpf && customer.Email == c.Email)
                {
                    c.Address = customer.Address;
                    c.City = customer.City;
                    c.Cpf = customer.Cpf;
                    c.Cellphone = customer.Cellphone;
                    c.Country = customer.Country;
                    c.FullName = customer.FullName;
                    c.Number = customer.Number;
                    c.DateOfBirth = customer.DateOfBirth;
                    c.Email = customer.Email;
                    c.EmailConfirmation = customer.EmailConfirmation;
                    c.PostalCode = customer.PostalCode;
                    c.Whatsapp = customer.Whatsapp;
                    c.EmailSms = customer.EmailSms;
                    return 200;
                }
                return 404;
            }
            return 400;
        }
        public CustomersModel GetSpecific(string cpf, string email)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (!customersList.Any())
            {
                return null;
            }

            foreach (CustomersModel c in customersList)
            {
                if (c.Cpf == cpf && c.Email == email)
                {
                    return c;
                }
                return null;
            }
            return null;
        }
    }
}
