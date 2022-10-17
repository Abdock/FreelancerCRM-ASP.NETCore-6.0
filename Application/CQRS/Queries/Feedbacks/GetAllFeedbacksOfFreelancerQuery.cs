using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Feedbacks;

public class GetAllFeedbacksOfFreelancerQuery : IRequest<IEnumerable<FeedbackResponse>>
{
    private readonly Guid _freelancerId;

    public GetAllFeedbacksOfFreelancerQuery(Guid freelancerId)
    {
        _freelancerId = freelancerId;
    }

    public class GetAllFeedbacksOfFreelancerQueryHandler : IRequestHandler<GetAllFeedbacksOfFreelancerQuery,
            IEnumerable<FeedbackResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllFeedbacksOfFreelancerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackResponse>> Handle(GetAllFeedbacksOfFreelancerQuery request,
            CancellationToken cancellationToken)
        {
            var feedbacks = await _unitOfWork.FreelancerRepository.GetFeedbacksOfFreelancerAsync(request._freelancerId);
            var response = feedbacks.Select(feedback => _mapper.Map<FeedbackResponse>(feedback)).ToList();
            return response;
        }
    }
}