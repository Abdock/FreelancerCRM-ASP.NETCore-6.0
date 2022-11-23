using Application.Responses;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class AdvertisementRepository : RepositoryBase<Advertisement, AdvertisementEntity>,
    IAdvertisementRepository
{
    public AdvertisementRepository(CrmContext context, IMapper mapper) : base(context, mapper)
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

        return Mapper.Map<Category>(entity);
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

        return Mapper.Map<Client>(entity);
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

        return advertisement.Skills.Select(skill => Mapper.Map<Skill>(skill));
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

        return Mapper.Map<Order>(order);
    }

    public async Task AddAsync(Advertisement advertisement)
    {
        var category = await Context.Categories
            .FirstOrDefaultAsync(category => category.Id == advertisement.Category.Id);
        if (category == null)
        {
            throw new ResourceNotFoundException(nameof(Category), advertisement.Category.Id);
        }

        var client = await Context.Clients
            .FirstOrDefaultAsync(client => client.Id == advertisement.Client.Id);
        if (client == null)
        {
            throw new ResourceNotFoundException(nameof(Client), advertisement.Client.Id);
        }

        var skills = advertisement.Skills.Select(s => s.Id).ToHashSet();

        var createdSkills = await Context.Skills.Where(skill => skills.Contains(skill.Id)).ToListAsync();

        var status = await Context.AdvertisementsStatuses.FirstAsync(s => s.Id == advertisement.Status);

        var entity = Mapper.Map<AdvertisementEntity>(advertisement);
        entity.CategoryId = category.Id;
        entity.Category = category;
        entity.ClientId = client.Id;
        entity.Client = client;
        entity.AdvertisementStatus = status;
        entity.AdvertisementStatusId = status.Id;
        entity.Skills = createdSkills;

        await Context.Advertisements.AddAsync(entity);
    }

    public async Task UpdateAsync(Advertisement advertisement)
    {
        var entity = await Context.Advertisements.FirstOrDefaultAsync(ad => ad.Id == advertisement.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(entity), advertisement.Id);
        }

        entity.Deadline = advertisement.Deadline;
        entity.Description = advertisement.Description;
        entity.Title = advertisement.Title;
        entity.Price = advertisement.Price;
        Context.Advertisements.Update(entity);
    }
}