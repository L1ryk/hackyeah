namespace WebAPI.Models.Paginations;

/// <summary>
/// Represents a paginated result.
/// </summary>
/// <typeparam name="T">Paginated data type.</typeparam>
public class PaginatedResult< T >
{
    /// <summary>
    /// Total items count.
    /// </summary>
    public long ItemCount { get; set; }
    
    /// <summary>
    /// Result items.
    /// </summary>
    public IEnumerable< T > Items { get; set; }
}