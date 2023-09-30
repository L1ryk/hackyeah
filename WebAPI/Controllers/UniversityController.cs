using Microsoft.AspNetCore.Mvc;
using WebAPI.DataSource.Accessors.UniversityAccessors;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses;
using WebAPI.Models.Responses.Cities;
using WebAPI.Models.Responses.Courses;
using WebAPI.Models.Responses.Universities;

namespace WebAPI.Controllers;

[ Route( "api/university" ) ]
public class UniversityController : ControllerBase
{
    private readonly IUniversityAccessor _universityAccessor;
    private readonly ICourseAccessor _courseAccessor;
    private readonly IUniversityCourseAccessor _universityCourseAccessor;

    public UniversityController( IUniversityAccessor universityAccessor, 
                                 ICourseAccessor courseAccessor, 
                                 IUniversityCourseAccessor universityCourseAccessor )
    {
        Guard.IsNotNull( universityAccessor );
        Guard.IsNotNull( courseAccessor );
        Guard.IsNotNull( universityCourseAccessor );

        _universityAccessor = universityAccessor;
        _courseAccessor = courseAccessor;
        _universityCourseAccessor = universityCourseAccessor;
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

    [ HttpGet( "courses" ) ]
    public async Task<IActionResult> GetCourses( [ FromQuery ] Pagination pagination )
    {
        Guard.IsNotNull( pagination );

        var courses = await _courseAccessor.GetAllCoursesAsync( pagination );

        return Ok( new Response<PaginatedResult<Course>>
        {
            IsSuccess = true, Result = new PaginatedResult<Course> { Items = courses.Items, ItemCount = courses.ItemCount }
        } );
    }

    [ HttpPost( "courses" ) ]
    public async Task<IActionResult> GetCourses( [ FromBody ] GetCourses getCourses )
    {
        Guard.IsNotNull( getCourses );

        var courses = await _courseAccessor.GetCoursesAsync( getCourses );

        return Ok( new Response<PaginatedResult<Course>>
        {
            IsSuccess = true, Result = new PaginatedResult<Course> { Items = courses.Items, ItemCount = courses.ItemCount }
        } );
    }

    [ HttpGet( "university-courses" ) ]
    public async Task<IActionResult> GetUniversityCourses( [ FromQuery ] Pagination pagination )
    {
        Guard.IsNotNull( pagination );

        var universityCourses = await _universityCourseAccessor.GetAllUniversityCoursesAsync( pagination );

        return Ok( new Response<PaginatedResult<UniversityCourse>>
        {
            IsSuccess = true, Result = new PaginatedResult<UniversityCourse> { Items = universityCourses.Items, ItemCount = universityCourses.ItemCount }
        } );
    }

    [ HttpPost( "university-courses" ) ]
    public async Task<IActionResult> GetUniversityCourses( [ FromBody ] GetCourses getUniversityCourses )
    {
        Guard.IsNotNull( getUniversityCourses );

        var universityCourses = await _universityCourseAccessor.GetUniversityCoursesAsync( getUniversityCourses );

        return Ok( new Response<PaginatedResult<UniversityCourse>>
        {
            IsSuccess = true, Result = new PaginatedResult<UniversityCourse> { Items = universityCourses.Items, ItemCount = universityCourses.ItemCount }
        } );
    }
}