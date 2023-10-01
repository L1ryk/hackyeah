using WebAPI.Models.Paginations;

namespace WebAPI.Models.Queries;

/// <summary>
/// Represents a partial data used to suggest tag dynamically.
/// </summary>
public class MeetTagQuery : Pagination
{
    /// <summary>
    /// Part of the tag name.
    /// </summary>
    public string Part { get; set; }
}