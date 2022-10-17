namespace Application.Services.PaginationServices;

public class PagedResponse<TResponse>
{
    public PagedResponse(IEnumerable<TResponse> collection, PaginationPresets presets)
    {
        var validFilter = presets.Filter;
        var uriService = presets.UriService;
        PageNumber = validFilter.PageNumber;
        PageSize = validFilter.PageSize;
        TotalRecords = presets.TotalRecords;
        TotalPages = (presets.TotalRecords + PageSize - 1) / PageSize;
        if (PageNumber >= 1 && PageNumber < TotalPages)
        {
            NextPage = uriService.GetPageUri(new PaginationFilter(PageNumber + 1, PageSize), presets.Route);
        }
        else
        {
            NextPage = null;
        }

        if (PageNumber > 1 && PageNumber <= TotalPages)
        {
            PreviousPage = uriService.GetPageUri(new PaginationFilter(PageNumber - 1, PageSize), presets.Route);
        }
        else
        {
            PreviousPage = null;
        }

        FirstPage = uriService.GetPageUri(new PaginationFilter(1, PageSize), presets.Route);
        LastPage = uriService.GetPageUri(new PaginationFilter(TotalPages, PageSize), presets.Route);
        Collection = collection.Take(PageSize);
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Uri FirstPage { get; set; }
    public Uri LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public Uri? NextPage { get; set; }
    public Uri? PreviousPage { get; set; }
    public IEnumerable<TResponse> Collection { get; set; }
}