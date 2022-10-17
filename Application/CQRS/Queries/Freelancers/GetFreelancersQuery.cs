using Application.Responses;
using Application.Services.PaginationServices;
using Application.Services.UriServices;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Freelancers;

public class GetFreelancersQuery : IRequest<PagedResponse<FreelancerResponse>>
{
    private readonly PaginationFilter _filter;
    private readonly string _route;

    public GetFreelancersQuery(PaginationFilter filter, string route)
    {
        _filter = filter;
        _route = route;
    }

    public class GetFreelancersQueryHandler : IRequestHandler<GetFreelancersQuery, PagedResponse<FreelancerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IPaginationService _paginationService;

        public GetFreelancersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUriService uriService,
            IPaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uriService = uriService;
            _paginationService = paginationService;
        }

        public async Task<PagedResponse<FreelancerResponse>> Handle(GetFreelancersQuery request, CancellationToken cancellationToken)
        {
            var skipCount = (request._filter.PageNumber - 1) * request._filter.PageSize;
            var freelancers = await _unitOfWork.FreelancerRepository
                .GetRangeAsync(skipCount, request._filter.PageSize);
            var response = freelancers.Select(freelancer => _mapper.Map<FreelancerResponse>(freelancer)).ToList();
            var totalCount = await _unitOfWork.FreelancerRepository.TotalCountAsync();
            return _paginationService
                .CreatePagedResponse(response, request._filter, request._route, totalCount, _uriService);
        }
    }
}