namespace DomainModels
{
    public class Order : IEntity
    {
        public long Id { get; set; }
        public int Quotes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public DateTime LiquidatedAt { get; set; }
        public OrderDirection Direction { get; set; }
        public Portfolio Portfolio { get; set; }
        public long PortfolioId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }

        public Order(long portfolioId, long productId)
        {
            PortfolioId = portfolioId;
            ProductId = productId;
        }
    }
}
