using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Advertisements;

public class GetAdvertisementByIdQuery : IRequest<AdvertisementResponse>
{
    private readonly Guid _id;

    public GetAdvertisementByIdQuery(Guid id)
    {
        _id = id;
    }

    public class GetAdvertisementByIdQueryHandler : IRequestHandler<GetAdvertisementByIdQuery, AdvertisementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdvertisementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AdvertisementResponse> Handle(GetAdvertisementByIdQuery request, CancellationToken cancellationToken)
        {
            var advertisement = await _unitOfWork.AdvertisementRepository.GetByIdAsync(request._id);
            var client = await _unitOfWork.AdvertisementRepository.GetClientOfAdvertisementAsync(advertisement);
            var category = await _unitOfWork.AdvertisementRepository.GetCategoryOfAdvertisementAsync(advertisement);
            advertisement.Category = category;
            advertisement.Client = client;
            return _mapper.Map<AdvertisementResponse>(advertisement);
        }
    }
}