using Application.Services.PaginationServices;
using Application.Services.UriServices;
using Application.ShortResponses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Advertisements;

public class GetAdvertisementsQuery : IRequest<PagedResponse<AdvertisementShortResponse>>
{
    private readonly PaginationFilter _filter;
    private readonly string _route;

    public GetAdvertisementsQuery(PaginationFilter filter, string route)
    {
        _filter = filter;
        _route = route;
    }

    public class GetAdvertisementsQueryHandler :
        IRequestHandler<GetAdvertisementsQuery, PagedResponse<AdvertisementShortResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IPaginationService _paginationService;

        public GetAdvertisementsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUriService uriService,
            IPaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uriService = uriService;
            _paginationService = paginationService;
        }

        public async Task<PagedResponse<AdvertisementShortResponse>> Handle(GetAdvertisementsQuery request,
            CancellationToken cancellationToken)
        {
            var skipCount = (request._filter.PageNumber - 1) * request._filter.PageSize;
            var advertisements = await _unitOfWork.AdvertisementRepository
                .GetRangeAsync(skipCount, request._filter.PageSize);
            var response = advertisements
                .Select(advertisement => _mapper.Map<AdvertisementShortResponse>(advertisement))
                .ToList();
            var totalCount = await _unitOfWork.AdvertisementRepository.TotalCountAsync();
            var pagedResponse = _paginationService
                .CreatePagedResponse(response, request._filter, request._route, totalCount, _uriService);
            return pagedResponse;
        }
    }
}