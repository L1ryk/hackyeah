using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Helpers;
using WebAPI.Migrations;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Courses;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class CourseAccessor : ICourseAccessor
{
    private readonly ApiDbContext _dbContext;
    public CourseAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllCoursesResponse> GetAllCoursesAsync( Pagination pagination )
    {
        var result = await QueryHelper.GetPaginatedQuery<UniversityCourse>( pagination, _dbContext );

        return new GetAllCoursesResponse { Items = result.Result, ItemCount = result.ItemsCount };
    }


    /// <summary>
    /// Get courses by: id, tags, name (search if contains)
    /// </summary>
    public async Task<GetAllCoursesResponse> GetCoursesAsync( GetCourses getCourses )
    {
        Guard.IsNotNull( getCourses );

        var res = await QueryHelper.PrepareCourseQueryAsync( getCourses, _dbContext );

        return new GetAllCoursesResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }
}