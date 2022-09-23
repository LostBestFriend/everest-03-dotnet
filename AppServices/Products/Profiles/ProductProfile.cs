using AppModels.Products.Mapper;
using AutoMapper;
using DomainModels;

namespace AppServices.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResult>();
        }
    }
}
