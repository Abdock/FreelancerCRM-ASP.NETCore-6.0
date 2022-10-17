using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class FeedbackMappingProfile : Profile
{
    public FeedbackMappingProfile()
    {
        CreateMap<Feedback, FeedbackResponse>(MemberList.Destination)
            .ForMember(dst => dst.Freelancer, expression =>
            {
                expression.MapFrom(src => src.Freelancer);
            })
            .ForMember(dst => dst.Client, expression =>
            {
                expression.MapFrom(src => src.Client);
            })
            .ForMember(dst => dst.Order, expression =>
            {
                expression.MapFrom(src => src.Order);
            });
    }
}