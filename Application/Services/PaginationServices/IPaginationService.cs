using Application.Services.UriServices;

namespace Application.Services.PaginationServices;

public interface IPaginationService
{
    PagedResponse<TEntity> CreatePagedResponse<TEntity>(IEnumerable<TEntity> collection, PaginationFilter validFilter,
        string route, int totalCount, IUriService uriService);
}