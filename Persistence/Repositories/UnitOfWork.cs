using AutoMapper;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CrmContext _context;

    public UnitOfWork(CrmContext context, IMapper mapper)
    {
        _context = context;
        ClientRepository = new ClientRepository(context);
        AdvertisementRepository = new AdvertisementRepository(context);
        CategoryRepository = new CategoryRepository(context);
        FeedbackRepository = new FeedbackRepository(context);
        FreelancerRepository = new FreelancerRepository(context);
        OrderRepository = new OrderRepository(context);
        SkillRepository = new SkillRepository(context);
    }

    public IAdvertisementRepository AdvertisementRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IClientRepository ClientRepository { get; }
    public IFeedbackRepository FeedbackRepository { get; }
    public IFreelancerRepository FreelancerRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public ISkillRepository SkillRepository { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}