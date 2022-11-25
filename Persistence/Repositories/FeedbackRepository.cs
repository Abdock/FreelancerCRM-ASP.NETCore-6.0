using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(CrmContext context) : base(context)
    {
    }

    public async Task<Order> GetOrderFromFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Order)
            .FirstOrDefaultAsync(fb => fb.Id == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return entity.Order;
    }

    public async Task<Client> GetAuthorOfFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Client)
            .FirstOrDefaultAsync(fb => fb.Id == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return entity.Client;
    }

    public async Task<Freelancer> GetFreelancerOfFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Freelancer)
            .FirstOrDefaultAsync(fb => fb.Id == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return entity.Freelancer;
    }

    public async Task<Advertisement> GetAdvertisementFromFeedbackAsync(Feedback feedback)
    {
        var entity = await Context.Feedbacks
            .Include(fb => fb.Order)
            .ThenInclude(order => order.Advertisement)
            .FirstOrDefaultAsync(fb => fb.Id == feedback.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Feedback), feedback.Id);
        }

        return entity.Order.Advertisement;
    }
}