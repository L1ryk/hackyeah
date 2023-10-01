using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Cities;

public class SearchCities : Pagination
{
    public string Part { get; set; }
}