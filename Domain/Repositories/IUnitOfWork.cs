namespace Domain.Repositories;

public interface IUnitOfWork
{
    IAdvertisementRepository AdvertisementRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IClientRepository ClientRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
    IFreelancerRepository FreelancerRepository { get; }
    IOrderRepository OrderRepository { get; }
    ISkillRepository SkillRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}