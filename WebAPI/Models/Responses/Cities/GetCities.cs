using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Cities;

public class GetCities : Pagination
{
    public Guid VoivodeshipId { get; set; }
}