using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Universities;

public class GetUniversities : Pagination
{
    public List<Filter> Filters { get; set; }
}