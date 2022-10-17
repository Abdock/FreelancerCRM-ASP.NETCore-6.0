using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<NewSkillDto, Skill>(MemberList.Source);
        CreateMap<CreatedSkillDto, Skill>(MemberList.Source);
    }
}