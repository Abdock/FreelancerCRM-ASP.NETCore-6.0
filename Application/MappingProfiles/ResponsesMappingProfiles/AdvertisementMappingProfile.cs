using Application.Responses;
using Application.ShortResponses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class AdvertisementMappingProfile : Profile
{
    public AdvertisementMappingProfile()
    {
        MapAdvertisementToResponse();
        MapAdvertisementToShortResponse();
    }

    private void MapAdvertisementToResponse()
    {
        CreateMap<Advertisement, AdvertisementResponse>(MemberList.Destination)
            .ForMember(dst => dst.Client, expression =>
            {
                expression.MapFrom(src => src.Client);
            })
            .ForMember(dst => dst.Category, expression =>
            {
                expression.MapFrom(src => src.Category);
            })
            .ForMember(src => src.Skills, expression =>
            {
                expression.MapFrom(src => src.Skills);
            })
            .ForMember(dst => dst.Status, expression =>
            {
                expression.MapFrom(src => src.Status.ToString());
            });
    }

    private void MapAdvertisementToShortResponse()
    {
        CreateMap<Advertisement, AdvertisementShortResponse>(MemberList.Destination)
            .ForMember(dst => dst.Category, expression =>
            {
                expression.MapFrom(src => src.Category);
            })
            .ForMember(dst => dst.Client, expression =>
            {
                expression.MapFrom(src => src.Client);
            })
            .ForMember(dst=>dst.Status, expression =>
            {
                expression.MapFrom(src=>src.Status.ToString());
            });
    }
}