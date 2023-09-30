namespace WebAPI.Models.Queries;

public class PaginationQuery<T>
{
    public IEnumerable<T> Result { get; set; }

    public long ItemsCount { get; set; }
}