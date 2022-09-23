using AppModels.Orders.Mapper;
using AppServices.Orders.Interface;
using AutoMapper;
using DomainModels;
using DomainServices.Orders.Interface;

namespace AppServices.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderAppService(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IEnumerable<OrderResult> GetByPortfolioId(long portfolioId)
        {
            var orderList = _orderService.GetByPortfolioId(portfolioId);

            return _mapper.Map<List<OrderResult>>(orderList);
        }

        public async Task<long> CreateAsync(CreateOrderRequest createOrder)
        {
            var mapOrder = _mapper.Map<Order>(createOrder);

            return await _orderService.CreateAsync(mapOrder).ConfigureAwait(false);
        }
        public async Task<OrderResult> GetByIdAsync(long id)
        {
            var order = await _orderService.GetByIdAsync(id).ConfigureAwait(false);

            return _mapper.Map<OrderResult>(order);
        }

        public void Delete(long id)
        {
            _orderService.Delete(id);
        }
    }
}
