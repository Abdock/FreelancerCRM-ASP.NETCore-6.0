using Application.Responses;
using Application.Services.PaginationServices;
using Application.Services.UriServices;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Clients;

public class GetClientsQuery : IRequest<PagedResponse<ClientResponse>>
{
    private readonly string _route;
    private readonly PaginationFilter _validFilter;

    public GetClientsQuery(PaginationFilter validFilter, string route)
    {
        _validFilter = validFilter;
        _route = route;
    }

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, PagedResponse<ClientResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUriService _uriService;

        public GetClientsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IPaginationService paginationService,
            IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
            _uriService = uriService;
        }

        public async Task<PagedResponse<ClientResponse>> Handle(GetClientsQuery request,
            CancellationToken cancellationToken)
        {
            var skipCount = (request._validFilter.PageNumber - 1) * request._validFilter.PageSize;
            var clients = await _unitOfWork
                .ClientRepository
                .GetRangeAsync(skipCount, request._validFilter.PageSize);
            var response = clients
                .Select(client => _mapper.Map<ClientResponse>(client))
                .ToList();
            var totalClientsCount = await _unitOfWork
                .ClientRepository
                .TotalCountAsync();
            var pagedResponse = _paginationService
                .CreatePagedResponse(response, request._validFilter, request._route, totalClientsCount, _uriService);
            return pagedResponse;
        }
    }
}