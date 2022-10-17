using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Freelancers;

public class CreateFreelancerCommand : IRequest<FreelancerResponse>
{
    private readonly FreelancerDto _freelancer;

    public CreateFreelancerCommand(FreelancerDto freelancer)
    {
        _freelancer = freelancer;
    }
    
    public class CreateFreelancerCommandHandler : IRequestHandler<CreateFreelancerCommand, FreelancerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFreelancerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FreelancerResponse> Handle(CreateFreelancerCommand request,
            CancellationToken cancellationToken)
        {
            var freelancer = _mapper.Map<Freelancer>(request._freelancer);
            await _unitOfWork.FreelancerRepository.AddAsync(freelancer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<FreelancerResponse>(freelancer);
        }
    }
}