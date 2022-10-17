using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class OrderRepository : RepositoryBase<Order, OrderEntity>, IOrderRepository
{
    public OrderRepository(CrmContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Client> GetClientOfOrderAsync(Order order)
    {
        var entity = await Context.Orders
            .Include(ord => ord.Advertisement)
            .ThenInclude(ad => ad.Client)
            .FirstOrDefaultAsync(ord => ord.RowGuid == order.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Order), order.Id);
        }

        return Mapper.Map<Client>(entity.Advertisement.Client);
    }

    public async Task<Freelancer> GetFreelancerOfOrderAsync(Order order)
    {
        var entity = await Context.Orders
            .Include(ord => ord.Freelancer)
            .FirstOrDefaultAsync(ord => ord.RowGuid == order.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Order), order.Id);
        }

        return Mapper.Map<Freelancer>(entity.Freelancer);
    }

    public async Task<IEnumerable<Feedback>> GetFeedbacksFromOrderAsync(Order order)
    {
        return await Context.Orders
            .Include(ord => ord.Feedbacks)
            .Where(ord => ord.RowGuid == order.Id)
            .SelectMany(ord => ord.Feedbacks)
            .ProjectTo<Feedback>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        var advertisement = await Context.Advertisements
                .FirstOrDefaultAsync(ad => ad.RowGuid == order.Advertisement.Id);
        if (advertisement == null)
        {
            throw new ResourceNotFoundException(nameof(Advertisement), order.Advertisement.Id);
        }

        var freelancer = await Context.Freelancers
            .FirstOrDefaultAsync(freelancer => freelancer.RowGuid == order.Freelancer.Id);
        if (freelancer == null)
        {
            throw new ResourceNotFoundException(nameof(Freelancer), order.Freelancer.Id);
        }

        var entity = Mapper.Map<OrderEntity>(order);
        entity.AdvertisementId = advertisement.Id;
        entity.Advertisement = advertisement;
        entity.FreelancerId = freelancer.Id;
        entity.Freelancer = freelancer;

        await Context.Orders.AddAsync(entity);
    }
}