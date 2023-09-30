namespace WebAPI.Models.Paginations;

public class PaginatedResult< T >
{
    public long ItemCount { get; set; }
    public IEnumerable< T > Items { get; set; }
}