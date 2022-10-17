using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class FeedbackMappingProfile : Profile
{
    public FeedbackMappingProfile()
    {
        CreateMap<FeedbackDto, Feedback>(MemberList.Source)
            .ForMember(dst => dst.Client, expression =>
            {
                expression.MapFrom(src => src.Client);
            })
            .ForMember(dst => dst.Freelancer, expression =>
            {
                expression.MapFrom(src => src.Freelancer);
            })
            .ForMember(dst => dst.Order, expression =>
            {
                expression.MapFrom(src => src.Order);
            });
    }
}