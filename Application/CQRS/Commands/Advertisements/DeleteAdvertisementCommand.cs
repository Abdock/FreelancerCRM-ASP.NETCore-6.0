using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Advertisements;

public class DeleteAdvertisementCommand : IRequest
{
    private readonly Guid _id;

    public DeleteAdvertisementCommand(Guid id)
    {
        _id = id;
    }
    
    public class DeleteAdvertisementCommandHandler : IRequestHandler<DeleteAdvertisementCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdvertisementCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.AdvertisementRepository.RemoveAsync(request._id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}