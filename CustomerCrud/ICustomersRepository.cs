namespace CustomerCrudApi
{
    public interface ICustomersRepository
    {
        public List<CustomersModel> Get();
        public CustomersModel GetById(long id);
        public int Create(CustomersModel model);
        public int Update(CustomersModel model);
        public CustomersModel GetSpecific(string cpf, string email);
        public int Delete(string cpf, string email);

    }
}
