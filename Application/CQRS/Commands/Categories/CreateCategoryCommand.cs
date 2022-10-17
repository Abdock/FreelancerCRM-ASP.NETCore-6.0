using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Categories;

public class CreateCategoryCommand : IRequest<CategoryResponse>
{
    private readonly CategoryDto _category;

    public CreateCategoryCommand(CategoryDto category)
    {
        _category = category;
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request._category);
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CategoryResponse>(category);
        }
    }
}