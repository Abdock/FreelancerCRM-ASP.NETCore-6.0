using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderResponse>(MemberList.Destination)
            .ForMember(dst => dst.Freelancer, expression =>
            {
                expression.MapFrom(src => src.Freelancer);
            })
            .ForMember(dst => dst.Advertisement, expression =>
            {
                expression.MapFrom(src => src.Advertisement);
            })
            .ForMember(dst => dst.Status, expression =>
            {
                expression.MapFrom(src => src.Status.ToString());
            });
    }
}