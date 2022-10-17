using Application.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Advertisements;

public class UpdateAdvertisementCommand : IRequest
{
    private readonly Guid _id;
    private readonly AdvertisementDto _advertisement;

    public UpdateAdvertisementCommand(Guid id, AdvertisementDto advertisement)
    {
        _id = id;
        _advertisement = advertisement;
    }

    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdvertisementCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var advertisement = await _unitOfWork.AdvertisementRepository.GetByIdAsync(request._id);
            advertisement.Deadline = request._advertisement.Deadline;
            advertisement.Title = request._advertisement.Title;
            advertisement.Description = request._advertisement.Description;
            advertisement.Price = request._advertisement.Price;
            await _unitOfWork.AdvertisementRepository.UpdateAsync(advertisement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}