using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Clients;

public class DeleteClientCommand : IRequest
{
    private readonly Guid _rowGuid;

    public DeleteClientCommand(Guid rowGuid)
    {
        _rowGuid = rowGuid;
    }

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ClientRepository.RemoveAsync(request._rowGuid);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}