using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Skills;

public class GetSkillByIdQuery : IRequest<SkillResponse>
{
    private readonly Guid _id;

    public GetSkillByIdQuery(Guid id)
    {
        _id = id;
    }

    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSkillByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SkillResponse> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _unitOfWork.SkillRepository.GetByIdAsync(request._id);
            return _mapper.Map<SkillResponse>(skill);
        }
    }
}