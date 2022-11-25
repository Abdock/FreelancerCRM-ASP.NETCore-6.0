using Application.DTOs;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Categories;

public class UpdateCategoryCommand : IRequest
{
    private readonly Guid _id;
    private readonly CategoryDto _category;

    public UpdateCategoryCommand(Guid id, CategoryDto category)
    {
        _id = id;
        _category = category;
    }
    
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request._id);
            category.Name = request._category.Name;
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}