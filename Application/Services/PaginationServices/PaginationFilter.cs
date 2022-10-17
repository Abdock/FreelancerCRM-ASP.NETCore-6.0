namespace Application.Services.PaginationServices;

public class PaginationFilter
{
    private readonly int _pageNumber;
    private readonly int _pageSize;

    public PaginationFilter()
    {
        _pageNumber = 1;
        _pageSize = 50;
    }

    public PaginationFilter(int pageNumber, int pageSize)
    {
        _pageSize = Math.Min(50, pageSize);
        _pageNumber = Math.Max(1, pageNumber);
    }

    public int PageNumber
    {
        get => _pageNumber;
        init => _pageNumber = Math.Max(1, value);
    }

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = Math.Min(50, value);
    }
}