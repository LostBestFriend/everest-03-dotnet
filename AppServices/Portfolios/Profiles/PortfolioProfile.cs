using AppModels.Portfolios.Mapper;
using AutoMapper;
using DomainModels;

namespace AppServices.Portfolios.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<CreatePortfolioRequest, Portfolio>();
            CreateMap<Portfolio, PortfolioResult>();
            CreateMap<UpdatePortfolioRequest, Portfolio>();
        }
    }
}
