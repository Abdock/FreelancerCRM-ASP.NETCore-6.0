using AutoMapper;
using Domain.Models;
using Persistence.Entities;

namespace Persistence.MappingProfiles;

public class ClientMappingProfile : Profile
{
    public ClientMappingProfile()
    {
        CreateMap<Client, ClientEntity>(MemberList.Source)
            .ForMember(dst => dst.Id, expression => expression.Ignore())
            .ForMember(dst => dst.Account, expression => { expression.MapFrom(src => src.Account); })
            .ForMember(dst => dst.Feedbacks, expression => { expression.MapFrom(src => src.Feedbacks); })
            .ForMember(dst => dst.Orders, expression => { expression.MapFrom(src => src.Orders); })
            .ReverseMap();
    }
}