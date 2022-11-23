using AutoMapper;
using Domain.Models;
using Persistence.Entities;

namespace Persistence.MappingProfiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryEntity>(MemberList.Source)
            .ForMember(dst => dst.Id, expression => expression.Ignore())
            .ForMember(dst => dst.Advertisements, expression => { expression.MapFrom(src => src.Advertisements); })
            .ReverseMap();
    }
}