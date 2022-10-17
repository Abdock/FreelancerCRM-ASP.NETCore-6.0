using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class AdvertisementMappingProfile : Profile
{
    public AdvertisementMappingProfile()
    {
        CreateMap<AdvertisementDto, Advertisement>(MemberList.Source)
            .ForMember(dst => dst.Skills, expression =>
            {
                expression.MapFrom(src => src.Skills);
            });
    }
}