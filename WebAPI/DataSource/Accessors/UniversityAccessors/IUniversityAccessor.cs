using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Universities;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public interface IUniversityAccessor
{
    Task<GetAllUniversityResponse> GetAllUniversitiesAsync( Pagination pagination );
}