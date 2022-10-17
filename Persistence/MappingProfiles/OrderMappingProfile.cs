using AutoMapper;
using Domain.Models;
using Persistence.Entities;

namespace Persistence.MappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderEntity>(MemberList.Source)
            .ForMember(dst => dst.Id, expression => expression.Ignore())
            .ForMember(dst => dst.RowGuid, expression => { expression.MapFrom(src => src.Id); })
            .ForMember(dst => dst.Advertisement, expression => { expression.MapFrom(src => src.Advertisement); })
            .ForMember(dst => dst.OrderStatusId, expression => { expression.MapFrom(src => src.Status); })
            .ForMember(dst => dst.OrderStatus, expression =>
            {
                expression.MapFrom(src => new OrderStatusEntity
                {
                    Id = src.Status,
                    Name = src.Status.ToString()
                });
            })
            .ForMember(dst => dst.Feedbacks, expression => { expression.MapFrom(src => src.Feedbacks); })
            .ReverseMap();
    }
}