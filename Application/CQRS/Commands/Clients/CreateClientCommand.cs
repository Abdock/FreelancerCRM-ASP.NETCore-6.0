using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Clients;

public class CreateClientCommand : IRequest<ClientResponse>
{
    private readonly ClientDto _clientDto;

    public CreateClientCommand(ClientDto clientDto)
    {
        _clientDto = clientDto;
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request._clientDto);
            await _unitOfWork.ClientRepository.AddAsync(client);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ClientResponse>(client);
        }
    }
}