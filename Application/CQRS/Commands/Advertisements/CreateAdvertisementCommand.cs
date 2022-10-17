using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Advertisements;

public class CreateAdvertisementCommand : IRequest<AdvertisementResponse>
{
    private readonly AdvertisementDto _advertisement;

    public CreateAdvertisementCommand(AdvertisementDto advertisement)
    {
        _advertisement = advertisement;
    }

    public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, AdvertisementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAdvertisementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AdvertisementResponse> Handle(CreateAdvertisementCommand request,
            CancellationToken cancellationToken)
        {
            var advertisement = _mapper.Map<Advertisement>(request._advertisement);
            advertisement.Category = await _unitOfWork.CategoryRepository
                .GetByIdAsync(request._advertisement.CategoryId);
            advertisement.Client = await _unitOfWork.ClientRepository
                .GetByIdAsync(request._advertisement.ClientId);
            advertisement.Status = AdvertisementStatus.Open;
            await _unitOfWork.AdvertisementRepository.AddAsync(advertisement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AdvertisementResponse>(advertisement);
        }
    }
}