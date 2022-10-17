using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class FeedbackRepository : RepositoryBase<Feedback, FeedbackEntity>, IFeedbackRepository
{
    public FeedbackRepository(CrmContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Order> GetOrderFromFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Order)
            .FirstOrDefaultAsync(fb => fb.RowGuid == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return Mapper.Map<Order>(entity.Order);
    }

    public async Task<Client> GetAuthorOfFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Client)
            .FirstOrDefaultAsync(fb => fb.RowGuid == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return Mapper.Map<Client>(entity.Client);
    }

    public async Task<Freelancer> GetFreelancerOfFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Freelancer)
            .FirstOrDefaultAsync(fb => fb.RowGuid == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return Mapper.Map<Freelancer>(feedback.Freelancer);
    }

    public async Task<Advertisement> GetAdvertisementFromFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Order)
            .ThenInclude(order => order.Advertisement)
            .FirstOrDefaultAsync(fb => fb.RowGuid == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return Mapper.Map<Advertisement>(feedback.Order.Advertisement);
    }

    public async Task AddAsync(Feedback feedback)
    {
        var client = await Context.Clients
            .FirstOrDefaultAsync(client => client.RowGuid == feedback.Client.Id);
        if (client == null)
        {
            throw new ResourceNotFoundException(nameof(Client), feedback.Client.Id);
        }

        var freelancer = await Context.Freelancers
            .FirstOrDefaultAsync(freelancer => freelancer.RowGuid == feedback.Freelancer.Id);
        if (freelancer == null)
        {
            throw new ResourceNotFoundException(nameof(Freelancer), feedback.Freelancer.Id);
        }

        var order = await Context.Orders
            .FirstOrDefaultAsync(order => order.RowGuid == feedback.Order.Id);
        if (order == null)
        {
            throw new ResourceNotFoundException(nameof(Order), feedback.Order.Id);
        }

        var entity = Mapper.Map<FeedbackEntity>(feedback);
        entity.Client = client;
        entity.Freelancer = freelancer;
        entity.Order = order;
        entity.ClientId = client.Id;
        entity.FreelancerId = freelancer.Id;
        entity.OrderId = order.Id;
        await Context.Feedbacks.AddAsync(entity);
    }
}