using Application.Services.UriServices;

namespace Application.Services.PaginationServices;

public class PaginationPresets
{
    public PaginationFilter Filter { get; set; } = default!;
    public int TotalRecords { get; set; }
    public IUriService UriService { get; set; } = default!;
    public string Route { get; set; } = default!;
}