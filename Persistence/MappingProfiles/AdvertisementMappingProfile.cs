using AutoMapper;
using Domain.Models;
using Persistence.Entities;

namespace Persistence.MappingProfiles;

public class AdvertisementMappingProfile : Profile
{
    public AdvertisementMappingProfile()
    {
        CreateMap<Advertisement, AdvertisementEntity>(MemberList.Source)
            .ForMember(dst => dst.Id, expression => expression.Ignore())
            .ForMember(dst=>dst.CategoryId, expression => expression.Ignore())
            .ForMember(dst=>dst.ClientId, expression => expression.Ignore())
            .ForMember(dst => dst.Client, expression => { expression.MapFrom(src => src.Client); })
            .ForMember(dst => dst.RowGuid, expression => { expression.MapFrom(src => src.Id); })
            .ForMember(dst => dst.Skills, expression => { expression.MapFrom(src => src.Skills); })
            .ForMember(dst => dst.AdvertisementStatusId, expression => { expression.MapFrom(src => src.Status); })
            .ForMember(dst => dst.AdvertisementStatus, expression =>
            {
                expression.MapFrom(src => new AdvertisementStatusEntity
                {
                    Id = src.Status,
                    Name = src.Status.ToString()
                });
            })
            .ForMember(dst => dst.CreatedDate, expression => { expression.MapFrom(src => src.CreationDate); })
            .ReverseMap();
    }
}