using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class ClientMappingProfile : Profile
{
    public ClientMappingProfile()
    {
        CreateMap<Client, ClientResponse>(MemberList.Source)
            .ForMember(dst => dst.Account, expression => { expression.MapFrom(src => src.Account); });
    }
}