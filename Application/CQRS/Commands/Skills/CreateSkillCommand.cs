using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Skills;

public class CreateSkillCommand : IRequest<SkillResponse>
{
    private readonly NewSkillDto _newSkill;

    public CreateSkillCommand(NewSkillDto newSkill)
    {
        _newSkill = newSkill;
    }
    
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, SkillResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SkillResponse> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<Skill>(request._newSkill);
            await _unitOfWork.SkillRepository.AddAsync(skill);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<SkillResponse>(skill);
        }
    }
}