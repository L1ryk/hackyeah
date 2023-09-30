using Microsoft.AspNetCore.Mvc;
using WebAPI.DataSource.Accessors.UniversityAccessors;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses;
using WebAPI.Models.Responses.Universities;

namespace WebAPI.Controllers;

[ Route( "api/university" ) ]
public class UniversityController : ControllerBase
{
    private readonly IUniversityAccessor _universityAccessor;

    public UniversityController( IUniversityAccessor universityAccessor )
    {
        Guard.IsNotNull( universityAccessor );

        _universityAccessor = universityAccessor;
    }

    [ HttpGet( "universities" ) ]
    public async Task<IActionResult> Get( [ FromQuery ] Pagination pagination )
    {
        var universities = await _universityAccessor.GetAllUniversitiesAsync( pagination );

        return Ok( new Response<PaginatedResult<SimplifiedUniversityDto>>
        {
            IsSuccess = true,
            Result = new PaginatedResult<SimplifiedUniversityDto>()
            {
                Items = universities.Items, ItemCount = universities.ItemCount
            }
        } );
    }
}