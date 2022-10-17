using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Skills;

public class GetAllSkillsQuery : IRequest<IEnumerable<SkillResponse>>
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, IEnumerable<SkillResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSkillsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillResponse>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _unitOfWork.SkillRepository.GetAllAsync();
            var response = skills.Select(skill => _mapper.Map<SkillResponse>(skill)).ToList();
            return response;
        }
    }
}