using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class FreelancerMappingProfile : Profile
{
    public FreelancerMappingProfile()
    {
        CreateMap<FreelancerDto, Freelancer>(MemberList.Source)
            .ForMember(dst => dst.Account, expression =>
            {
                expression.MapFrom(src => src.Account);
            });
    }
}