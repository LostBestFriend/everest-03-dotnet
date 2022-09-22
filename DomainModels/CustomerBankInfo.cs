namespace DomainModels
{
    public class CustomerBankInfo : IEntity
    {
        public long Id { get; set; }
        public decimal AccountBalance { get; set; }
        public Customer Customer { get; set; } = default!;
        public long CustomerId { get; set; }

        public CustomerBankInfo(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
