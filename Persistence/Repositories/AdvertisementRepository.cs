using Application.Responses;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class AdvertisementRepository : RepositoryBase<Advertisement>,
    IAdvertisementRepository
{
    public AdvertisementRepository(CrmContext context) : base(context)
    {
    }

    public async Task<Category> GetCategoryOfAdvertisementAsync(Advertisement advertisement)
    {
        var entity = await Context.Advertisements
            .Include(e => e.Category)
            .Where(ad => ad.Id == advertisement.Id)
            .Select(ad => ad.Category)
            .FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new ResourceNotFoundException($"Category of advertisement with id {advertisement.Id} not found");
        }

        return entity;
    }

    public async Task<Client> GetClientOfAdvertisementAsync(Advertisement advertisement)
    {
        var entity = await Context.Advertisements
            .Include(e => e.Client)
            .Where(ad => ad.Id == advertisement.Id)
            .Select(ad => ad.Client)
            .FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new ResourceNotFoundException($"Client of advertisement with id {advertisement.Id} not found");
        }

        return entity;
    }

    public async Task<IEnumerable<Skill>> GetSkillsFromAdvertisementAsync(Advertisement entity)
    {
        var advertisement = await Context.Advertisements
            .Include(ad => ad.Skills)
            .FirstOrDefaultAsync(ad => ad.Id == entity.Id);
        if (advertisement == null)
        {
            throw new ResourceNotFoundException(nameof(Advertisement), entity.Id);
        }

        return advertisement.Skills;
    }

    public async Task<Order> GetOrderOfAdvertisementAsync(Advertisement entity)
    {
        var order = await Context.Orders
            .Include(order => order.Advertisement)
            .FirstOrDefaultAsync(order => order.Advertisement.Id == entity.Id);
        if (order == null)
        {
            throw new ResourceNotFoundException(nameof(Advertisement), entity.Id);
        }

        return order;
    }
}