using AppModels.Mapper;
using AutoMapper;
using DomainModels;

namespace AppServices.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<UpdateCustomerRequest, Customer>();
        }
    }
}
