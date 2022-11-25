using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(CrmContext context) : base(context)
    {
    }

    public async Task<Client> GetClientOfOrderAsync(Order order)
    {
        var entity = await Context.Orders
            .Include(ord => ord.Advertisement)
            .ThenInclude(ad => ad.Client)
            .FirstOrDefaultAsync(ord => ord.Id == order.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Order), order.Id);
        }

        return entity.Advertisement.Client;
    }

    public async Task<Freelancer> GetFreelancerOfOrderAsync(Order order)
    {
        var entity = await Context.Orders
            .Include(ord => ord.Freelancer)
            .FirstOrDefaultAsync(ord => ord.Id == order.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Order), order.Id);
        }

        return entity.Freelancer;
    }

    public async Task<IEnumerable<Feedback>> GetFeedbacksFromOrderAsync(Order order)
    {
        return await Context.Orders
            .Include(ord => ord.Feedbacks)
            .Where(ord => ord.Id == order.Id)
            .SelectMany(ord => ord.Feedbacks)
            .ToListAsync();
    }
}