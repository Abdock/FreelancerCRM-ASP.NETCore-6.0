using AutoMapper;
using Domain.Models;
using Persistence.Entities;

namespace Persistence.MappingProfiles;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<Skill, SkillEntity>(MemberList.Source)
            .ForMember(dst => dst.Id, expression => expression.Ignore())
            .ForMember(dst => dst.RowGuid, expression => { expression.MapFrom(src => src.Id); })
            .ForMember(dst => dst.Advertisements, expression => { expression.MapFrom(src => src.Advertisements); })
            .ForMember(dst => dst.Freelancers, expression => { expression.MapFrom(src => src.Freelancers); })
            .ReverseMap();
    }
}