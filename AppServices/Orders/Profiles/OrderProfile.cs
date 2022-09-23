using AppModels.Orders.Mapper;
using AutoMapper;
using DomainModels;

namespace AppServices.Orders.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, OrderResult>();
        }
    }
}
