namespace DomainModels
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string? Symbol { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; } = Array.Empty<Portfolio>();
        public ICollection<Order> Orders { get; set; } = Array.Empty<Order>();
    }
}
