namespace ZenPharm.DAL.Models;

public class PagedResult<T>
{
    public PagedResult(IEnumerable<T> value, int totalPages, int currentPage, int totalItems, int pageSize = 10)
    {
        Value = value;
        TotalPages = totalPages;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
    }

    public IEnumerable<T> Value { get; }
    public int TotalPages { get; }
    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalItems { get; }


}
