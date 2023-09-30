using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities.System;
using WebAPI.Helpers;
using WebAPI.Models.Pagination;
using WebAPI.Models.Responses;

namespace WebAPI.Controllers;

[Route( "api/location" )]
public class LocationController : Controller
{
    private ApiDbContext _dbContext;
    public LocationController( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    [ HttpGet( "cities" ) ]
    public async Task<IActionResult> Get( [ FromQuery ] Pagination pagination )
    {
        var cities = await _dbContext.Cities.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit ).ToListAsync();


        return Ok( new Response<PaginatedResult<City>>
        {
            IsSuccess = true,
            Result = new PaginatedResult<City>
            {
                Items = cities
            }
        } );
    }
}