using WebAPI.Models.Paginations;

namespace WebAPI.Models.Queries;

/// <summary>
/// Represents a partial data used to suggest occupations dynamically.
/// </summary>
public class MeetOccupationQuery : Pagination
{
    /// <summary>
    /// Part of the occupation name.
    /// </summary>
    public string Part { get; set; } = String.Empty;
}