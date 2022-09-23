namespace DomainModels
{
    public class Portfolio : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public virtual ICollection<Product> Products { get; set; } = Array.Empty<Product>();  
        public virtual ICollection<Order> Orders { get; set; } = Array.Empty<Order>();

        public Portfolio(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
