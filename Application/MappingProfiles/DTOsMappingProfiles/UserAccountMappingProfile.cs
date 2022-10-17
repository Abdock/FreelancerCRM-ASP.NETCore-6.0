using Application.DTOs;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class UserAccountMappingProfile : Profile
{
    public UserAccountMappingProfile()
    {
        CreateMap<UserAccountDto, UserAccount>(MemberList.Destination);
    }
}