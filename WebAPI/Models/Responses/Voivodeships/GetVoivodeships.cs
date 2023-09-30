using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Voivodeships;

public class GetVoivodeships : Pagination
{
    public Guid Id { get; set; }
}