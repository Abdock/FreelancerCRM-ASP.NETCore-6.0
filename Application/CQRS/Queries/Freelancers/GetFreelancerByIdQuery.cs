using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Freelancers;

public class GetFreelancerByIdQuery : IRequest<FreelancerResponse>
{
    private readonly Guid _id;

    public GetFreelancerByIdQuery(Guid id)
    {
        _id = id;
    }

    public class GetFreelancerByIdQueryHandler : IRequestHandler<GetFreelancerByIdQuery, FreelancerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFreelancerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FreelancerResponse> Handle(GetFreelancerByIdQuery request, CancellationToken cancellationToken)
        {
            var freelancer = await _unitOfWork.FreelancerRepository.GetByIdAsync(request._id);
            return _mapper.Map<FreelancerResponse>(freelancer);
        }
    }
}