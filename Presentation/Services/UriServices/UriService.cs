using Application.Services.PaginationServices;
using Application.Services.UriServices;
using Microsoft.AspNetCore.WebUtilities;

namespace Presentation.Services.UriServices;

public class UriService : IUriService
{
    private readonly string _baseUri;

    public UriService(string baseUri)
    {
        _baseUri = baseUri;
    }

    public Uri GetPageUri(PaginationFilter filter, string route)
    {
        var endpointUri = new Uri(_baseUri + route);
        var resultUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
        resultUri = QueryHelpers.AddQueryString(resultUri, "pageSize", filter.PageSize.ToString());
        return new Uri(resultUri);
    }
}