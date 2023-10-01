namespace WebAPI.Models.Queries;

/// <summary>
/// Represents a basic pagination query.
/// </summary>
/// <typeparam name="T">Paginated data type.</typeparam>
public class PaginationQuery<T>
{
    /// <summary>
    /// A collection of result items.
    /// </summary>
    public IEnumerable<T> Result { get; set; }

    /// <summary>
    /// Total items count.
    /// </summary>
    public long ItemsCount { get; set; }
}