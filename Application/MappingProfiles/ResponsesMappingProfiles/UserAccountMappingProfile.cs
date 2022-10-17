using Application.Responses;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class UserAccountMappingProfile : Profile
{
    public UserAccountMappingProfile()
    {
        CreateMap<UserAccount, UserAccountResponse>(MemberList.Source);
    }
}