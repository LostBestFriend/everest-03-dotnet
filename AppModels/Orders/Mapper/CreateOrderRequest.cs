using AppModels.Orders.Enums;

namespace AppModels.Orders.Mapper
{
    public class CreateOrderRequest
    {
        public CreateOrderRequest(
            int quotes,
            decimal unitPrice,
            decimal netValue,
            DateTime liquidatedAt,
            OrderDirection direction,
            long portfolioId,
            long productId)
        {
            Quotes = quotes;
            UnitPrice = unitPrice;
            NetValue = netValue;
            LiquidatedAt = liquidatedAt;
            Direction = direction;
            PortfolioId = portfolioId;
            ProductId = productId;
        }

        public int Quotes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public DateTime LiquidatedAt { get; set; }
        public OrderDirection Direction { get; set; }
        public long PortfolioId { get; set; }
        public long ProductId { get; set; }
    }
}
