using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Categories;

public class DeleteCategoryCommand : IRequest
{
    private readonly Guid _id;

    public DeleteCategoryCommand(Guid id)
    {
        _id = id;
    }

    public class DeletedCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletedCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CategoryRepository.RemoveAsync(request._id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}