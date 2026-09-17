using AutoMapper;
using Entities.Models;
using Shared.Dto;

namespace UltimateNetFiApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                       .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => x.Address + ", " + x.Country));

            CreateMap<Employee, EmployeeDto>();
        }
    }
}
