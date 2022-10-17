using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles.DTOsMappingProfiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryDto, Category>(MemberList.Source);
    }
}