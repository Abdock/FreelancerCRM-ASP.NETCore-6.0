using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Orders;

public class GetAllOrdersOfFreelancerQuery : IRequest<IEnumerable<OrderResponse>>
{
    private readonly Guid _freelancerId;

    public GetAllOrdersOfFreelancerQuery(Guid freelancerId)
    {
        _freelancerId = freelancerId;
    }
    
    public class GetAllOrdersOfFreelancerQueryHandler : IRequestHandler<GetAllOrdersOfFreelancerQuery, IEnumerable<OrderResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersOfFreelancerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetAllOrdersOfFreelancerQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.FreelancerRepository.GetOrdersOfFreelancerAsync(request._freelancerId);
            var response = orders.Select(order => _mapper.Map<OrderResponse>(order)).ToList();
            return response;
        }
    }
}