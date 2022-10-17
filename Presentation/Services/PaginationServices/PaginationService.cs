using Application.Services.PaginationServices;
using Application.Services.UriServices;

namespace Presentation.Services.PaginationServices;

public class PaginationService : IPaginationService
{
    public PagedResponse<TEntity> CreatePagedResponse<TEntity>(IEnumerable<TEntity> collection,
        PaginationFilter validFilter, string route,
        int totalCount, IUriService uriService)
    {
        var presets = new PaginationPresets
        {
            Filter = validFilter,
            TotalRecords = totalCount,
            Route = route,
            UriService = uriService
        };
        return new PagedResponse<TEntity>(collection, presets);
    }
}