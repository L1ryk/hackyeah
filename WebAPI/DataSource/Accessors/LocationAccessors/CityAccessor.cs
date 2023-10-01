using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Cities;

namespace WebAPI.DataSource.Accessors.LocationAccessors;

public class CityAccessor : ICityAccessor
{
    private readonly ApiDbContext _dbContext;

    public CityAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllCitiesResponse> GetAllCitiesAsync( Pagination pagination )
    {
        var query = await QueryHelper.GetPaginatedQuery<City>( pagination, _dbContext );

        return new GetAllCitiesResponse { Items = query.Result, ItemCount = query.ItemsCount };
    }

    public async Task<GetAllCitiesResponse> GetCitiesAsync( GetCities getCities )
    {
        Guard.IsNotNull( getCities );

        var query = _dbContext.Cities.Where( c => c.Voivodeship.Id == getCities.VoivodeshipId );

        var res = await query.GetPaginatedQuery( getCities, _dbContext );

        return new GetAllCitiesResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }

    public async Task<GetAllCitiesResponse> SearchCitiesAsync( SearchCities searchCities )
    {
        var part = searchCities.Part.ToLower();

        var occupationsQuery = _dbContext.Cities
            .Where( t => t.Name.ToLower().Contains( part ) )
            .OrderByDescending( t => t.Name.ToLower().StartsWith( part ) );

        var res = await occupationsQuery.GetPaginatedQuery( searchCities, _dbContext );

        return new GetAllCitiesResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }
}