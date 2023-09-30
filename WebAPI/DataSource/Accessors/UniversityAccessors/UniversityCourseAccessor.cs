using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Courses;
using WebAPI.Models.Responses.UniversityCourses;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class UniversityCourseAccessor : IUniversityCourseAccessor
{
    private readonly ApiDbContext _dbContext;
    public UniversityCourseAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllUniversityCoursesResponse> GetAllUniversityCoursesAsync( Pagination pagination )
    {
        var query = _dbContext.UniversityCourses;

        var itemsCount = await query.CountAsync();

        var universityCourses = await query.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit )
            .ToListAsync();

        return new GetAllUniversityCoursesResponse { Items = universityCourses, ItemCount = itemsCount };
    }

    public async Task<GetAllUniversityCoursesResponse> GetUniversityCoursesAsync( GetUniversityCourses getUniversityCourses )
    {
        Guard.IsNotNull( getUniversityCourses );

        var res = await QueryHelper.PrepareCourseQueryAsync( getUniversityCourses, _dbContext );

        return new GetAllUniversityCoursesResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }
}