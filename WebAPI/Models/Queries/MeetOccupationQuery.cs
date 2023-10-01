using WebAPI.Models.Paginations;

namespace WebAPI.Models.Queries;

public class MeetOccupationQuery : Pagination
{
    public string Part { get; set; } = String.Empty;
}