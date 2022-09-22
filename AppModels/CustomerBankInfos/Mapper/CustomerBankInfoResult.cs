namespace AppModels.CustomerBankInfos.Mapper
{
    public class CustomerBankInfoResult
    {
        public CustomerBankInfoResult(
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
