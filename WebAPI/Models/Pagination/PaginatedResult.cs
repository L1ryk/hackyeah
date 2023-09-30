namespace WebAPI.Models.Pagination;

public class PaginatedResult< T >
{
    public long ItemCount { get; set; }
    public IEnumerable< T > Items { get; set; }
}