using Application.Services.PaginationServices;

namespace Application.Services.UriServices;

public interface IUriService
{
    Uri GetPageUri(PaginationFilter filter, string route);
}