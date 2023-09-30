using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Helpers;
using WebAPI.Models.Pagination;
using WebAPI.Models.Responses;
using WebAPI.Models.Responses.Universities;

namespace WebAPI.Controllers;

[Route("api/university")]
public class UniversityController : ControllerBase
{
    private readonly ApiDbContext _dbContext;

    public UniversityController( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );
        
        _dbContext = dbContext;
    }

    [HttpGet("universities")]
    public async Task<IActionResult> Get( [ FromQuery ] Pagination pagination )
    {
        var universities = await _dbContext.Universities
            .OrderBy( u => u.Name )
            .Skip( ( pagination.Page - 1 ) * pagination.Limit )
            .Take( pagination.Limit )
            .ToListAsync();
        
        var result = universities.Select( u => new UniversityResponse()
        {
            Id = u.Id,
            Name = u.Name,
            City = u.Details.City,
            Voivodeship = u.Details.Voivodeship
        } );

        return Ok( new Response<PaginatedResult<UniversityResponse>>
        {
            IsSuccess = true,
            Result = new PaginatedResult<UniversityResponse>()
            {
                Items = result
            }
        } );
    }

    [ HttpGet( "details" ) ]
    public async Task<IActionResult> Get( [ FromQuery ] Guid universityId )
    {
        var details = await _dbContext.UniversitiesDetails
            .FirstAsync( d => d.Id == universityId );
        
        return Ok(new Response<UniversityDetails>
        {
            IsSuccess = true,
            Result = details
        });
    }
}
