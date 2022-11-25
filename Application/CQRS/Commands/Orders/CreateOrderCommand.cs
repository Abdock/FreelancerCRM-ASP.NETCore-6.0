using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Orders;

public class CreateOrderCommand : IRequest<OrderResponse>
{
    private readonly OrderDto _order;

    public CreateOrderCommand(OrderDto order)
    {
        _order = order;
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var freelancer = await _unitOfWork.FreelancerRepository.GetByIdAsync(request._order.FreelancerId);
            var advertisement = await _unitOfWork.AdvertisementRepository.GetByIdAsync(request._order.AdvertisementId);
            var order = new Order
            {
                Freelancer = freelancer,
                Advertisement = advertisement,
                Status = OrderStatusId.InProgress
            };
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OrderResponse>(order);
        }
    }
}