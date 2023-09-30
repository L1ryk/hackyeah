﻿using Microsoft.AspNetCore.Mvc;
using WebAPI.DataSource.Accessors.LocationAccessors;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses;
using WebAPI.Models.Responses.Cities;
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
}