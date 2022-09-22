namespace AppModels.CustomerBankInfos.Mapper
{
    public class UpdateCustomerBankInfoRequest
    {
        public UpdateCustomerBankInfoRequest(
            long id,
            decimal accountBalance)
        {
            Id = id;
            AccountBalance = accountBalance;
        }

        public long Id { get; set; }
        public decimal AccountBalance { get; set; }
    }
}

