using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class ClientRepository : RepositoryBase<Client, ClientEntity>, IClientRepository
{
    public ClientRepository(CrmContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<Order>> GetAllOrdersFromClientAsync(Guid id)
    {
        var client = await Context.Clients
            .Include(client => client.Orders)
            .FirstOrDefaultAsync(client => client.Id == id);
        if (client == null)
        {
            throw new ResourceNotFoundException($"{nameof(Client)}", id);
        }

        return client.Orders.Select(order => Mapper.Map<Order>(order));
    }

    public async Task<IEnumerable<Feedback>> GetAllFeedbacksFromClientAsync(Guid id)
    {
        var client = await Context
            .Clients
            .Include(client => client.Feedbacks)
            .FirstAsync(client => client.Id == id);
        if (client == null)
        {
            throw new ResourceNotFoundException(nameof(Client), id);
        }

        return client.Feedbacks.Select(feedback => Mapper.Map<Feedback>(feedback));
    }

    public async Task AddAsync(Client client)
    {
        var entity = Mapper.Map<ClientEntity>(client);
        await Context.Clients.AddAsync(entity);
    }
}