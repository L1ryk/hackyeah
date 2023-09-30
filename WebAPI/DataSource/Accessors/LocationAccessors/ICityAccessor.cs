using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Cities;

namespace WebAPI.DataSource.Accessors.LocationAccessors;

public interface ICityAccessor
{
    Task<GetAllCitiesResponse> GetAllCitiesAsync( Pagination pagination );
    Task<GetAllCitiesResponse> GetCitiesAsync( GetCities getCities );
}