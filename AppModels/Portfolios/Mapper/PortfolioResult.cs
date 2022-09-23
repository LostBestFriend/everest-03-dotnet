namespace AppModels.Portfolios.Mapper
{
    public class PortfolioResult
    {
        public PortfolioResult(
            long id, 
            string name, 
            string description, 
            decimal totalBalance, 
            long customerId)
        {
            Id = id;
            Name = name;
            Description = description;
            TotalBalance = totalBalance;
            CustomerId = customerId;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public long CustomerId { get; set; }
    }
}
