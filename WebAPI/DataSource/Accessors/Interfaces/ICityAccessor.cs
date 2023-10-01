using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Cities;

namespace WebAPI.DataSource.Accessors.Interfaces;

public interface ICityAccessor
{
    Task<GetAllCitiesResponse> GetAllCitiesAsync( Pagination pagination );
    Task<GetAllCitiesResponse> GetCitiesAsync( GetCities getCities );
    Task<GetAllCitiesResponse> SearchCitiesAsync( SearchCities searchCities );
}