using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Feedbacks;

public class CreateFeedbackCommand : IRequest<FeedbackResponse>
{
    private readonly FeedbackDto _feedback;

    public CreateFeedbackCommand(FeedbackDto feedback)
    {
        _feedback = feedback;
    }

    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, FeedbackResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFeedbackCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Feedback>(request);
            await _unitOfWork.FeedbackRepository.AddAsync(feedback);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<FeedbackResponse>(feedback);
        }
    }
}