using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<Skill, SkillResponse>(MemberList.Destination);
    }
}