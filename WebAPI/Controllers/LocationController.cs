using Microsoft.AspNetCore.Mvc;
using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses;
using WebAPI.Models.Responses.Cities;
using WebAPI.Models.Responses.Locations;
using WebAPI.Models.Responses.Voivodeships;

namespace WebAPI.Controllers;

[ Route( "api/location" ) ]
public class LocationController : Controller
{
    private readonly ICityAccessor _cityAccessor;
    private readonly IVoivodeshipAccessor _voivodeshipAccessor;

    public LocationController( ICityAccessor cityAccessor, IVoivodeshipAccessor voivodeshipAccessor )
    {
        Guard.IsNotNull( cityAccessor );
        Guard.IsNotNull( voivodeshipAccessor );

        _cityAccessor = cityAccessor;
        _voivodeshipAccessor = voivodeshipAccessor;
    }

    [ HttpGet( "cities" ) ]
    public async Task<ActionResult> Get( [ FromQuery ] Pagination pagination ) =>
        await ErrorHandler.HandlerAsync(
            async () =>
            {
                Guard.IsNotNull( pagination );

                var cities = await _cityAccessor.GetAllCitiesAsync( pagination );

                return Ok( new Response<PaginatedResult<City>>
                {
                    IsSuccess = true,
                    Result = new PaginatedResult<City> { Items = cities.Items, ItemCount = cities.ItemCount }
                } );
            } );

    [ HttpPost( "cities" ) ]
    public async Task<ActionResult> Get( [ FromBody ] GetCities getCities ) =>
        await ErrorHandler.HandlerAsync(
            async () =>
            {
                Guard.IsNotNull( getCities );

                var cities = await _cityAccessor.GetCitiesAsync( getCities );

                return Ok( new Response<PaginatedResult<City>>
                {
                    IsSuccess = true,
                    Result = new PaginatedResult<City> { Items = cities.Items, ItemCount = cities.ItemCount }
                } );
            } );

    [ HttpPost( "search_cities" ) ]
    public async Task<ActionResult> Get( [ FromBody ] SearchCities searchCities ) =>
        await ErrorHandler.HandlerAsync(
            async () =>
            {
                Guard.IsNotNull( searchCities );

                if ( searchCities.Part.Length < 3 )
                    return NoContent();

                var cities = await _cityAccessor.SearchCitiesAsync( searchCities );

                return Ok( new Response<PaginatedResult<City>>
                {
                    IsSuccess = true,
                    Result = new PaginatedResult<City> { Items = cities.Items, ItemCount = cities.ItemCount }
                } );
            } );

    [ HttpGet( "voivodeships" ) ]
    public async Task<ActionResult> GetVoivodeships( [ FromQuery ] Pagination pagination ) =>
        await ErrorHandler.HandlerAsync(
            async () =>
            {
                Guard.IsNotNull( pagination );

                var voivodeships = await _voivodeshipAccessor.GetAllVoivodeshipsAsync( pagination );

                return Ok( new Response<PaginatedResult<Voivodeship>>
                {
                    IsSuccess = true,
                    Result = new PaginatedResult<Voivodeship>
                    {
                        Items = voivodeships.Items, ItemCount = voivodeships.ItemCount
                    }
                } );
            } );

    [ HttpPost( "voivodeships" ) ]
    public async Task<IActionResult> GetVoivodeships( [ FromBody ] GetVoivodeships getVoivodeships ) =>
        await ErrorHandler.HandlerAsync(
            async () =>
            {
                Guard.IsNotNull( getVoivodeships );

                var voivodeships = await _voivodeshipAccessor.GetAllVoivodeshipsAsync( getVoivodeships );

                return Ok( new Response<PaginatedResult<Voivodeship>>
                {
                    IsSuccess = true,
                    Result = new PaginatedResult<Voivodeship>
                    {
                        Items = voivodeships.Items, ItemCount = voivodeships.ItemCount
                    }
                } );
            } );

    [HttpPost("getdistance")]
    public async Task<IActionResult> GetDistance( [ FromBody ] DistanceQuery distanceQuery ) =>
        await ErrorHandler.HandlerAsync( 
            async () =>
            {
                Guard.IsNotNull( distanceQuery );
                Guard.IsNotNull( distanceQuery.First );
                Guard.IsNotNull( distanceQuery.Second );

                double x = 69.1 * (distanceQuery.Second.Latitude - distanceQuery.First.Latitude);
                double y = 69.1 * (distanceQuery.Second.Longitude - distanceQuery.First.Longitude)
                                * Math.Cos(distanceQuery.First.Latitude / 57.3);

                const float milesToKmMultiplier = 1.609344f;
                var distanceKm = (Math.Sqrt(x * x + y * y) * milesToKmMultiplier);
                
                return Ok(new Response<GetDistanceResponse>()
                {
                    IsSuccess = true,
                    Result = new GetDistanceResponse
                    {
                        Distance = distanceKm
                    }
                });
            } );
}