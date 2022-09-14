namespace CustomerCrudApi
{
    public interface ICustomersRepository
    {
        List<CustomersModel> Get();
        CustomersModel GetSpecific(string cpf, string email);
        long Create(CustomersModel model);
        void Update(long id, CustomersModel model);
        void Delete(string cpf, string email);
    }  
}
