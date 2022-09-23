using AppModels.Orders.Enums;

namespace AppModels.Orders.Mapper
{
    public class OrderResult
    {
        public OrderResult(
            long id,
            int quotes,
            decimal unitPrice,
            decimal netValue,
            DateTime liquidatedAt,
            OrderDirection direction,
            long portfolioId,
            long productId)
        {
            Id = id;
            Quotes = quotes;
            UnitPrice = unitPrice;
            NetValue = netValue;
            LiquidatedAt = liquidatedAt;
            Direction = direction;
            PortfolioId = portfolioId;
            ProductId = productId;
        }

        public long Id { get; set; }
        public int Quotes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public DateTime LiquidatedAt { get; set; }
        public OrderDirection Direction { get; set; }
        public long PortfolioId { get; set; }
        public long ProductId { get; set; }
    }
}
