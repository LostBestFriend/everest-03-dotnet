namespace DomainModels
{
    public class Portfolio : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public virtual ICollection<Product> Products { get; set; }       
        public virtual ICollection<Order> Orders { get; set; }
    }
}
