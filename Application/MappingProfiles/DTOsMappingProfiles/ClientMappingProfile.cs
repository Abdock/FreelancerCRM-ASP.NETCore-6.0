using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class ClientMappingProfile : Profile
{
    public ClientMappingProfile()
    {
        CreateMap<ClientDto, Client>(MemberList.Destination)
            .ForMember(dst => dst.Account, expression => { expression.MapFrom(src => src.Account); });
    }
}