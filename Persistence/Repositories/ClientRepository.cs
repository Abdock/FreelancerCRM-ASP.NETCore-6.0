using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(CrmContext context) : base(context)
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

        return client.Orders;
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

        return client.Feedbacks;
    }
}