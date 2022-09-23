using AppModels.Products.Enums;

namespace AppModels.Products.Mapper
{
    public class CreateProductRequest
    {
        public CreateProductRequest(
            string symbol,
            decimal unitPrice,
            DateTime issuanceAt,
            DateTime expirationAt,
            int daysToExpire,
            ProductType type)
        {
            Symbol = symbol;
            UnitPrice = unitPrice;
            IssuanceAt = issuanceAt;
            ExpirationAt = expirationAt;
            DaysToExpire = daysToExpire;
            Type = type;
        }

        public string? Symbol { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }
    }
}
