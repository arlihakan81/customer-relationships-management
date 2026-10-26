using AutoMapper;
using CRM.Application.Dtos.Companies;
using CRM.Domain.Entities;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Company, CompanyListDto>();
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
        }



    }
}
