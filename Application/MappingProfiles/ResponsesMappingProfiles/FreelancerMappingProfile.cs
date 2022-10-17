using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class FreelancerMappingProfile : Profile
{
    public FreelancerMappingProfile()
    {
        CreateMap<Freelancer, FreelancerResponse>(MemberList.Destination)
            .ForMember(dst=>dst.Account, expression =>
            {
                expression.MapFrom(src=>src.Account);
            });
    }
}