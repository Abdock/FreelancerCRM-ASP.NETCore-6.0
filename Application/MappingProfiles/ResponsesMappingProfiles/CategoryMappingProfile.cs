using Application.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.ResponsesMappingProfiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryResponse>(MemberList.Destination);
    }
}