using Application.Responses;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Clients;

public class GetClientByIdQuery : IRequest<ClientResponse>
{
    private readonly Guid _id;

    public GetClientByIdQuery(Guid id)
    {
        _id = id;
    }

    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClientResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(request._id);
            return _mapper.Map<ClientResponse>(client);
        }
    }
}