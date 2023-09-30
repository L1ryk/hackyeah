using WebAPI.Models.Paginations;

namespace WebAPI.Models.Queries;

public class MeetTagQuery : Pagination
{
    public string Part { get; set; }
}