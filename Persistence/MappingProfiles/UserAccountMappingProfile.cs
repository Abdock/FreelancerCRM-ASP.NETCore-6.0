using AutoMapper;
using Domain.ValueObjects;
using Persistence.Entities;

namespace Persistence.MappingProfiles;

public class UserAccountMappingProfile : Profile
{
    public UserAccountMappingProfile()
    {
        CreateMap<UserAccount, UserAccountEntity>(MemberList.Source).ReverseMap();
    }
}