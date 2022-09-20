using AutoMapper;
using Customer.AppModels.Dtos;
using Customer.DomainModels.Models;

namespace Customer.AppServices.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerDto, CustomerModel>();
            CreateMap<CustomerModel, CustomerResult>();
            CreateMap<UpdateCustomerDto, CustomerModel>();
        }
    }
}
