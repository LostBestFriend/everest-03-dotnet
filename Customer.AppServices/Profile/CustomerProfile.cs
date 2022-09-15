using AutoMapper;
using Customer.AppModels.Dtos;
using Customer.DomainModels.Models;

namespace Customer.AppServices.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerDto, CustomersModel>();
            CreateMap<CustomersModel, GetCustomerDto>();
            CreateMap<UpdateCustomerDto, CustomersModel>();
        }
    }
}
