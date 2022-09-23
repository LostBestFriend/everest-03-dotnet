using AppModels.Products.Enums;

namespace AppModels.Products.Mapper
{
    public class ProductResult
    {
        public ProductResult(
            long id,
            string symbol,
            decimal unitPrice,
            DateTime issuanceAt,
            DateTime expirationAt,
            int daysToExpire,
            ProductType type)
        {
            Id = id;
            Symbol = symbol;
            UnitPrice = unitPrice;
            IssuanceAt = issuanceAt;
            ExpirationAt = expirationAt;
            DaysToExpire = daysToExpire;
            Type = type;
        }

        protected ProductResult() { }

        public long Id { get; set; }
        public string? Symbol { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }
    }
}
