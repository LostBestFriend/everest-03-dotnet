namespace AppModels.Portfolios.Mapper
{
    public class UpdatePortfolioRequest
    {
        public UpdatePortfolioRequest(
            string name,
            string description,
            decimal totalBalance,
            long customerId)
        {
            Name = name;
            Description = description;
            TotalBalance = totalBalance;
            CustomerId = customerId;         
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public long CustomerId { get; set; }
    }
}
