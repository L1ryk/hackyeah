using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource;
using WebAPI.DataSource.Accessors;
using WebAPI.DataSource.Accessors.LocationAccessors;
using WebAPI.DataSource.Entities.System;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses;
using WebAPI.Models.Responses.Cities;

namespace WebAPI.Controllers;

[ Route( "api/location" ) ]
public class LocationController : Controller
{
    private readonly ICityAccessor _cityAccessor;

    public LocationController( ICityAccessor cityAccessor )
    {
        Guard.IsNotNull( cityAccessor );

        _cityAccessor = cityAccessor;
    }

    [ HttpGet( "cities" ) ]
    public async Task<IActionResult> Get( [ FromQuery ] Pagination pagination )
    {
        Guard.IsNotNull( pagination );

        var allCities = await _cityAccessor.GetAllCitiesAsync( pagination );

        return Ok( new Response<PaginatedResult<City>>
        {
            IsSuccess = true, Result = new PaginatedResult<City> { Items = allCities.Items, ItemCount = allCities.ItemCount }
        } );
    }

    [ HttpPost( "cities" ) ]
    public async Task<IActionResult> Get( [ FromBody ] GetCities getCities )
    {
        Guard.IsNotNull( getCities );

        var cities = await _cityAccessor.GetAllCitiesAsync( getCities );

        return Ok( new Response<PaginatedResult<City>>
        {
            IsSuccess = true, Result = new PaginatedResult<City> { Items = cities.Items, ItemCount = cities.ItemCount }
        } );
    }
}