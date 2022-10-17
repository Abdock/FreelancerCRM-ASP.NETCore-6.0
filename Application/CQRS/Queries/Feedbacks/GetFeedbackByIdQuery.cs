using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Feedbacks;

public class GetFeedbackByIdQuery : IRequest<FeedbackResponse>
{
    private readonly Guid _id;

    public GetFeedbackByIdQuery(Guid id)
    {
        _id = id;
    }
    
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, FeedbackResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFeedbackByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FeedbackResponse> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _unitOfWork.FeedbackRepository.GetByIdAsync(request._id);
            return _mapper.Map<FeedbackResponse>(feedback);
        }
    }
}