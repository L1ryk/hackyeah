namespace WebAPI.Models.Paginations;

/// <summary>
/// Base pagination class.
/// </summary>
public class Pagination
{
    /// <summary>
    /// Selected page.
    /// </summary>
    public int Page { get; set; } = 1;
    
    /// <summary>
    /// Max number of items in a single result.
    /// </summary>
    public int Limit { get; set; } = 20;
}